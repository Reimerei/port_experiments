// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class TypeAmount : Table {
  public static TypeAmount GetRootAsTypeAmount(ByteBuffer _bb) { return GetRootAsTypeAmount(_bb, new TypeAmount()); }
  public static TypeAmount GetRootAsTypeAmount(ByteBuffer _bb, TypeAmount obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public TypeAmount __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Type { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public int Amount { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<TypeAmount> CreateTypeAmount(FlatBufferBuilder builder,
      StringOffset type = default(StringOffset),
      int amount = 0) {
    builder.StartObject(2);
    TypeAmount.AddAmount(builder, amount);
    TypeAmount.AddType(builder, type);
    return TypeAmount.EndTypeAmount(builder);
  }

  public static void StartTypeAmount(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddType(FlatBufferBuilder builder, StringOffset typeOffset) { builder.AddOffset(0, typeOffset.Value, 0); }
  public static void AddAmount(FlatBufferBuilder builder, int amount) { builder.AddInt(1, amount, 0); }
  public static Offset<TypeAmount> EndTypeAmount(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<TypeAmount>(o);
  }
};


}
