using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public IslandNextPirateAttackComponent islandNextPirateAttack { get { return (IslandNextPirateAttackComponent)GetComponent(MetaGameComponentIds.IslandNextPirateAttack); } }

        public bool hasIslandNextPirateAttack { get { return HasComponent(MetaGameComponentIds.IslandNextPirateAttack); } }

        static readonly Stack<IslandNextPirateAttackComponent> _islandLastPirateAttackComponentPool = new Stack<IslandNextPirateAttackComponent>();

        public static void ClearIslandLastPirateAttackComponentPool() {
            _islandLastPirateAttackComponentPool.Clear();
        }

        public Entity AddIslandNextPirateAttack(System.DateTime newTime) {
            var component = _islandLastPirateAttackComponentPool.Count > 0 ? _islandLastPirateAttackComponentPool.Pop() : new IslandNextPirateAttackComponent();
            component.time = newTime;
            return AddComponent(MetaGameComponentIds.IslandNextPirateAttack, component);
        }

        public Entity ReplaceIslandNextPirateAttack(System.DateTime newTime) {
            var previousComponent = hasIslandNextPirateAttack ? islandNextPirateAttack : null;
            var component = _islandLastPirateAttackComponentPool.Count > 0 ? _islandLastPirateAttackComponentPool.Pop() : new IslandNextPirateAttackComponent();
            component.time = newTime;
            ReplaceComponent(MetaGameComponentIds.IslandNextPirateAttack, component);
            if (previousComponent != null) {
                _islandLastPirateAttackComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveIslandNextPirateAttack() {
            var component = islandNextPirateAttack;
            RemoveComponent(MetaGameComponentIds.IslandNextPirateAttack);
            _islandLastPirateAttackComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity islandNextPirateAttackEntity { get { return GetGroup(MetaGameMatcher.IslandNextPirateAttack).GetSingleEntity(); } }

        public IslandNextPirateAttackComponent islandNextPirateAttack { get { return islandNextPirateAttackEntity.islandNextPirateAttack; } }

        public bool hasIslandNextPirateAttack { get { return islandNextPirateAttackEntity != null; } }

        public Entity SetIslandNextPirateAttack(System.DateTime newTime) {
            if (hasIslandNextPirateAttack) {
                throw new SingleEntityException(MetaGameMatcher.IslandNextPirateAttack);
            }
            var entity = CreateEntity();
            entity.AddIslandNextPirateAttack(newTime);
            return entity;
        }

        public Entity ReplaceIslandNextPirateAttack(System.DateTime newTime) {
            var entity = islandNextPirateAttackEntity;
            if (entity == null) {
                entity = SetIslandNextPirateAttack(newTime);
            } else {
                entity.ReplaceIslandNextPirateAttack(newTime);
            }

            return entity;
        }

        public void RemoveIslandNextPirateAttack() {
            DestroyEntity(islandNextPirateAttackEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherIslandNextPirateAttack;

        public static AllOfMatcher IslandNextPirateAttack {
            get {
                if (_matcherIslandNextPirateAttack == null) {
                    _matcherIslandNextPirateAttack = new MetaGameMatcher(MetaGameComponentIds.IslandNextPirateAttack);
                }

                return _matcherIslandNextPirateAttack;
            }
        }
    }
