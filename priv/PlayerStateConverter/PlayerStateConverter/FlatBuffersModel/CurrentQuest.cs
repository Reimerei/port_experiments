// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class CurrentQuest : Table {
  public static CurrentQuest GetRootAsCurrentQuest(ByteBuffer _bb) { return GetRootAsCurrentQuest(_bb, new CurrentQuest()); }
  public static CurrentQuest GetRootAsCurrentQuest(ByteBuffer _bb, CurrentQuest obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public CurrentQuest __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Name { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public int TaskAmountToComplete { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int TaskAmountDone { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public bool Done { get { int o = __offset(10); return o != 0 ? 0!=bb.Get(o + bb_pos) : (bool)false; } }

  public static Offset<CurrentQuest> CreateCurrentQuest(FlatBufferBuilder builder,
      StringOffset name = default(StringOffset),
      int taskAmountToComplete = 0,
      int taskAmountDone = 0,
      bool done = false) {
    builder.StartObject(4);
    CurrentQuest.AddTaskAmountDone(builder, taskAmountDone);
    CurrentQuest.AddTaskAmountToComplete(builder, taskAmountToComplete);
    CurrentQuest.AddName(builder, name);
    CurrentQuest.AddDone(builder, done);
    return CurrentQuest.EndCurrentQuest(builder);
  }

  public static void StartCurrentQuest(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddTaskAmountToComplete(FlatBufferBuilder builder, int taskAmountToComplete) { builder.AddInt(1, taskAmountToComplete, 0); }
  public static void AddTaskAmountDone(FlatBufferBuilder builder, int taskAmountDone) { builder.AddInt(2, taskAmountDone, 0); }
  public static void AddDone(FlatBufferBuilder builder, bool done) { builder.AddBool(3, done, false); }
  public static Offset<CurrentQuest> EndCurrentQuest(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<CurrentQuest>(o);
  }
};


}
