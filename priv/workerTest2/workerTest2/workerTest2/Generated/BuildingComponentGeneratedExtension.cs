using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly BuildingComponent buildingComponent = new BuildingComponent();

        public bool isBuilding {
            get { return HasComponent(CoreGameComponentIds.Building); }
            set {
                if (value != isBuilding) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Building, buildingComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Building);
                    }
                }
            }
        }

        public Entity IsBuilding(bool value) {
            isBuilding = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherBuilding;

        public static AllOfMatcher Building {
            get {
                if (_matcherBuilding == null) {
                    _matcherBuilding = new CoreGameMatcher(CoreGameComponentIds.Building);
                }

                return _matcherBuilding;
            }
        }
    }
