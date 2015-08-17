using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public IslandDefenceComponent islandDefence { get { return (IslandDefenceComponent)GetComponent(CoreGameComponentIds.IslandDefence); } }

        public bool hasIslandDefence { get { return HasComponent(CoreGameComponentIds.IslandDefence); } }

        static readonly Stack<IslandDefenceComponent> _islandDefenceComponentPool = new Stack<IslandDefenceComponent>();

        public static void ClearIslandDefenceComponentPool() {
            _islandDefenceComponentPool.Clear();
        }

        public Entity AddIslandDefence(System.Collections.Generic.List<IslandDefence> newDefences) {
            var component = _islandDefenceComponentPool.Count > 0 ? _islandDefenceComponentPool.Pop() : new IslandDefenceComponent();
            component.defences = newDefences;
            return AddComponent(CoreGameComponentIds.IslandDefence, component);
        }

        public Entity ReplaceIslandDefence(System.Collections.Generic.List<IslandDefence> newDefences) {
            var previousComponent = hasIslandDefence ? islandDefence : null;
            var component = _islandDefenceComponentPool.Count > 0 ? _islandDefenceComponentPool.Pop() : new IslandDefenceComponent();
            component.defences = newDefences;
            ReplaceComponent(CoreGameComponentIds.IslandDefence, component);
            if (previousComponent != null) {
                _islandDefenceComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveIslandDefence() {
            var component = islandDefence;
            RemoveComponent(CoreGameComponentIds.IslandDefence);
            _islandDefenceComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherIslandDefence;

        public static AllOfMatcher IslandDefence {
            get {
                if (_matcherIslandDefence == null) {
                    _matcherIslandDefence = new CoreGameMatcher(CoreGameComponentIds.IslandDefence);
                }

                return _matcherIslandDefence;
            }
        }
    }
