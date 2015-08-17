// automatically generated, do not modify

namespace DogeFB
{

using FlatBuffers;

public sealed class CityDefences : Table {
  public static CityDefences GetRootAsCityDefences(ByteBuffer _bb) { return GetRootAsCityDefences(_bb, new CityDefences()); }
  public static CityDefences GetRootAsCityDefences(ByteBuffer _bb, CityDefences obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public CityDefences __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Type { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public sbyte Level { get { int o = __offset(6); return o != 0 ? bb.GetSbyte(o + bb_pos) : (sbyte)0; } }
  public bool Upgrading { get { int o = __offset(8); return o != 0 ? 0!=bb.Get(o + bb_pos) : (bool)false; } }
  public TimeInterval UpgradingTime { get { return GetUpgradingTime(new TimeInterval()); } }
  public TimeInterval GetUpgradingTime(TimeInterval obj) { int o = __offset(10); return o != 0 ? obj.__init(__indirect(o + bb_pos), bb) : null; }

  public static Offset<CityDefences> CreateCityDefences(FlatBufferBuilder builder,
      StringOffset type = default(StringOffset),
      sbyte level = 0,
      bool upgrading = false,
      Offset<TimeInterval> upgradingTime = default(Offset<TimeInterval>)) {
    builder.StartObject(4);
    CityDefences.AddUpgradingTime(builder, upgradingTime);
    CityDefences.AddType(builder, type);
    CityDefences.AddUpgrading(builder, upgrading);
    CityDefences.AddLevel(builder, level);
    return CityDefences.EndCityDefences(builder);
  }

  public static void StartCityDefences(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddType(FlatBufferBuilder builder, StringOffset typeOffset) { builder.AddOffset(0, typeOffset.Value, 0); }
  public static void AddLevel(FlatBufferBuilder builder, sbyte level) { builder.AddSbyte(1, level, 0); }
  public static void AddUpgrading(FlatBufferBuilder builder, bool upgrading) { builder.AddBool(2, upgrading, false); }
  public static void AddUpgradingTime(FlatBufferBuilder builder, Offset<TimeInterval> upgradingTimeOffset) { builder.AddOffset(3, upgradingTimeOffset.Value, 0); }
  public static Offset<CityDefences> EndCityDefences(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<CityDefences>(o);
  }
};


}
