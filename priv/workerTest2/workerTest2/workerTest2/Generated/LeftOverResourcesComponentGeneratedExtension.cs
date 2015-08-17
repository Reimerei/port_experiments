using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public LeftOverResourcesComponent leftOverResources { get { return (LeftOverResourcesComponent)GetComponent(MetaGameComponentIds.LeftOverResources); } }

        public bool hasLeftOverResources { get { return HasComponent(MetaGameComponentIds.LeftOverResources); } }

        static readonly Stack<LeftOverResourcesComponent> _leftOverResourcesComponentPool = new Stack<LeftOverResourcesComponent>();

        public static void ClearLeftOverResourcesComponentPool() {
            _leftOverResourcesComponentPool.Clear();
        }

        public Entity AddLeftOverResources(System.Collections.Generic.Dictionary<string, int> newResources) {
            var component = _leftOverResourcesComponentPool.Count > 0 ? _leftOverResourcesComponentPool.Pop() : new LeftOverResourcesComponent();
            component.resources = newResources;
            return AddComponent(MetaGameComponentIds.LeftOverResources, component);
        }

        public Entity ReplaceLeftOverResources(System.Collections.Generic.Dictionary<string, int> newResources) {
            var previousComponent = hasLeftOverResources ? leftOverResources : null;
            var component = _leftOverResourcesComponentPool.Count > 0 ? _leftOverResourcesComponentPool.Pop() : new LeftOverResourcesComponent();
            component.resources = newResources;
            ReplaceComponent(MetaGameComponentIds.LeftOverResources, component);
            if (previousComponent != null) {
                _leftOverResourcesComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveLeftOverResources() {
            var component = leftOverResources;
            RemoveComponent(MetaGameComponentIds.LeftOverResources);
            _leftOverResourcesComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity leftOverResourcesEntity { get { return GetGroup(MetaGameMatcher.LeftOverResources).GetSingleEntity(); } }

        public LeftOverResourcesComponent leftOverResources { get { return leftOverResourcesEntity.leftOverResources; } }

        public bool hasLeftOverResources { get { return leftOverResourcesEntity != null; } }

        public Entity SetLeftOverResources(System.Collections.Generic.Dictionary<string, int> newResources) {
            if (hasLeftOverResources) {
                throw new SingleEntityException(MetaGameMatcher.LeftOverResources);
            }
            var entity = CreateEntity();
            entity.AddLeftOverResources(newResources);
            return entity;
        }

        public Entity ReplaceLeftOverResources(System.Collections.Generic.Dictionary<string, int> newResources) {
            var entity = leftOverResourcesEntity;
            if (entity == null) {
                entity = SetLeftOverResources(newResources);
            } else {
                entity.ReplaceLeftOverResources(newResources);
            }

            return entity;
        }

        public void RemoveLeftOverResources() {
            DestroyEntity(leftOverResourcesEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherLeftOverResources;

        public static AllOfMatcher LeftOverResources {
            get {
                if (_matcherLeftOverResources == null) {
                    _matcherLeftOverResources = new MetaGameMatcher(MetaGameComponentIds.LeftOverResources);
                }

                return _matcherLeftOverResources;
            }
        }
    }
