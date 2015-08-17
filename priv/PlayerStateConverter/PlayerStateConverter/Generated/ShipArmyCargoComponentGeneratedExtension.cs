using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public ShipArmyCargoComponent shipArmyCargo { get { return (ShipArmyCargoComponent)GetComponent(CoreGameComponentIds.ShipArmyCargo); } }

        public bool hasShipArmyCargo { get { return HasComponent(CoreGameComponentIds.ShipArmyCargo); } }

        static readonly Stack<ShipArmyCargoComponent> _shipArmyCargoComponentPool = new Stack<ShipArmyCargoComponent>();

        public static void ClearShipArmyCargoComponentPool() {
            _shipArmyCargoComponentPool.Clear();
        }

        public Entity AddShipArmyCargo(System.Collections.Generic.Dictionary<string, int> newTroops) {
            var component = _shipArmyCargoComponentPool.Count > 0 ? _shipArmyCargoComponentPool.Pop() : new ShipArmyCargoComponent();
            component.troops = newTroops;
            return AddComponent(CoreGameComponentIds.ShipArmyCargo, component);
        }

        public Entity ReplaceShipArmyCargo(System.Collections.Generic.Dictionary<string, int> newTroops) {
            var previousComponent = hasShipArmyCargo ? shipArmyCargo : null;
            var component = _shipArmyCargoComponentPool.Count > 0 ? _shipArmyCargoComponentPool.Pop() : new ShipArmyCargoComponent();
            component.troops = newTroops;
            ReplaceComponent(CoreGameComponentIds.ShipArmyCargo, component);
            if (previousComponent != null) {
                _shipArmyCargoComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveShipArmyCargo() {
            var component = shipArmyCargo;
            RemoveComponent(CoreGameComponentIds.ShipArmyCargo);
            _shipArmyCargoComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherShipArmyCargo;

        public static AllOfMatcher ShipArmyCargo {
            get {
                if (_matcherShipArmyCargo == null) {
                    _matcherShipArmyCargo = new CoreGameMatcher(CoreGameComponentIds.ShipArmyCargo);
                }

                return _matcherShipArmyCargo;
            }
        }
    }
