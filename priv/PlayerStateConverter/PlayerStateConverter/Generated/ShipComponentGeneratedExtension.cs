using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly ShipComponent shipComponent = new ShipComponent();

        public bool isShip {
            get { return HasComponent(CoreGameComponentIds.Ship); }
            set {
                if (value != isShip) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Ship, shipComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Ship);
                    }
                }
            }
        }

        public Entity IsShip(bool value) {
            isShip = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherShip;

        public static AllOfMatcher Ship {
            get {
                if (_matcherShip == null) {
                    _matcherShip = new CoreGameMatcher(CoreGameComponentIds.Ship);
                }

                return _matcherShip;
            }
        }
    }
