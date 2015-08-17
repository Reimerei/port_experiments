using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public TypeComponent type { get { return (TypeComponent)GetComponent(CoreGameComponentIds.Type); } }

        public bool hasType { get { return HasComponent(CoreGameComponentIds.Type); } }

        static readonly Stack<TypeComponent> _typeComponentPool = new Stack<TypeComponent>();

        public static void ClearTypeComponentPool() {
            _typeComponentPool.Clear();
        }

        public Entity AddType(string newValue) {
            var component = _typeComponentPool.Count > 0 ? _typeComponentPool.Pop() : new TypeComponent();
            component.value = newValue;
            return AddComponent(CoreGameComponentIds.Type, component);
        }

        public Entity ReplaceType(string newValue) {
            var previousComponent = hasType ? type : null;
            var component = _typeComponentPool.Count > 0 ? _typeComponentPool.Pop() : new TypeComponent();
            component.value = newValue;
            ReplaceComponent(CoreGameComponentIds.Type, component);
            if (previousComponent != null) {
                _typeComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveType() {
            var component = type;
            RemoveComponent(CoreGameComponentIds.Type);
            _typeComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherType;

        public static AllOfMatcher Type {
            get {
                if (_matcherType == null) {
                    _matcherType = new CoreGameMatcher(CoreGameComponentIds.Type);
                }

                return _matcherType;
            }
        }
    }
