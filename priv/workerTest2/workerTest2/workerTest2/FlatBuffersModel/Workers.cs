// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class Workers : Table {
  public static Workers GetRootAsWorkers(ByteBuffer _bb) { return GetRootAsWorkers(_bb, new Workers()); }
  public static Workers GetRootAsWorkers(ByteBuffer _bb, Workers obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public Workers __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public long ProductionStartTime { get { int o = __offset(4); return o != 0 ? bb.GetLong(o + bb_pos) : (long)0; } }
  public int AssignedWorkers { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<Workers> CreateWorkers(FlatBufferBuilder builder,
      long productionStartTime = 0,
      int assignedWorkers = 0) {
    builder.StartObject(2);
    Workers.AddProductionStartTime(builder, productionStartTime);
    Workers.AddAssignedWorkers(builder, assignedWorkers);
    return Workers.EndWorkers(builder);
  }

  public static void StartWorkers(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddProductionStartTime(FlatBufferBuilder builder, long productionStartTime) { builder.AddLong(0, productionStartTime, 0); }
  public static void AddAssignedWorkers(FlatBufferBuilder builder, int assignedWorkers) { builder.AddInt(1, assignedWorkers, 0); }
  public static Offset<Workers> EndWorkers(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Workers>(o);
  }
};


}
