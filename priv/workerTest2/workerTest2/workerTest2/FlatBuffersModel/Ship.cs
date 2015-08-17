// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class Ship : Table {
  public static Ship GetRootAsShip(ByteBuffer _bb) { return GetRootAsShip(_bb, new Ship()); }
  public static Ship GetRootAsShip(ByteBuffer _bb, Ship obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public Ship __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Type { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public float Status { get { int o = __offset(6); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public sbyte Order { get { int o = __offset(8); return o != 0 ? bb.GetSbyte(o + bb_pos) : (sbyte)0; } }
  public sbyte Level { get { int o = __offset(10); return o != 0 ? bb.GetSbyte(o + bb_pos) : (sbyte)0; } }
  public TypeAmount GetCargo(int j) { return GetCargo(new TypeAmount(), j); }
  public TypeAmount GetCargo(TypeAmount obj, int j) { int o = __offset(12); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int CargoLength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }
  public TypeAmount GetArmyCargo(int j) { return GetArmyCargo(new TypeAmount(), j); }
  public TypeAmount GetArmyCargo(TypeAmount obj, int j) { int o = __offset(14); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int ArmyCargoLength { get { int o = __offset(14); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<Ship> CreateShip(FlatBufferBuilder builder,
      StringOffset type = default(StringOffset),
      float status = 0,
      sbyte order = 0,
      sbyte level = 0,
      VectorOffset cargo = default(VectorOffset),
      VectorOffset armyCargo = default(VectorOffset)) {
    builder.StartObject(6);
    Ship.AddArmyCargo(builder, armyCargo);
    Ship.AddCargo(builder, cargo);
    Ship.AddStatus(builder, status);
    Ship.AddType(builder, type);
    Ship.AddLevel(builder, level);
    Ship.AddOrder(builder, order);
    return Ship.EndShip(builder);
  }

  public static void StartShip(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddType(FlatBufferBuilder builder, StringOffset typeOffset) { builder.AddOffset(0, typeOffset.Value, 0); }
  public static void AddStatus(FlatBufferBuilder builder, float status) { builder.AddFloat(1, status, 0); }
  public static void AddOrder(FlatBufferBuilder builder, sbyte order) { builder.AddSbyte(2, order, 0); }
  public static void AddLevel(FlatBufferBuilder builder, sbyte level) { builder.AddSbyte(3, level, 0); }
  public static void AddCargo(FlatBufferBuilder builder, VectorOffset cargoOffset) { builder.AddOffset(4, cargoOffset.Value, 0); }
  public static VectorOffset CreateCargoVector(FlatBufferBuilder builder, Offset<TypeAmount>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartCargoVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddArmyCargo(FlatBufferBuilder builder, VectorOffset armyCargoOffset) { builder.AddOffset(5, armyCargoOffset.Value, 0); }
  public static VectorOffset CreateArmyCargoVector(FlatBufferBuilder builder, Offset<TypeAmount>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartArmyCargoVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Ship> EndShip(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Ship>(o);
  }
};


}
