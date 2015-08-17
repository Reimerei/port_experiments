using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public ShipStatusComponent shipStatus { get { return (ShipStatusComponent)GetComponent(CoreGameComponentIds.ShipStatus); } }

        public bool hasShipStatus { get { return HasComponent(CoreGameComponentIds.ShipStatus); } }

        static readonly Stack<ShipStatusComponent> _shipStatusComponentPool = new Stack<ShipStatusComponent>();

        public static void ClearShipStatusComponentPool() {
            _shipStatusComponentPool.Clear();
        }

        public Entity AddShipStatus(float newValue) {
            var component = _shipStatusComponentPool.Count > 0 ? _shipStatusComponentPool.Pop() : new ShipStatusComponent();
            component.value = newValue;
            return AddComponent(CoreGameComponentIds.ShipStatus, component);
        }

        public Entity ReplaceShipStatus(float newValue) {
            var previousComponent = hasShipStatus ? shipStatus : null;
            var component = _shipStatusComponentPool.Count > 0 ? _shipStatusComponentPool.Pop() : new ShipStatusComponent();
            component.value = newValue;
            ReplaceComponent(CoreGameComponentIds.ShipStatus, component);
            if (previousComponent != null) {
                _shipStatusComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveShipStatus() {
            var component = shipStatus;
            RemoveComponent(CoreGameComponentIds.ShipStatus);
            _shipStatusComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherShipStatus;

        public static AllOfMatcher ShipStatus {
            get {
                if (_matcherShipStatus == null) {
                    _matcherShipStatus = new CoreGameMatcher(CoreGameComponentIds.ShipStatus);
                }

                return _matcherShipStatus;
            }
        }
    }
