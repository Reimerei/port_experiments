using Entitas;

public static class CoreGameComponentIds {
    public const int Academy = 0;
    public const int AccessingWater = 1;
    public const int ActionBadge = 2;
    public const int Arsenal = 3;
    public const int BoostBadge = 4;
    public const int Boost = 5;
    public const int BoostDisplay = 6;
    public const int BoostingBadge = 7;
    public const int Building = 8;
    public const int BuildingStorage = 9;
    public const int CanalMap = 10;
    public const int Colliding = 11;
    public const int Color = 12;
    public const int Construction = 13;
    public const int ConstructionFinished = 14;
    public const int Crafter = 15;
    public const int Crafting = 16;
    public const int CraftingQueue = 17;
    public const int Defence = 18;
    public const int DefenceUpgrading = 19;
    public const int DescriptionBadge = 20;
    public const int Docks = 21;
    public const int Dragged = 22;
    public const int DragGesture = 23;
    public const int ExecuteAfterFrame = 24;
    public const int FlyIn = 25;
    public const int Fortress = 26;
    public const int GameObject = 27;
    public const int Housing = 28;
    public const int IslandBeingAttacked = 29;
    public const int Island = 30;
    public const int IslandDefence = 31;
    public const int IslandID = 32;
    public const int IslandOwner = 33;
    public const int IslandSectorBeingDiscovered = 34;
    public const int IslandSector = 35;
    public const int IslandSectorID = 36;
    public const int LevelBadge = 37;
    public const int Level = 38;
    public const int LongPressGesture = 39;
    public const int MerchantOffer = 40;
    public const int MerchantShip = 41;
    public const int NameBadge = 42;
    public const int NavigationMesh = 43;
    public const int Order = 44;
    public const int PinchGesture = 45;
    public const int PopupBadge = 46;
    public const int Position = 47;
    public const int Production = 48;
    public const int ProductionPaused = 49;
    public const int ProgressBar = 50;
    public const int Refinery = 51;
    public const int RefineryFlowBadge = 52;
    public const int RefineryProperties = 53;
    public const int Repairing = 54;
    public const int Research = 55;
    public const int ResearchFinished = 56;
    public const int Selected = 57;
    public const int ShipAction = 58;
    public const int ShipArmyCargo = 59;
    public const int ShipCargo = 60;
    public const int Ship = 61;
    public const int ShipRaid = 62;
    public const int ShipReadyForTravel = 63;
    public const int ShipSelectedForAction = 64;
    public const int ShipStatus = 65;
    public const int ShipTrade = 66;
    public const int Shipyard = 67;
    public const int Size = 68;
    public const int StartEndTime = 69;
    public const int StorageBadge = 70;
    public const int Storage = 71;
    public const int TapGesture = 72;
    public const int Tapped = 73;
    public const int Townhall = 74;
    public const int Type = 75;
    public const int Unconfirmed = 76;
    public const int Upgrading = 77;
    public const int Vault = 78;
    public const int WorldPosition = 79;

    public const int TotalComponents = 80;

    static readonly string[] components = {
        "Academy",
        "AccessingWater",
        "ActionBadge",
        "Arsenal",
        "BoostBadge",
        "Boost",
        "BoostDisplay",
        "BoostingBadge",
        "Building",
        "BuildingStorage",
        "CanalMap",
        "Colliding",
        "Color",
        "Construction",
        "ConstructionFinished",
        "Crafter",
        "Crafting",
        "CraftingQueue",
        "Defence",
        "DefenceUpgrading",
        "DescriptionBadge",
        "Docks",
        "Dragged",
        "DragGesture",
        "ExecuteAfterFrame",
        "FlyIn",
        "Fortress",
        "GameObject",
        "Housing",
        "IslandBeingAttacked",
        "Island",
        "IslandDefence",
        "IslandID",
        "IslandOwner",
        "IslandSectorBeingDiscovered",
        "IslandSector",
        "IslandSectorID",
        "LevelBadge",
        "Level",
        "LongPressGesture",
        "MerchantOffer",
        "MerchantShip",
        "NameBadge",
        "NavigationMesh",
        "Order",
        "PinchGesture",
        "PopupBadge",
        "Position",
        "Production",
        "ProductionPaused",
        "ProgressBar",
        "Refinery",
        "RefineryFlowBadge",
        "RefineryProperties",
        "Repairing",
        "Research",
        "ResearchFinished",
        "Selected",
        "ShipAction",
        "ShipArmyCargo",
        "ShipCargo",
        "Ship",
        "ShipRaid",
        "ShipReadyForTravel",
        "ShipSelectedForAction",
        "ShipStatus",
        "ShipTrade",
        "Shipyard",
        "Size",
        "StartEndTime",
        "StorageBadge",
        "Storage",
        "TapGesture",
        "Tapped",
        "Townhall",
        "Type",
        "Unconfirmed",
        "Upgrading",
        "Vault",
        "WorldPosition"
    };

    public static string IdToString(int componentId) {
        return components[componentId];
    }
}

public partial class CoreGameMatcher : AllOfMatcher {
    public CoreGameMatcher(int index) : base(new [] { index }) {
    }

    public override string ToString() {
        return CoreGameComponentIds.IdToString(indices[0]);
    }
}