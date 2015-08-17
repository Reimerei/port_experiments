using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public PositionComponent position { get { return (PositionComponent)GetComponent(CoreGameComponentIds.Position); } }

        public bool hasPosition { get { return HasComponent(CoreGameComponentIds.Position); } }

        static readonly Stack<PositionComponent> _positionComponentPool = new Stack<PositionComponent>();

        public static void ClearPositionComponentPool() {
            _positionComponentPool.Clear();
        }

        public Entity AddPosition(int newX, int newY) {
            var component = _positionComponentPool.Count > 0 ? _positionComponentPool.Pop() : new PositionComponent();
            component.x = newX;
            component.y = newY;
            return AddComponent(CoreGameComponentIds.Position, component);
        }

        public Entity ReplacePosition(int newX, int newY) {
            var previousComponent = hasPosition ? position : null;
            var component = _positionComponentPool.Count > 0 ? _positionComponentPool.Pop() : new PositionComponent();
            component.x = newX;
            component.y = newY;
            ReplaceComponent(CoreGameComponentIds.Position, component);
            if (previousComponent != null) {
                _positionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemovePosition() {
            var component = position;
            RemoveComponent(CoreGameComponentIds.Position);
            _positionComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherPosition;

        public static AllOfMatcher Position {
            get {
                if (_matcherPosition == null) {
                    _matcherPosition = new CoreGameMatcher(CoreGameComponentIds.Position);
                }

                return _matcherPosition;
            }
        }
    }
