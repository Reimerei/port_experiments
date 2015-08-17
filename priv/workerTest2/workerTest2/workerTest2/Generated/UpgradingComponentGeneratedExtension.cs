using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly UpgradingComponent upgradingComponent = new UpgradingComponent();

        public bool isUpgrading {
            get { return HasComponent(CoreGameComponentIds.Upgrading); }
            set {
                if (value != isUpgrading) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Upgrading, upgradingComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Upgrading);
                    }
                }
            }
        }

        public Entity IsUpgrading(bool value) {
            isUpgrading = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherUpgrading;

        public static AllOfMatcher Upgrading {
            get {
                if (_matcherUpgrading == null) {
                    _matcherUpgrading = new CoreGameMatcher(CoreGameComponentIds.Upgrading);
                }

                return _matcherUpgrading;
            }
        }
    }
