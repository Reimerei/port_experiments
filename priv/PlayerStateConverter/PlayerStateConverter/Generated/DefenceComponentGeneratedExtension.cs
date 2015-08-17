using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly DefenceComponent defenceComponent = new DefenceComponent();

        public bool isDefence {
            get { return HasComponent(CoreGameComponentIds.Defence); }
            set {
                if (value != isDefence) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Defence, defenceComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Defence);
                    }
                }
            }
        }

        public Entity IsDefence(bool value) {
            isDefence = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherDefence;

        public static AllOfMatcher Defence {
            get {
                if (_matcherDefence == null) {
                    _matcherDefence = new CoreGameMatcher(CoreGameComponentIds.Defence);
                }

                return _matcherDefence;
            }
        }
    }
