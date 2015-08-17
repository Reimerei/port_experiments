using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly CrafterComponent crafterComponent = new CrafterComponent();

        public bool isCrafter {
            get { return HasComponent(CoreGameComponentIds.Crafter); }
            set {
                if (value != isCrafter) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Crafter, crafterComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Crafter);
                    }
                }
            }
        }

        public Entity IsCrafter(bool value) {
            isCrafter = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherCrafter;

        public static AllOfMatcher Crafter {
            get {
                if (_matcherCrafter == null) {
                    _matcherCrafter = new CoreGameMatcher(CoreGameComponentIds.Crafter);
                }

                return _matcherCrafter;
            }
        }
    }
