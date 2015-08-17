using System;
using DogeFB;
using Entitas;
using System.Collections.Generic;


class FBDeserializationService
{

	public static readonly FBDeserializationService singleton = new FBDeserializationService();
	
	public Pool corePool = new Pool(CoreGameComponentIds.TotalComponents);
	public Pool metaPool = new Pool(MetaGameComponentIds.TotalComponents);
	
	public void Deserialize (GameStateRoot gameState)
	{
		corePool = new Pool(CoreGameComponentIds.TotalComponents);
		metaPool = new Pool(MetaGameComponentIds.TotalComponents);

		CreateBuildings (gameState);
		CreateIslands (gameState);
		CreatePlayerResources(gameState);
		CreateUnits(gameState);
		CreateWorkers(gameState);
		CreateTechnologies(gameState);
		CreateSectors(gameState);
		CreateCompletedQuests(gameState);
		CreateCurrentQuests(gameState);
		CreateDefences(gameState);
		CreateShips(gameState);	
		metaPool.SetTrophies(gameState.GameData1.Trophies);
	}

	void CreateSectors (GameStateRoot gameState)
	{
		int amount = gameState.GameData1.SectorsLength;
		int length = (int)Math.Sqrt(amount);
		bool[,] sectors = new bool[length, length];
		for (int i = 0; i < amount; i++) {
			int row = i / length;
			int col = i % length;
			sectors[col, row] = gameState.GameData1.GetSectors(i);
		}
		metaPool.SetIslandSectors(sectors);
	}

	void CreatePlayerResources (GameStateRoot gameState)
	{
		int amount = gameState.GameData1.PlayerResourcesLength;
		Dictionary<string, int> resources = new Dictionary<string, int>();
		for (int i = 0; i < amount; i++) {
			TypeAmount typeAmount = gameState.GameData1.GetPlayerResources (i);
			resources[typeAmount.Type] = typeAmount.Amount;
		}
		metaPool.SetPlayerResources(resources, new Dictionary<string, int>());
	}

	void CreateUnits (GameStateRoot gameState)
	{
		int amount = gameState.GameData1.UnitLevelsLength;
		Dictionary<string, int> resources = new Dictionary<string, int>();
		for (int i = 0; i < amount; i++) {
			TypeLevel typeAmount = gameState.GameData1.GetUnitLevels (i);
			resources[typeAmount.Type] = typeAmount.Level;
		}
		metaPool.SetUnitLevels(resources);
	}

	void CreateWorkers (GameStateRoot gameState)
	{
		metaPool.SetAssignedWorkers(gameState.GameData1.Workers.AssignedWorkers);
		metaPool.SetWorkersProduction(gameState.GameData1.Workers.ProductionStartTime.GetDateTimeFromMicroseconds());
	}

	void CreateTechnologies (GameStateRoot gameState)
	{
		int amount = gameState.GameData1.TechnologiesLength;
		var technologies = new HashSet<string>();
		for (int i = 0; i < amount; i++) {
			technologies.Add(gameState.GameData1.GetTechnologies (i));
		}
		metaPool.SetTechnologies(technologies);
	}

	void CreateCompletedQuests (GameStateRoot gameState)
	{
		int amount = gameState.GameData1.CompletedQuestsLength;
		var questNames = new HashSet<string>();
		for (int i = 0; i < amount; i++) {
			questNames.Add(gameState.GameData1.GetCompletedQuests (i));
		}
		metaPool.SetQuestsCompleted(questNames);
	}

	void CreateCurrentQuests (GameStateRoot gameState)
	{
		int amount = gameState.GameData1.CurrentQuestsLength;
		for (int i = 0; i < amount; i++) {
			var currentQuest = gameState.GameData1.GetCurrentQuests(i);
			var e = metaPool.CreateEntity();
			e.AddQuest(currentQuest.Name);
			e.AddQuestTaskAmount(currentQuest.TaskAmountToComplete, currentQuest.TaskAmountDone);
			e.isQuestDone = currentQuest.Done;
		}
	}

	void CreateDefences (GameStateRoot gameState)
	{
		int amount = gameState.GameData1.DefencesLength;
		for (int i = 0; i < amount; i++) {
			var defence = gameState.GameData1.GetDefences(i);
			var e = corePool.CreateEntity();
			e.isDefence = true;
			e.AddType(defence.Type);
			e.AddLevel(defence.Level);
//			e.AddOrder(defence.
			if(defence.Upgrading){
				e.isUpgrading = true;
				e.AddStartEndTime(defence.UpgradingTime.Start.GetDateTimeFromMicroseconds(), defence.UpgradingTime.End.GetDateTimeFromMicroseconds());
			}
		}
	}

	void CreateShips (GameStateRoot gameState)
	{
		int amount = gameState.GameData1.ShipsLength;
		for (int i = 0; i < amount; i++) {
			var ship = gameState.GameData1.GetShips(i);
			var e = corePool.CreateEntity();

			e.isShip = true;

			e.isDefence = true;
			e.AddType(ship.Type);
			e.AddLevel(ship.Level);
			e.AddShipStatus(ship.Status);
			e.AddOrder(ship.Order);
			var cargo = new Dictionary<string, int>();
			for (int j = 0; i < ship.CargoLength; j++) {
				cargo[ship.GetCargo(j).Type] = ship.GetCargo(j).Amount;
			}
			e.AddShipCargo(cargo);

			var armyCargo = new Dictionary<string, int>();
			for (int j = 0; i < ship.ArmyCargoLength; j++) {
				armyCargo[ship.GetArmyCargo(j).Type] = ship.GetArmyCargo(j).Amount;
			}
			e.AddShipArmyCargo(cargo);
		}
	}

	void CreateIslands (GameStateRoot gameState)
	{
		int amount = gameState.GameData1.IslandsLength;
		for (int i = 0; i < amount; i++) {
			var e = corePool.CreateEntity ();
			e.isIsland = true;
			Island island = gameState.GameData1.GetIslands (i);
			e.AddLevel(island.Level);
			e.AddIslandID(island.Name);
			e.AddIslandOwner(island.Owner);
			if(island.Production != null){
				e.AddProduction (island.Production.Start.GetDateTimeFromMicroseconds (), island.Production.End.GetDateTimeFromMicroseconds ());
			}
			if(island.DefencesLength > 0){
				List<IslandDefence> defences = new List<IslandDefence>();
				for (int j = 0; j < island.DefencesLength; j++) {
					var defence = island.GetDefences(j);
					defences.Add(new IslandDefence(defence.Type, defence.Level, defence.Hp));
				}
				e.AddIslandDefence(defences);
			}
		}
	}


	void CreateBuildings (GameStateRoot gameState)
	{
		int amountOfBuildings = gameState.GameData1.BuildingsLength;
		for (int i = 0; i < amountOfBuildings; i++) {
			var e = corePool.CreateEntity ();
			e.isBuilding = true;
			Building building = gameState.GameData1.GetBuildings (i);
			e.AddPosition (building.Position.X, building.Position.Y);
			e.AddType (building.Type);
			e.AddLevel (building.Level);
			if (building.Production != null) {
				e.AddProduction (building.Production.Start.GetDateTimeFromMicroseconds (), building.Production.End.GetDateTimeFromMicroseconds ());
			}
			e.isProductionPaused = building.Paused;
			if (building.StorageLength > 0) {
				e.CreateBuildingStorage ();
				for (int j = 0; j < building.StorageLength; j++) {
					e.AddBuildingStorageItem (building.GetStorage (j).Type, building.GetStorage (j).Amount);
				}
			}
		}
	}
}
