using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly RefineryComponent refineryComponent = new RefineryComponent();

        public bool isRefinery {
            get { return HasComponent(CoreGameComponentIds.Refinery); }
            set {
                if (value != isRefinery) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Refinery, refineryComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Refinery);
                    }
                }
            }
        }

        public Entity IsRefinery(bool value) {
            isRefinery = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherRefinery;

        public static AllOfMatcher Refinery {
            get {
                if (_matcherRefinery == null) {
                    _matcherRefinery = new CoreGameMatcher(CoreGameComponentIds.Refinery);
                }

                return _matcherRefinery;
            }
        }
    }
