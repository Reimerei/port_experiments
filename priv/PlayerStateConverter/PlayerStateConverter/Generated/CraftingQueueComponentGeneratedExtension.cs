using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public CraftingQueueComponent craftingQueue { get { return (CraftingQueueComponent)GetComponent(CoreGameComponentIds.CraftingQueue); } }

        public bool hasCraftingQueue { get { return HasComponent(CoreGameComponentIds.CraftingQueue); } }

        static readonly Stack<CraftingQueueComponent> _craftingQueueComponentPool = new Stack<CraftingQueueComponent>();

        public static void ClearCraftingQueueComponentPool() {
            _craftingQueueComponentPool.Clear();
        }

        public Entity AddCraftingQueue(Nito.Deque<Tuple<string, int>> newDeque) {
            var component = _craftingQueueComponentPool.Count > 0 ? _craftingQueueComponentPool.Pop() : new CraftingQueueComponent();
            component.deque = newDeque;
            return AddComponent(CoreGameComponentIds.CraftingQueue, component);
        }

        public Entity ReplaceCraftingQueue(Nito.Deque<Tuple<string, int>> newDeque) {
            var previousComponent = hasCraftingQueue ? craftingQueue : null;
            var component = _craftingQueueComponentPool.Count > 0 ? _craftingQueueComponentPool.Pop() : new CraftingQueueComponent();
            component.deque = newDeque;
            ReplaceComponent(CoreGameComponentIds.CraftingQueue, component);
            if (previousComponent != null) {
                _craftingQueueComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveCraftingQueue() {
            var component = craftingQueue;
            RemoveComponent(CoreGameComponentIds.CraftingQueue);
            _craftingQueueComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherCraftingQueue;

        public static AllOfMatcher CraftingQueue {
            get {
                if (_matcherCraftingQueue == null) {
                    _matcherCraftingQueue = new CoreGameMatcher(CoreGameComponentIds.CraftingQueue);
                }

                return _matcherCraftingQueue;
            }
        }
    }
