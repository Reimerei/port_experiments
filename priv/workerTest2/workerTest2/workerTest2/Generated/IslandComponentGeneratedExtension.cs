using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly IslandComponent islandComponent = new IslandComponent();

        public bool isIsland {
            get { return HasComponent(CoreGameComponentIds.Island); }
            set {
                if (value != isIsland) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Island, islandComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Island);
                    }
                }
            }
        }

        public Entity IsIsland(bool value) {
            isIsland = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherIsland;

        public static AllOfMatcher Island {
            get {
                if (_matcherIsland == null) {
                    _matcherIsland = new CoreGameMatcher(CoreGameComponentIds.Island);
                }

                return _matcherIsland;
            }
        }
    }
