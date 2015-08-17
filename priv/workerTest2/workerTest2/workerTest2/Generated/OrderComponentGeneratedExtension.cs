using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public OrderComponent order { get { return (OrderComponent)GetComponent(CoreGameComponentIds.Order); } }

        public bool hasOrder { get { return HasComponent(CoreGameComponentIds.Order); } }

        static readonly Stack<OrderComponent> _orderComponentPool = new Stack<OrderComponent>();

        public static void ClearOrderComponentPool() {
            _orderComponentPool.Clear();
        }

        public Entity AddOrder(int newValue) {
            var component = _orderComponentPool.Count > 0 ? _orderComponentPool.Pop() : new OrderComponent();
            component.value = newValue;
            return AddComponent(CoreGameComponentIds.Order, component);
        }

        public Entity ReplaceOrder(int newValue) {
            var previousComponent = hasOrder ? order : null;
            var component = _orderComponentPool.Count > 0 ? _orderComponentPool.Pop() : new OrderComponent();
            component.value = newValue;
            ReplaceComponent(CoreGameComponentIds.Order, component);
            if (previousComponent != null) {
                _orderComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveOrder() {
            var component = order;
            RemoveComponent(CoreGameComponentIds.Order);
            _orderComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherOrder;

        public static AllOfMatcher Order {
            get {
                if (_matcherOrder == null) {
                    _matcherOrder = new CoreGameMatcher(CoreGameComponentIds.Order);
                }

                return _matcherOrder;
            }
        }
    }
