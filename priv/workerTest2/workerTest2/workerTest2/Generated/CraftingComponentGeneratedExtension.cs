using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public CraftingComponent crafting { get { return (CraftingComponent)GetComponent(CoreGameComponentIds.Crafting); } }

        public bool hasCrafting { get { return HasComponent(CoreGameComponentIds.Crafting); } }

        static readonly Stack<CraftingComponent> _craftingComponentPool = new Stack<CraftingComponent>();

        public static void ClearCraftingComponentPool() {
            _craftingComponentPool.Clear();
        }

        public Entity AddCrafting(string newItem, System.DateTime newStartTime) {
            var component = _craftingComponentPool.Count > 0 ? _craftingComponentPool.Pop() : new CraftingComponent();
            component.item = newItem;
            component.startTime = newStartTime;
            return AddComponent(CoreGameComponentIds.Crafting, component);
        }

        public Entity ReplaceCrafting(string newItem, System.DateTime newStartTime) {
            var previousComponent = hasCrafting ? crafting : null;
            var component = _craftingComponentPool.Count > 0 ? _craftingComponentPool.Pop() : new CraftingComponent();
            component.item = newItem;
            component.startTime = newStartTime;
            ReplaceComponent(CoreGameComponentIds.Crafting, component);
            if (previousComponent != null) {
                _craftingComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveCrafting() {
            var component = crafting;
            RemoveComponent(CoreGameComponentIds.Crafting);
            _craftingComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherCrafting;

        public static AllOfMatcher Crafting {
            get {
                if (_matcherCrafting == null) {
                    _matcherCrafting = new CoreGameMatcher(CoreGameComponentIds.Crafting);
                }

                return _matcherCrafting;
            }
        }
    }
