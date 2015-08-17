using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public SizeComponent size { get { return (SizeComponent)GetComponent(CoreGameComponentIds.Size); } }

        public bool hasSize { get { return HasComponent(CoreGameComponentIds.Size); } }

        static readonly Stack<SizeComponent> _sizeComponentPool = new Stack<SizeComponent>();

        public static void ClearSizeComponentPool() {
            _sizeComponentPool.Clear();
        }

        public Entity AddSize(int newValue) {
            var component = _sizeComponentPool.Count > 0 ? _sizeComponentPool.Pop() : new SizeComponent();
            component.value = newValue;
            return AddComponent(CoreGameComponentIds.Size, component);
        }

        public Entity ReplaceSize(int newValue) {
            var previousComponent = hasSize ? size : null;
            var component = _sizeComponentPool.Count > 0 ? _sizeComponentPool.Pop() : new SizeComponent();
            component.value = newValue;
            ReplaceComponent(CoreGameComponentIds.Size, component);
            if (previousComponent != null) {
                _sizeComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveSize() {
            var component = size;
            RemoveComponent(CoreGameComponentIds.Size);
            _sizeComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherSize;

        public static AllOfMatcher Size {
            get {
                if (_matcherSize == null) {
                    _matcherSize = new CoreGameMatcher(CoreGameComponentIds.Size);
                }

                return _matcherSize;
            }
        }
    }
