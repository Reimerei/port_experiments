// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class TimeInterval : Table {
  public static TimeInterval GetRootAsTimeInterval(ByteBuffer _bb) { return GetRootAsTimeInterval(_bb, new TimeInterval()); }
  public static TimeInterval GetRootAsTimeInterval(ByteBuffer _bb, TimeInterval obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public TimeInterval __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public long Start { get { int o = __offset(4); return o != 0 ? bb.GetLong(o + bb_pos) : (long)0; } }
  public long End { get { int o = __offset(6); return o != 0 ? bb.GetLong(o + bb_pos) : (long)0; } }

  public static Offset<TimeInterval> CreateTimeInterval(FlatBufferBuilder builder,
      long start = 0,
      long end = 0) {
    builder.StartObject(2);
    TimeInterval.AddEnd(builder, end);
    TimeInterval.AddStart(builder, start);
    return TimeInterval.EndTimeInterval(builder);
  }

  public static void StartTimeInterval(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddStart(FlatBufferBuilder builder, long start) { builder.AddLong(0, start, 0); }
  public static void AddEnd(FlatBufferBuilder builder, long end) { builder.AddLong(1, end, 0); }
  public static Offset<TimeInterval> EndTimeInterval(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<TimeInterval>(o);
  }
};


}
