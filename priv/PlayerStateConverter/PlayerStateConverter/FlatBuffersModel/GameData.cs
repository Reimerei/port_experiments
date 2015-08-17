// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class GameData : Table {
  public static GameData GetRootAsGameData(ByteBuffer _bb) { return GetRootAsGameData(_bb, new GameData()); }
  public static GameData GetRootAsGameData(ByteBuffer _bb, GameData obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public GameData __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public Workers Workers { get { return GetWorkers(new Workers()); } }
  public Workers GetWorkers(Workers obj) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(o + bb_pos), bb) : null; }
  public TypeLevel GetUnitLevels(int j) { return GetUnitLevels(new TypeLevel(), j); }
  public TypeLevel GetUnitLevels(TypeLevel obj, int j) { int o = __offset(6); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int UnitLevelsLength { get { int o = __offset(6); return o != 0 ? __vector_len(o) : 0; } }
  public int Trophies { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public string GetTechnologies(int j) { int o = __offset(10); return o != 0 ? __string(__vector(o) + j * 4) : null; }
  public int TechnologiesLength { get { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; } }
  public Ship GetShips(int j) { return GetShips(new Ship(), j); }
  public Ship GetShips(Ship obj, int j) { int o = __offset(12); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int ShipsLength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }
  public bool GetSectors(int j) { int o = __offset(14); return o != 0 ? 0!=bb.Get(__vector(o) + j * 1) : false; }
  public int SectorsLength { get { int o = __offset(14); return o != 0 ? __vector_len(o) : 0; } }
  public CurrentQuest GetCurrentQuests(int j) { return GetCurrentQuests(new CurrentQuest(), j); }
  public CurrentQuest GetCurrentQuests(CurrentQuest obj, int j) { int o = __offset(16); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int CurrentQuestsLength { get { int o = __offset(16); return o != 0 ? __vector_len(o) : 0; } }
  public string GetCompletedQuests(int j) { int o = __offset(18); return o != 0 ? __string(__vector(o) + j * 4) : null; }
  public int CompletedQuestsLength { get { int o = __offset(18); return o != 0 ? __vector_len(o) : 0; } }
  public TypeAmount GetPlayerResources(int j) { return GetPlayerResources(new TypeAmount(), j); }
  public TypeAmount GetPlayerResources(TypeAmount obj, int j) { int o = __offset(20); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int PlayerResourcesLength { get { int o = __offset(20); return o != 0 ? __vector_len(o) : 0; } }
  public string PlayerName { get { int o = __offset(22); return o != 0 ? __string(o + bb_pos) : null; } }
  public long NextPirateAttack { get { int o = __offset(24); return o != 0 ? bb.GetLong(o + bb_pos) : (long)0; } }
  public TypeAmount GetLeftOverResources(int j) { return GetLeftOverResources(new TypeAmount(), j); }
  public TypeAmount GetLeftOverResources(TypeAmount obj, int j) { int o = __offset(26); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int LeftOverResourcesLength { get { int o = __offset(26); return o != 0 ? __vector_len(o) : 0; } }
  public Island GetIslands(int j) { return GetIslands(new Island(), j); }
  public Island GetIslands(Island obj, int j) { int o = __offset(28); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int IslandsLength { get { int o = __offset(28); return o != 0 ? __vector_len(o) : 0; } }
  public sbyte FortressLevel { get { int o = __offset(30); return o != 0 ? bb.GetSbyte(o + bb_pos) : (sbyte)0; } }
  public CityDefences GetDefences(int j) { return GetDefences(new CityDefences(), j); }
  public CityDefences GetDefences(CityDefences obj, int j) { int o = __offset(32); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int DefencesLength { get { int o = __offset(32); return o != 0 ? __vector_len(o) : 0; } }
  public Building GetBuildings(int j) { return GetBuildings(new Building(), j); }
  public Building GetBuildings(Building obj, int j) { int o = __offset(34); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int BuildingsLength { get { int o = __offset(34); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<GameData> CreateGameData(FlatBufferBuilder builder,
      Offset<Workers> workers = default(Offset<Workers>),
      VectorOffset unitLevels = default(VectorOffset),
      int trophies = 0,
      VectorOffset technologies = default(VectorOffset),
      VectorOffset ships = default(VectorOffset),
      VectorOffset sectors = default(VectorOffset),
      VectorOffset currentQuests = default(VectorOffset),
      VectorOffset completedQuests = default(VectorOffset),
      VectorOffset playerResources = default(VectorOffset),
      StringOffset playerName = default(StringOffset),
      long nextPirateAttack = 0,
      VectorOffset leftOverResources = default(VectorOffset),
      VectorOffset islands = default(VectorOffset),
      sbyte fortressLevel = 0,
      VectorOffset defences = default(VectorOffset),
      VectorOffset buildings = default(VectorOffset)) {
    builder.StartObject(16);
    GameData.AddNextPirateAttack(builder, nextPirateAttack);
    GameData.AddBuildings(builder, buildings);
    GameData.AddDefences(builder, defences);
    GameData.AddIslands(builder, islands);
    GameData.AddLeftOverResources(builder, leftOverResources);
    GameData.AddPlayerName(builder, playerName);
    GameData.AddPlayerResources(builder, playerResources);
    GameData.AddCompletedQuests(builder, completedQuests);
    GameData.AddCurrentQuests(builder, currentQuests);
    GameData.AddSectors(builder, sectors);
    GameData.AddShips(builder, ships);
    GameData.AddTechnologies(builder, technologies);
    GameData.AddTrophies(builder, trophies);
    GameData.AddUnitLevels(builder, unitLevels);
    GameData.AddWorkers(builder, workers);
    GameData.AddFortressLevel(builder, fortressLevel);
    return GameData.EndGameData(builder);
  }

  public static void StartGameData(FlatBufferBuilder builder) { builder.StartObject(16); }
  public static void AddWorkers(FlatBufferBuilder builder, Offset<Workers> workersOffset) { builder.AddOffset(0, workersOffset.Value, 0); }
  public static void AddUnitLevels(FlatBufferBuilder builder, VectorOffset unitLevelsOffset) { builder.AddOffset(1, unitLevelsOffset.Value, 0); }
  public static VectorOffset CreateUnitLevelsVector(FlatBufferBuilder builder, Offset<TypeLevel>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartUnitLevelsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddTrophies(FlatBufferBuilder builder, int trophies) { builder.AddInt(2, trophies, 0); }
  public static void AddTechnologies(FlatBufferBuilder builder, VectorOffset technologiesOffset) { builder.AddOffset(3, technologiesOffset.Value, 0); }
  public static VectorOffset CreateTechnologiesVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartTechnologiesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddShips(FlatBufferBuilder builder, VectorOffset shipsOffset) { builder.AddOffset(4, shipsOffset.Value, 0); }
  public static VectorOffset CreateShipsVector(FlatBufferBuilder builder, Offset<Ship>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartShipsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddSectors(FlatBufferBuilder builder, VectorOffset sectorsOffset) { builder.AddOffset(5, sectorsOffset.Value, 0); }
  public static VectorOffset CreateSectorsVector(FlatBufferBuilder builder, bool[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddBool(data[i]); return builder.EndVector(); }
  public static void StartSectorsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddCurrentQuests(FlatBufferBuilder builder, VectorOffset currentQuestsOffset) { builder.AddOffset(6, currentQuestsOffset.Value, 0); }
  public static VectorOffset CreateCurrentQuestsVector(FlatBufferBuilder builder, Offset<CurrentQuest>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartCurrentQuestsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddCompletedQuests(FlatBufferBuilder builder, VectorOffset completedQuestsOffset) { builder.AddOffset(7, completedQuestsOffset.Value, 0); }
  public static VectorOffset CreateCompletedQuestsVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartCompletedQuestsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddPlayerResources(FlatBufferBuilder builder, VectorOffset playerResourcesOffset) { builder.AddOffset(8, playerResourcesOffset.Value, 0); }
  public static VectorOffset CreatePlayerResourcesVector(FlatBufferBuilder builder, Offset<TypeAmount>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartPlayerResourcesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddPlayerName(FlatBufferBuilder builder, StringOffset playerNameOffset) { builder.AddOffset(9, playerNameOffset.Value, 0); }
  public static void AddNextPirateAttack(FlatBufferBuilder builder, long nextPirateAttack) { builder.AddLong(10, nextPirateAttack, 0); }
  public static void AddLeftOverResources(FlatBufferBuilder builder, VectorOffset leftOverResourcesOffset) { builder.AddOffset(11, leftOverResourcesOffset.Value, 0); }
  public static VectorOffset CreateLeftOverResourcesVector(FlatBufferBuilder builder, Offset<TypeAmount>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartLeftOverResourcesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddIslands(FlatBufferBuilder builder, VectorOffset islandsOffset) { builder.AddOffset(12, islandsOffset.Value, 0); }
  public static VectorOffset CreateIslandsVector(FlatBufferBuilder builder, Offset<Island>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartIslandsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddFortressLevel(FlatBufferBuilder builder, sbyte fortressLevel) { builder.AddSbyte(13, fortressLevel, 0); }
  public static void AddDefences(FlatBufferBuilder builder, VectorOffset defencesOffset) { builder.AddOffset(14, defencesOffset.Value, 0); }
  public static VectorOffset CreateDefencesVector(FlatBufferBuilder builder, Offset<CityDefences>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartDefencesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddBuildings(FlatBufferBuilder builder, VectorOffset buildingsOffset) { builder.AddOffset(15, buildingsOffset.Value, 0); }
  public static VectorOffset CreateBuildingsVector(FlatBufferBuilder builder, Offset<Building>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartBuildingsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<GameData> EndGameData(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GameData>(o);
  }
};


}
