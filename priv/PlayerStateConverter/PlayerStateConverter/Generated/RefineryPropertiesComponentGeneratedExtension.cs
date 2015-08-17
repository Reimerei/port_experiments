using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public RefineryPropertiesComponent refineryProperties { get { return (RefineryPropertiesComponent)GetComponent(CoreGameComponentIds.RefineryProperties); } }

        public bool hasRefineryProperties { get { return HasComponent(CoreGameComponentIds.RefineryProperties); } }

        static readonly Stack<RefineryPropertiesComponent> _refineryPropertiesComponentPool = new Stack<RefineryPropertiesComponent>();

        public static void ClearRefineryPropertiesComponentPool() {
            _refineryPropertiesComponentPool.Clear();
        }

        public Entity AddRefineryProperties(int newPriority, int newCapacity, int newProductionTime, System.Collections.Generic.Dictionary<string, int> newSupplyAmounts, System.Collections.Generic.Dictionary<string, int> newProductionAmounts) {
            var component = _refineryPropertiesComponentPool.Count > 0 ? _refineryPropertiesComponentPool.Pop() : new RefineryPropertiesComponent();
            component.priority = newPriority;
            component.capacity = newCapacity;
            component.productionTime = newProductionTime;
            component.supplyAmounts = newSupplyAmounts;
            component.productionAmounts = newProductionAmounts;
            return AddComponent(CoreGameComponentIds.RefineryProperties, component);
        }

        public Entity ReplaceRefineryProperties(int newPriority, int newCapacity, int newProductionTime, System.Collections.Generic.Dictionary<string, int> newSupplyAmounts, System.Collections.Generic.Dictionary<string, int> newProductionAmounts) {
            var previousComponent = hasRefineryProperties ? refineryProperties : null;
            var component = _refineryPropertiesComponentPool.Count > 0 ? _refineryPropertiesComponentPool.Pop() : new RefineryPropertiesComponent();
            component.priority = newPriority;
            component.capacity = newCapacity;
            component.productionTime = newProductionTime;
            component.supplyAmounts = newSupplyAmounts;
            component.productionAmounts = newProductionAmounts;
            ReplaceComponent(CoreGameComponentIds.RefineryProperties, component);
            if (previousComponent != null) {
                _refineryPropertiesComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveRefineryProperties() {
            var component = refineryProperties;
            RemoveComponent(CoreGameComponentIds.RefineryProperties);
            _refineryPropertiesComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherRefineryProperties;

        public static AllOfMatcher RefineryProperties {
            get {
                if (_matcherRefineryProperties == null) {
                    _matcherRefineryProperties = new CoreGameMatcher(CoreGameComponentIds.RefineryProperties);
                }

                return _matcherRefineryProperties;
            }
        }
    }
