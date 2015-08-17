using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public IslandOwnerComponent islandOwner { get { return (IslandOwnerComponent)GetComponent(CoreGameComponentIds.IslandOwner); } }

        public bool hasIslandOwner { get { return HasComponent(CoreGameComponentIds.IslandOwner); } }

        static readonly Stack<IslandOwnerComponent> _islandOwnerComponentPool = new Stack<IslandOwnerComponent>();

        public static void ClearIslandOwnerComponentPool() {
            _islandOwnerComponentPool.Clear();
        }

        public Entity AddIslandOwner(string newValue) {
            var component = _islandOwnerComponentPool.Count > 0 ? _islandOwnerComponentPool.Pop() : new IslandOwnerComponent();
            component.value = newValue;
            return AddComponent(CoreGameComponentIds.IslandOwner, component);
        }

        public Entity ReplaceIslandOwner(string newValue) {
            var previousComponent = hasIslandOwner ? islandOwner : null;
            var component = _islandOwnerComponentPool.Count > 0 ? _islandOwnerComponentPool.Pop() : new IslandOwnerComponent();
            component.value = newValue;
            ReplaceComponent(CoreGameComponentIds.IslandOwner, component);
            if (previousComponent != null) {
                _islandOwnerComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveIslandOwner() {
            var component = islandOwner;
            RemoveComponent(CoreGameComponentIds.IslandOwner);
            _islandOwnerComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherIslandOwner;

        public static AllOfMatcher IslandOwner {
            get {
                if (_matcherIslandOwner == null) {
                    _matcherIslandOwner = new CoreGameMatcher(CoreGameComponentIds.IslandOwner);
                }

                return _matcherIslandOwner;
            }
        }
    }
