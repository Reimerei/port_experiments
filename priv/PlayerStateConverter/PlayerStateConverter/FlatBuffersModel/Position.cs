// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class Position : Table {
  public static Position GetRootAsPosition(ByteBuffer _bb) { return GetRootAsPosition(_bb, new Position()); }
  public static Position GetRootAsPosition(ByteBuffer _bb, Position obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public Position __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public short X { get { int o = __offset(4); return o != 0 ? bb.GetShort(o + bb_pos) : (short)0; } }
  public short Y { get { int o = __offset(6); return o != 0 ? bb.GetShort(o + bb_pos) : (short)0; } }

  public static Offset<Position> CreatePosition(FlatBufferBuilder builder,
      short x = 0,
      short y = 0) {
    builder.StartObject(2);
    Position.AddY(builder, y);
    Position.AddX(builder, x);
    return Position.EndPosition(builder);
  }

  public static void StartPosition(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddX(FlatBufferBuilder builder, short x) { builder.AddShort(0, x, 0); }
  public static void AddY(FlatBufferBuilder builder, short y) { builder.AddShort(1, y, 0); }
  public static Offset<Position> EndPosition(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Position>(o);
  }
};


}
