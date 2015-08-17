using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public TechnologiesComponent technologies { get { return (TechnologiesComponent)GetComponent(MetaGameComponentIds.Technologies); } }

        public bool hasTechnologies { get { return HasComponent(MetaGameComponentIds.Technologies); } }

        static readonly Stack<TechnologiesComponent> _technologiesComponentPool = new Stack<TechnologiesComponent>();

        public static void ClearTechnologiesComponentPool() {
            _technologiesComponentPool.Clear();
        }

        public Entity AddTechnologies(System.Collections.Generic.HashSet<string> newValues) {
            var component = _technologiesComponentPool.Count > 0 ? _technologiesComponentPool.Pop() : new TechnologiesComponent();
            component.values = newValues;
            return AddComponent(MetaGameComponentIds.Technologies, component);
        }

        public Entity ReplaceTechnologies(System.Collections.Generic.HashSet<string> newValues) {
            var previousComponent = hasTechnologies ? technologies : null;
            var component = _technologiesComponentPool.Count > 0 ? _technologiesComponentPool.Pop() : new TechnologiesComponent();
            component.values = newValues;
            ReplaceComponent(MetaGameComponentIds.Technologies, component);
            if (previousComponent != null) {
                _technologiesComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveTechnologies() {
            var component = technologies;
            RemoveComponent(MetaGameComponentIds.Technologies);
            _technologiesComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity technologiesEntity { get { return GetGroup(MetaGameMatcher.Technologies).GetSingleEntity(); } }

        public TechnologiesComponent technologies { get { return technologiesEntity.technologies; } }

        public bool hasTechnologies { get { return technologiesEntity != null; } }

        public Entity SetTechnologies(System.Collections.Generic.HashSet<string> newValues) {
            if (hasTechnologies) {
                throw new SingleEntityException(MetaGameMatcher.Technologies);
            }
            var entity = CreateEntity();
            entity.AddTechnologies(newValues);
            return entity;
        }

        public Entity ReplaceTechnologies(System.Collections.Generic.HashSet<string> newValues) {
            var entity = technologiesEntity;
            if (entity == null) {
                entity = SetTechnologies(newValues);
            } else {
                entity.ReplaceTechnologies(newValues);
            }

            return entity;
        }

        public void RemoveTechnologies() {
            DestroyEntity(technologiesEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherTechnologies;

        public static AllOfMatcher Technologies {
            get {
                if (_matcherTechnologies == null) {
                    _matcherTechnologies = new MetaGameMatcher(MetaGameComponentIds.Technologies);
                }

                return _matcherTechnologies;
            }
        }
    }
