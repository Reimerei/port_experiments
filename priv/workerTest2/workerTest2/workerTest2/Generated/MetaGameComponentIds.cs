using Entitas;

public static class MetaGameComponentIds {
    public const int AssignedWorkers = 0;
    public const int Attacked = 1;
    public const int BattleReportsAttack = 2;
    public const int BattleReportsDefence = 3;
    public const int EndTime = 4;
    public const int HighscorePlayers = 5;
    public const int InitialGameState = 6;
    public const int IslandNextPirateAttack = 7;
    public const int IslandSectors = 8;
    public const int LastPvpAttackTime = 9;
    public const int LeftOverResources = 10;
    public const int Loading = 11;
    public const int Locked = 12;
    public const int MerchantVisit = 13;
    public const int PlayerResources = 14;
    public const int Priority = 15;
    public const int Quest = 16;
    public const int QuestDone = 17;
    public const int QuestsCompleted = 18;
    public const int QuestTaskAmount = 19;
    public const int QuestTask = 20;
    public const int RaidPlayer = 21;
    public const int RaidPlayerInfo = 22;
    public const int ResourceTransaction = 23;
    public const int Scouting = 24;
    public const int Technologies = 25;
    public const int Trophies = 26;
    public const int Tutorial = 27;
    public const int UnitLevels = 28;
    public const int WorkersProduction = 29;

    public const int TotalComponents = 30;

    static readonly string[] components = {
        "AssignedWorkers",
        "Attacked",
        "BattleReportsAttack",
        "BattleReportsDefence",
        "EndTime",
        "HighscorePlayers",
        "InitialGameState",
        "IslandLastPirateAttack",
        "IslandSectors",
        "LastPvpAttackTime",
        "LeftOverResources",
        "Loading",
        "Locked",
        "MerchantVisit",
        "PlayerResources",
        "Priority",
        "Quest",
        "QuestDone",
        "QuestsCompleted",
        "QuestTaskAmount",
        "QuestTask",
        "RaidPlayer",
        "RaidPlayerInfo",
        "ResourceTransaction",
        "Scouting",
        "Technologies",
        "Trophies",
        "Tutorial",
        "UnitLevels",
        "WorkersProduction"
    };

    public static string IdToString(int componentId) {
        return components[componentId];
    }
}

public partial class MetaGameMatcher : AllOfMatcher {
    public MetaGameMatcher(int index) : base(new [] { index }) {
    }

    public override string ToString() {
        return MetaGameComponentIds.IdToString(indices[0]);
    }
}