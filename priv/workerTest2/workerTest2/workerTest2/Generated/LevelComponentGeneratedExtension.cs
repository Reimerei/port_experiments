using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public LevelComponent level { get { return (LevelComponent)GetComponent(CoreGameComponentIds.Level); } }

        public bool hasLevel { get { return HasComponent(CoreGameComponentIds.Level); } }

        static readonly Stack<LevelComponent> _levelComponentPool = new Stack<LevelComponent>();

        public static void ClearLevelComponentPool() {
            _levelComponentPool.Clear();
        }

        public Entity AddLevel(int newValue) {
            var component = _levelComponentPool.Count > 0 ? _levelComponentPool.Pop() : new LevelComponent();
            component.value = newValue;
            return AddComponent(CoreGameComponentIds.Level, component);
        }

        public Entity ReplaceLevel(int newValue) {
            var previousComponent = hasLevel ? level : null;
            var component = _levelComponentPool.Count > 0 ? _levelComponentPool.Pop() : new LevelComponent();
            component.value = newValue;
            ReplaceComponent(CoreGameComponentIds.Level, component);
            if (previousComponent != null) {
                _levelComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveLevel() {
            var component = level;
            RemoveComponent(CoreGameComponentIds.Level);
            _levelComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherLevel;

        public static AllOfMatcher Level {
            get {
                if (_matcherLevel == null) {
                    _matcherLevel = new CoreGameMatcher(CoreGameComponentIds.Level);
                }

                return _matcherLevel;
            }
        }
    }
