using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public ShipCargoComponent shipCargo { get { return (ShipCargoComponent)GetComponent(CoreGameComponentIds.ShipCargo); } }

        public bool hasShipCargo { get { return HasComponent(CoreGameComponentIds.ShipCargo); } }

        static readonly Stack<ShipCargoComponent> _shipCargoComponentPool = new Stack<ShipCargoComponent>();

        public static void ClearShipCargoComponentPool() {
            _shipCargoComponentPool.Clear();
        }

        public Entity AddShipCargo(System.Collections.Generic.Dictionary<string, int> newItems) {
            var component = _shipCargoComponentPool.Count > 0 ? _shipCargoComponentPool.Pop() : new ShipCargoComponent();
            component.items = newItems;
            return AddComponent(CoreGameComponentIds.ShipCargo, component);
        }

        public Entity ReplaceShipCargo(System.Collections.Generic.Dictionary<string, int> newItems) {
            var previousComponent = hasShipCargo ? shipCargo : null;
            var component = _shipCargoComponentPool.Count > 0 ? _shipCargoComponentPool.Pop() : new ShipCargoComponent();
            component.items = newItems;
            ReplaceComponent(CoreGameComponentIds.ShipCargo, component);
            if (previousComponent != null) {
                _shipCargoComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveShipCargo() {
            var component = shipCargo;
            RemoveComponent(CoreGameComponentIds.ShipCargo);
            _shipCargoComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherShipCargo;

        public static AllOfMatcher ShipCargo {
            get {
                if (_matcherShipCargo == null) {
                    _matcherShipCargo = new CoreGameMatcher(CoreGameComponentIds.ShipCargo);
                }

                return _matcherShipCargo;
            }
        }
    }
