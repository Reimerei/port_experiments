// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class TypeLevel : Table {
  public static TypeLevel GetRootAsTypeLevel(ByteBuffer _bb) { return GetRootAsTypeLevel(_bb, new TypeLevel()); }
  public static TypeLevel GetRootAsTypeLevel(ByteBuffer _bb, TypeLevel obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public TypeLevel __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Type { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public sbyte Level { get { int o = __offset(6); return o != 0 ? bb.GetSbyte(o + bb_pos) : (sbyte)0; } }

  public static Offset<TypeLevel> CreateTypeLevel(FlatBufferBuilder builder,
      StringOffset type = default(StringOffset),
      sbyte level = 0) {
    builder.StartObject(2);
    TypeLevel.AddType(builder, type);
    TypeLevel.AddLevel(builder, level);
    return TypeLevel.EndTypeLevel(builder);
  }

  public static void StartTypeLevel(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddType(FlatBufferBuilder builder, StringOffset typeOffset) { builder.AddOffset(0, typeOffset.Value, 0); }
  public static void AddLevel(FlatBufferBuilder builder, sbyte level) { builder.AddSbyte(1, level, 0); }
  public static Offset<TypeLevel> EndTypeLevel(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<TypeLevel>(o);
  }
};


}
