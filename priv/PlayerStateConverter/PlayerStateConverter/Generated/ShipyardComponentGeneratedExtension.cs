using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly ShipyardComponent shipyardComponent = new ShipyardComponent();

        public bool isShipyard {
            get { return HasComponent(CoreGameComponentIds.Shipyard); }
            set {
                if (value != isShipyard) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Shipyard, shipyardComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Shipyard);
                    }
                }
            }
        }

        public Entity IsShipyard(bool value) {
            isShipyard = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity shipyardEntity { get { return GetGroup(CoreGameMatcher.Shipyard).GetSingleEntity(); } }

        public bool isShipyard {
            get { return shipyardEntity != null; }
            set {
                var entity = shipyardEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isShipyard = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherShipyard;

        public static AllOfMatcher Shipyard {
            get {
                if (_matcherShipyard == null) {
                    _matcherShipyard = new CoreGameMatcher(CoreGameComponentIds.Shipyard);
                }

                return _matcherShipyard;
            }
        }
    }
