using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly DefenceUpgradingComponent defenceUpgradingComponent = new DefenceUpgradingComponent();

        public bool isDefenceUpgrading {
            get { return HasComponent(CoreGameComponentIds.DefenceUpgrading); }
            set {
                if (value != isDefenceUpgrading) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.DefenceUpgrading, defenceUpgradingComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.DefenceUpgrading);
                    }
                }
            }
        }

        public Entity IsDefenceUpgrading(bool value) {
            isDefenceUpgrading = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherDefenceUpgrading;

        public static AllOfMatcher DefenceUpgrading {
            get {
                if (_matcherDefenceUpgrading == null) {
                    _matcherDefenceUpgrading = new CoreGameMatcher(CoreGameComponentIds.DefenceUpgrading);
                }

                return _matcherDefenceUpgrading;
            }
        }
    }
