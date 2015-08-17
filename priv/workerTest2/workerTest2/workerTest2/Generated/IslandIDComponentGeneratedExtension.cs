using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public IslandIDComponent islandID { get { return (IslandIDComponent)GetComponent(CoreGameComponentIds.IslandID); } }

        public bool hasIslandID { get { return HasComponent(CoreGameComponentIds.IslandID); } }

        static readonly Stack<IslandIDComponent> _islandIDComponentPool = new Stack<IslandIDComponent>();

        public static void ClearIslandIDComponentPool() {
            _islandIDComponentPool.Clear();
        }

        public Entity AddIslandID(string newValue) {
            var component = _islandIDComponentPool.Count > 0 ? _islandIDComponentPool.Pop() : new IslandIDComponent();
            component.value = newValue;
            return AddComponent(CoreGameComponentIds.IslandID, component);
        }

        public Entity ReplaceIslandID(string newValue) {
            var previousComponent = hasIslandID ? islandID : null;
            var component = _islandIDComponentPool.Count > 0 ? _islandIDComponentPool.Pop() : new IslandIDComponent();
            component.value = newValue;
            ReplaceComponent(CoreGameComponentIds.IslandID, component);
            if (previousComponent != null) {
                _islandIDComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveIslandID() {
            var component = islandID;
            RemoveComponent(CoreGameComponentIds.IslandID);
            _islandIDComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherIslandID;

        public static AllOfMatcher IslandID {
            get {
                if (_matcherIslandID == null) {
                    _matcherIslandID = new CoreGameMatcher(CoreGameComponentIds.IslandID);
                }

                return _matcherIslandID;
            }
        }
    }
