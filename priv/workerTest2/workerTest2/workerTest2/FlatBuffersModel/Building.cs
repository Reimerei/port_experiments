// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class Building : Table {
  public static Building GetRootAsBuilding(ByteBuffer _bb) { return GetRootAsBuilding(_bb, new Building()); }
  public static Building GetRootAsBuilding(ByteBuffer _bb, Building obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public Building __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Type { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public sbyte Level { get { int o = __offset(6); return o != 0 ? bb.GetSbyte(o + bb_pos) : (sbyte)0; } }
  public Position Position { get { return GetPosition(new Position()); } }
  public Position GetPosition(Position obj) { int o = __offset(8); return o != 0 ? obj.__init(__indirect(o + bb_pos), bb) : null; }
  public bool Paused { get { int o = __offset(10); return o != 0 ? 0!=bb.Get(o + bb_pos) : (bool)false; } }
  public TimeInterval Production { get { return GetProduction(new TimeInterval()); } }
  public TimeInterval GetProduction(TimeInterval obj) { int o = __offset(12); return o != 0 ? obj.__init(__indirect(o + bb_pos), bb) : null; }
  public TypeAmount GetStorage(int j) { return GetStorage(new TypeAmount(), j); }
  public TypeAmount GetStorage(TypeAmount obj, int j) { int o = __offset(14); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int StorageLength { get { int o = __offset(14); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<Building> CreateBuilding(FlatBufferBuilder builder,
      StringOffset type = default(StringOffset),
      sbyte level = 0,
      Offset<Position> position = default(Offset<Position>),
      bool paused = false,
      Offset<TimeInterval> production = default(Offset<TimeInterval>),
      VectorOffset storage = default(VectorOffset)) {
    builder.StartObject(6);
    Building.AddStorage(builder, storage);
    Building.AddProduction(builder, production);
    Building.AddPosition(builder, position);
    Building.AddType(builder, type);
    Building.AddPaused(builder, paused);
    Building.AddLevel(builder, level);
    return Building.EndBuilding(builder);
  }

  public static void StartBuilding(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddType(FlatBufferBuilder builder, StringOffset typeOffset) { builder.AddOffset(0, typeOffset.Value, 0); }
  public static void AddLevel(FlatBufferBuilder builder, sbyte level) { builder.AddSbyte(1, level, 0); }
  public static void AddPosition(FlatBufferBuilder builder, Offset<Position> positionOffset) { builder.AddOffset(2, positionOffset.Value, 0); }
  public static void AddPaused(FlatBufferBuilder builder, bool paused) { builder.AddBool(3, paused, false); }
  public static void AddProduction(FlatBufferBuilder builder, Offset<TimeInterval> productionOffset) { builder.AddOffset(4, productionOffset.Value, 0); }
  public static void AddStorage(FlatBufferBuilder builder, VectorOffset storageOffset) { builder.AddOffset(5, storageOffset.Value, 0); }
  public static VectorOffset CreateStorageVector(FlatBufferBuilder builder, Offset<TypeAmount>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartStorageVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Building> EndBuilding(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Building>(o);
  }
};


}
