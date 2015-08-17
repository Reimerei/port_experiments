using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public ProductionComponent production { get { return (ProductionComponent)GetComponent(CoreGameComponentIds.Production); } }

        public bool hasProduction { get { return HasComponent(CoreGameComponentIds.Production); } }

        static readonly Stack<ProductionComponent> _productionComponentPool = new Stack<ProductionComponent>();

        public static void ClearProductionComponentPool() {
            _productionComponentPool.Clear();
        }

        public Entity AddProduction(System.DateTime newStartTime, System.DateTime newEndTime) {
            var component = _productionComponentPool.Count > 0 ? _productionComponentPool.Pop() : new ProductionComponent();
            component.startTime = newStartTime;
            component.endTime = newEndTime;
            return AddComponent(CoreGameComponentIds.Production, component);
        }

        public Entity ReplaceProduction(System.DateTime newStartTime, System.DateTime newEndTime) {
            var previousComponent = hasProduction ? production : null;
            var component = _productionComponentPool.Count > 0 ? _productionComponentPool.Pop() : new ProductionComponent();
            component.startTime = newStartTime;
            component.endTime = newEndTime;
            ReplaceComponent(CoreGameComponentIds.Production, component);
            if (previousComponent != null) {
                _productionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveProduction() {
            var component = production;
            RemoveComponent(CoreGameComponentIds.Production);
            _productionComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherProduction;

        public static AllOfMatcher Production {
            get {
                if (_matcherProduction == null) {
                    _matcherProduction = new CoreGameMatcher(CoreGameComponentIds.Production);
                }

                return _matcherProduction;
            }
        }
    }
