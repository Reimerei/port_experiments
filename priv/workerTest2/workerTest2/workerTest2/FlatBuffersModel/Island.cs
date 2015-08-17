// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class Island : Table {
  public static Island GetRootAsIsland(ByteBuffer _bb) { return GetRootAsIsland(_bb, new Island()); }
  public static Island GetRootAsIsland(ByteBuffer _bb, Island obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public Island __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Name { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public string Owner { get { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; } }
  public sbyte Level { get { int o = __offset(8); return o != 0 ? bb.GetSbyte(o + bb_pos) : (sbyte)0; } }
  public TimeInterval Production { get { return GetProduction(new TimeInterval()); } }
  public TimeInterval GetProduction(TimeInterval obj) { int o = __offset(10); return o != 0 ? obj.__init(__indirect(o + bb_pos), bb) : null; }
  public Defence GetDefences(int j) { return GetDefences(new Defence(), j); }
  public Defence GetDefences(Defence obj, int j) { int o = __offset(12); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int DefencesLength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<Island> CreateIsland(FlatBufferBuilder builder,
      StringOffset name = default(StringOffset),
      StringOffset owner = default(StringOffset),
      sbyte level = 0,
      Offset<TimeInterval> production = default(Offset<TimeInterval>),
      VectorOffset defences = default(VectorOffset)) {
    builder.StartObject(5);
    Island.AddDefences(builder, defences);
    Island.AddProduction(builder, production);
    Island.AddOwner(builder, owner);
    Island.AddName(builder, name);
    Island.AddLevel(builder, level);
    return Island.EndIsland(builder);
  }

  public static void StartIsland(FlatBufferBuilder builder) { builder.StartObject(5); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddOwner(FlatBufferBuilder builder, StringOffset ownerOffset) { builder.AddOffset(1, ownerOffset.Value, 0); }
  public static void AddLevel(FlatBufferBuilder builder, sbyte level) { builder.AddSbyte(2, level, 0); }
  public static void AddProduction(FlatBufferBuilder builder, Offset<TimeInterval> productionOffset) { builder.AddOffset(3, productionOffset.Value, 0); }
  public static void AddDefences(FlatBufferBuilder builder, VectorOffset defencesOffset) { builder.AddOffset(4, defencesOffset.Value, 0); }
  public static VectorOffset CreateDefencesVector(FlatBufferBuilder builder, Offset<Defence>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartDefencesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Island> EndIsland(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Island>(o);
  }
};


}
