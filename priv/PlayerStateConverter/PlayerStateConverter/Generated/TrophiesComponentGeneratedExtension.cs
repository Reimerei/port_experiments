using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public TrophiesComponent trophies { get { return (TrophiesComponent)GetComponent(MetaGameComponentIds.Trophies); } }

        public bool hasTrophies { get { return HasComponent(MetaGameComponentIds.Trophies); } }

        static readonly Stack<TrophiesComponent> _trophiesComponentPool = new Stack<TrophiesComponent>();

        public static void ClearTrophiesComponentPool() {
            _trophiesComponentPool.Clear();
        }

        public Entity AddTrophies(int newValue) {
            var component = _trophiesComponentPool.Count > 0 ? _trophiesComponentPool.Pop() : new TrophiesComponent();
            component.value = newValue;
            return AddComponent(MetaGameComponentIds.Trophies, component);
        }

        public Entity ReplaceTrophies(int newValue) {
            var previousComponent = hasTrophies ? trophies : null;
            var component = _trophiesComponentPool.Count > 0 ? _trophiesComponentPool.Pop() : new TrophiesComponent();
            component.value = newValue;
            ReplaceComponent(MetaGameComponentIds.Trophies, component);
            if (previousComponent != null) {
                _trophiesComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveTrophies() {
            var component = trophies;
            RemoveComponent(MetaGameComponentIds.Trophies);
            _trophiesComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity trophiesEntity { get { return GetGroup(MetaGameMatcher.Trophies).GetSingleEntity(); } }

        public TrophiesComponent trophies { get { return trophiesEntity.trophies; } }

        public bool hasTrophies { get { return trophiesEntity != null; } }

        public Entity SetTrophies(int newValue) {
            if (hasTrophies) {
                throw new SingleEntityException(MetaGameMatcher.Trophies);
            }
            var entity = CreateEntity();
            entity.AddTrophies(newValue);
            return entity;
        }

        public Entity ReplaceTrophies(int newValue) {
            var entity = trophiesEntity;
            if (entity == null) {
                entity = SetTrophies(newValue);
            } else {
                entity.ReplaceTrophies(newValue);
            }

            return entity;
        }

        public void RemoveTrophies() {
            DestroyEntity(trophiesEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherTrophies;

        public static AllOfMatcher Trophies {
            get {
                if (_matcherTrophies == null) {
                    _matcherTrophies = new MetaGameMatcher(MetaGameComponentIds.Trophies);
                }

                return _matcherTrophies;
            }
        }
    }
