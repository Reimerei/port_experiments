using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly RepairingComponent repairingComponent = new RepairingComponent();

        public bool isRepairing {
            get { return HasComponent(CoreGameComponentIds.Repairing); }
            set {
                if (value != isRepairing) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Repairing, repairingComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Repairing);
                    }
                }
            }
        }

        public Entity IsRepairing(bool value) {
            isRepairing = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherRepairing;

        public static AllOfMatcher Repairing {
            get {
                if (_matcherRepairing == null) {
                    _matcherRepairing = new CoreGameMatcher(CoreGameComponentIds.Repairing);
                }

                return _matcherRepairing;
            }
        }
    }
