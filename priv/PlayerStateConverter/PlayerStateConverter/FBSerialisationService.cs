using FlatBuffers;
using System.IO;
using Entitas;
using DogeFB;

public class FBSerialisationService 
{
	public static readonly FBSerialisationService singleton = new FBSerialisationService();

	public Pool corePool = new Pool(CoreGameComponentIds.TotalComponents);
	public Pool metaPool = new Pool(MetaGameComponentIds.TotalComponents);

	public byte[] GenerateGameState()
	{   

		FlatBufferBuilder fbb = default(FlatBufferBuilder);

		fbb = new FlatBufferBuilder (1);
		MakeGameState (fbb);
		return new MemoryStream(fbb.DataBuffer.Data, fbb.DataBuffer.Position, fbb.Offset).ToArray();
	}

	void MakeGameState (FlatBufferBuilder fbb)
	{
		var playerName = createPlayerName (fbb);
		var resources = TypeAmountVector (fbb, metaPool.playerResources.quantities);
		var workers = createWorkers (fbb);
		var units = TypeLevelVector (fbb, metaPool.unitLevels.values);
		var islands = createIslands (fbb);
		var buildings = createBuildings(fbb);
		var technologies = createTechnologies(fbb);
		var sectors = createSectors(fbb);
		var completedQuests = createCompletedQuests(fbb);
		var currentQuests = createCurrentQuests(fbb);
		var defences = createDefences(fbb);
		var ships = createShips(fbb);
		
		GameData.StartGameData (fbb);
		GameData.AddPlayerName (fbb, playerName);
		GameData.AddPlayerResources (fbb, resources);
		GameData.AddWorkers (fbb, workers);
		GameData.AddUnitLevels (fbb, units);
		GameData.AddIslands (fbb, islands);
		GameData.AddBuildings (fbb, buildings);
		GameData.AddTrophies(fbb, metaPool.GetTrophies());
		GameData.AddTechnologies(fbb, technologies);
		GameData.AddSectors(fbb, sectors);
		GameData.AddShips (fbb, ships);
		GameData.AddCompletedQuests(fbb, completedQuests);
		GameData.AddCurrentQuests(fbb, currentQuests);
		GameData.AddDefences(fbb, defences);
		
		if(metaPool.hasIslandNextPirateAttack){
			GameData.AddNextPirateAttack(fbb, metaPool.islandNextPirateAttack.time.GetMicrosecondsFromEpoch());
		}
		
		if(metaPool.hasLeftOverResources){
			GameData.AddLeftOverResources(fbb, TypeAmountVector (fbb, metaPool.leftOverResources.resources));
			
		}
		
		if(corePool.isFortress){
			GameData.AddFortressLevel(fbb, (sbyte)corePool.fortressEntity.level.value);
		}
		
		Offset<GameData> gameData = GameData.EndGameData (fbb);
		GameStateRoot.StartGameStateRoot (fbb);
		GameStateRoot.AddGameData1 (fbb, gameData);
		Offset<GameStateRoot> root = GameStateRoot.EndGameStateRoot (fbb);
		fbb.Finish (root.Value);
	}
	
	StringOffset createPlayerName(FlatBufferBuilder fbb)
	{
		return fbb.CreateString("Caterina Spadari");//fbb.CreateString(GameSetupBehaviour.credentials.credentials.name);
	}
	
	Offset<Workers> createWorkers(FlatBufferBuilder fbb)
	{
		return Workers.CreateWorkers(fbb, metaPool.workersProduction.startTime.GetMicrosecondsFromEpoch(), metaPool.assignedWorkers.count);
	}
	
	VectorOffset createIslands(FlatBufferBuilder fbb)
	{
		Entity[] entities = corePool.GetGroup(CoreGameMatcher.Island).GetEntities();
		int count = entities.Length;
		Offset<Island>[] islands = new Offset<Island>[count];
		for (int i = 0; i < count; i++) {
			var e = entities[i];
			
			var defences = IslandDefences (fbb, e);
			
			Offset<TimeInterval> production = Production(fbb, e);
			
			islands[i] = Island.CreateIsland (fbb, fbb.CreateString (entities [i].islandID.value), fbb.CreateString (entities [i].islandOwner.value), (sbyte)e.level.value, production, defences);
		}
		return GameData.CreateIslandsVector(fbb, islands);
	}
	
	VectorOffset IslandDefences (FlatBufferBuilder fbb, Entity e)
	{
		VectorOffset defences = default(VectorOffset);
		if (e.hasIslandDefence) {
			int defencesCount = e.islandDefence.defences.Count;
			Offset<Defence>[] defenceArray = new Offset<Defence>[defencesCount];
			for (int j = 0; j < defencesCount; j++) {
				var defenceType = fbb.CreateString (e.islandDefence.defences [j].type);
				defenceArray [j] = Defence.CreateDefence (fbb, defenceType, (sbyte)e.islandDefence.defences [j].level, e.islandDefence.defences [j].hp);
			}
			defences = Island.CreateDefencesVector (fbb, defenceArray);
		}
		return defences;
	}
	
	Offset<TimeInterval> Production (FlatBufferBuilder fbb, Entity e)
	{
		Offset<TimeInterval> production = e.hasProduction ? TimeInterval.CreateTimeInterval (fbb, e.production.startTime.GetMicrosecondsFromEpoch (), e.production.endTime.GetMicrosecondsFromEpoch ()) : default(Offset<TimeInterval>);
		return production;
	}
	
	VectorOffset createBuildings(FlatBufferBuilder fbb)
	{
		Entity[] entities = corePool.GetGroup(CoreGameMatcher.Building).GetEntities();
		int count = entities.Length;
		Offset<Building>[] buildings = new Offset<Building>[count];
		for (int i = 0; i < count; i++) {
			var e = entities[i];
			var production = Production (fbb, e);
			StringOffset buildingType = fbb.CreateString (e.type.value);
			Offset<Position> position = Position.CreatePosition(fbb, (short)e.position.x, (short)e.position.y);
			VectorOffset storage = e.hasBuildingStorage ? TypeAmountVector(fbb, e.buildingStorage.items) : default(VectorOffset);;
			buildings[i] = Building.CreateBuilding(fbb, buildingType, (sbyte)e.level.value, position, e.isProductionPaused, production, storage); 
		}
		return GameData.CreateBuildingsVector(fbb, buildings);
	}
	
	VectorOffset createTechnologies(FlatBufferBuilder fbb)
	{
		if(!metaPool.hasTechnologies){
			return default(VectorOffset);
		}
		int count = metaPool.technologies.values.Count;
		
		StringOffset[] technologies = new StringOffset[count];
		int index = 0;
		foreach (var tech in metaPool.technologies.values) {
			technologies[index] = fbb.CreateString(tech);
			index++;
		}
		return GameData.CreateTechnologiesVector(fbb, technologies);
	}
	
	VectorOffset createCompletedQuests(FlatBufferBuilder fbb)
	{
		if(!metaPool.hasQuestsCompleted){
			return default(VectorOffset);
		}
		int count = metaPool.questsCompleted.ids.Count;
		
		StringOffset[] questArray = new StringOffset[count];
		int index = 0;
		foreach (var quests in metaPool.questsCompleted.ids) {
			questArray[index] = fbb.CreateString(quests);
			index++;
		}
		return GameData.CreateCompletedQuestsVector(fbb, questArray);
	}
	
	VectorOffset createShips(FlatBufferBuilder fbb)
	{
		Entity[] entities = corePool.GetGroup(CoreGameMatcher.Ship).GetEntities();
		int count = entities.Length;
		
		Offset<Ship>[] ships = new Offset<Ship>[count];
		for (int i = 0; i < count; i++) {
			var e = entities[i];
			StringOffset typeStringOffset = fbb.CreateString(e.type.value);
			VectorOffset cargo = e.hasShipCargo ? TypeAmountVector(fbb, e.shipCargo.items) : default(VectorOffset);
			VectorOffset armyCargo = e.hasShipArmyCargo ? TypeAmountVector(fbb, e.shipArmyCargo.troops) : default(VectorOffset);
			ships[i] = Ship.CreateShip(fbb, typeStringOffset, e.shipStatus.value, (sbyte)e.order.value, (sbyte)e.level.value, cargo, armyCargo);
		}
		return GameData.CreateShipsVector(fbb, ships);
	}
	
	VectorOffset TypeAmountVector(FlatBufferBuilder fbb, System.Collections.Generic.Dictionary<string, int> items)
	{
		if(items == null || items.Count == 0){
			return default(VectorOffset);
		}
		int count = items.Count;
		
		Offset<TypeAmount>[] resources = new Offset<TypeAmount>[count];
		int index = 0;
		foreach (var type in items.Keys) {
			StringOffset typeStringOffset = fbb.CreateString(type);
			resources[index] = TypeAmount.CreateTypeAmount(fbb,typeStringOffset, items[type]);
			index++;
		}
		
		fbb.StartVector(4, resources.Length, 4); 
		for (int i = resources.Length - 1; i >= 0; i--) fbb.AddOffset(resources[i].Value); 
		return fbb.EndVector(); 
	}
	
	VectorOffset TypeLevelVector(FlatBufferBuilder fbb, System.Collections.Generic.Dictionary<string, int> items)
	{
		var quantities = metaPool.unitLevels.values;
		int count = quantities.Count;
		
		Offset<TypeLevel>[] resources = new Offset<TypeLevel>[count];
		
		int index = 0;
		foreach (var type in quantities.Keys) {
			StringOffset typeStringOffset = fbb.CreateString(type);
			resources[index] = TypeLevel.CreateTypeLevel(fbb,typeStringOffset, (sbyte)quantities[type]);
			index++;
		}
		fbb.StartVector(4, resources.Length, 4); 
		for (int i = resources.Length - 1; i >= 0; i--) fbb.AddOffset(resources[i].Value); 
		return fbb.EndVector(); 
	}
	
	VectorOffset createSectors(FlatBufferBuilder fbb)
	{
		if(!metaPool.hasIslandSectors){
			return default(VectorOffset);
		}
		
		bool[,] sectors = metaPool.islandSectors.sectors;
		bool[] tmp = new bool[sectors.GetLength(0) * sectors.GetLength(1)];    
		System.Buffer.BlockCopy(sectors, 0, tmp, 0, tmp.Length * sizeof(bool));
		
		return GameData.CreateSectorsVector (fbb, tmp);
	}
	
	VectorOffset createCurrentQuests(FlatBufferBuilder fbb)
	{
		Entity[] entities = metaPool.GetGroup(Matcher.AllOf(MetaGameMatcher.Quest, MetaGameMatcher.QuestTaskAmount)).GetEntities();
		int count = entities.Length;
		
		Offset<CurrentQuest>[] quests = new Offset<CurrentQuest>[count];
		for (int i = 0; i < count; i++) {
			var e = entities[i];
			StringOffset questName = fbb.CreateString(e.quest.id);
			quests[i] = CurrentQuest.CreateCurrentQuest(fbb, questName, e.questTaskAmount.toComplete, e.questTaskAmount.done, e.isQuestDone);
		}
		return GameData.CreateCurrentQuestsVector(fbb, quests);
	}
	
	VectorOffset createDefences(FlatBufferBuilder fbb)
	{
		Entity[] entities = corePool.GetGroup(CoreGameMatcher.Defence).GetEntities();
		int count = entities.Length;
		
		Offset<CityDefences>[] defences = new Offset<CityDefences>[count];
		for (int i = 0; i < count; i++) {
			var e = entities[i];
			StringOffset type = fbb.CreateString(e.type.value);
			Offset<TimeInterval> production = e.hasStartEndTime ? TimeInterval.CreateTimeInterval (fbb, e.startEndTime.start.GetMicrosecondsFromEpoch (), e.startEndTime.end.GetMicrosecondsFromEpoch ()) : default(Offset<TimeInterval>);
			defences[i] = CityDefences.CreateCityDefences(fbb, type, (sbyte)e.level.value, e.isDefenceUpgrading, production);
		}
		return GameData.CreateDefencesVector(fbb, defences);
	}
}