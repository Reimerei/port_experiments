// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class Defence : Table {
  public static Defence GetRootAsDefence(ByteBuffer _bb) { return GetRootAsDefence(_bb, new Defence()); }
  public static Defence GetRootAsDefence(ByteBuffer _bb, Defence obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public Defence __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Type { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public sbyte Level { get { int o = __offset(6); return o != 0 ? bb.GetSbyte(o + bb_pos) : (sbyte)0; } }
  public int Hp { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<Defence> CreateDefence(FlatBufferBuilder builder,
      StringOffset type = default(StringOffset),
      sbyte level = 0,
      int hp = 0) {
    builder.StartObject(3);
    Defence.AddHp(builder, hp);
    Defence.AddType(builder, type);
    Defence.AddLevel(builder, level);
    return Defence.EndDefence(builder);
  }

  public static void StartDefence(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddType(FlatBufferBuilder builder, StringOffset typeOffset) { builder.AddOffset(0, typeOffset.Value, 0); }
  public static void AddLevel(FlatBufferBuilder builder, sbyte level) { builder.AddSbyte(1, level, 0); }
  public static void AddHp(FlatBufferBuilder builder, int hp) { builder.AddInt(2, hp, 0); }
  public static Offset<Defence> EndDefence(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Defence>(o);
  }
};


}
