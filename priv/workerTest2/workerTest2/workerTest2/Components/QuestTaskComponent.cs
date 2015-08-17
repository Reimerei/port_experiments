using Entitas;

public enum QuestAction
{
	ShopOpen,
	OverlayShow,
	BuildingHave,
	BuildingHaveCategory,
	BuildingHaveHighestLevelCategory,
	BuildingUpgradeStart,
	BuildingBoost,
	Select,
	GameViewShow,
	ShipHave,
	ShipUpgradeStart,
	ShipRepairFinish,
	SectorUnlockFinish,
	SectorUnlockTotal,
	HUDElementShow,
	IslandHave,
	TechnologyHave,
	CapacityReach,
	ResourceCraft,
	ResourceTradeSell,
	ResourceTradeBuy,
	ResourceTradeEarn,
	ResourceProduce,
	ResourceProducePerHour,
	ResourceHave,
	ResourceGet,
	DefenceHave,
	DefenceHaveTotal,
	MerchantDealPartial,
	MerchantDealWhole,
	SpeedUpConstruction,
	SpeedUpUpgrade,
	SpeedUpRepair,
	SpeedUpShipAction,
	SpeedUpResearch,
	SpeedUpCrafting,
	TrophiesHave,
	PvpAttack,
	PvpDefend,
	PvpLoot
}

[MetaGameAttribute]
public class QuestTaskComponent : IComponent
{
	public QuestAction action;
	public string type, info;
	public string description, hint;
}