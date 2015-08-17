// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class GameStateRoot : Table {
  public static GameStateRoot GetRootAsGameStateRoot(ByteBuffer _bb) { return GetRootAsGameStateRoot(_bb, new GameStateRoot()); }
  public static GameStateRoot GetRootAsGameStateRoot(ByteBuffer _bb, GameStateRoot obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public GameStateRoot __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int Version { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public GameData GameData1 { get { return GetGameData1(new GameData()); } }
  public GameData GetGameData1(GameData obj) { int o = __offset(6); return o != 0 ? obj.__init(__indirect(o + bb_pos), bb) : null; }

  public static Offset<GameStateRoot> CreateGameStateRoot(FlatBufferBuilder builder,
      int version = 0,
      Offset<GameData> gameData1 = default(Offset<GameData>)) {
    builder.StartObject(2);
    GameStateRoot.AddGameData1(builder, gameData1);
    GameStateRoot.AddVersion(builder, version);
    return GameStateRoot.EndGameStateRoot(builder);
  }

  public static void StartGameStateRoot(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddVersion(FlatBufferBuilder builder, int version) { builder.AddInt(0, version, 0); }
  public static void AddGameData1(FlatBufferBuilder builder, Offset<GameData> gameData1Offset) { builder.AddOffset(1, gameData1Offset.Value, 0); }
  public static Offset<GameStateRoot> EndGameStateRoot(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GameStateRoot>(o);
  }
  public static void FinishGameStateRootBuffer(FlatBufferBuilder builder, Offset<GameStateRoot> offset) { builder.Finish(offset.Value); }
};


}
