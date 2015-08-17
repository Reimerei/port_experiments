using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public LastPvpAttackTimeComponent lastPvpAttackTime { get { return (LastPvpAttackTimeComponent)GetComponent(MetaGameComponentIds.LastPvpAttackTime); } }

        public bool hasLastPvpAttackTime { get { return HasComponent(MetaGameComponentIds.LastPvpAttackTime); } }

        static readonly Stack<LastPvpAttackTimeComponent> _lastPvpAttackTimeComponentPool = new Stack<LastPvpAttackTimeComponent>();

        public static void ClearLastPvpAttackTimeComponentPool() {
            _lastPvpAttackTimeComponentPool.Clear();
        }

        public Entity AddLastPvpAttackTime(long newTime) {
            var component = _lastPvpAttackTimeComponentPool.Count > 0 ? _lastPvpAttackTimeComponentPool.Pop() : new LastPvpAttackTimeComponent();
            component.time = newTime;
            return AddComponent(MetaGameComponentIds.LastPvpAttackTime, component);
        }

        public Entity ReplaceLastPvpAttackTime(long newTime) {
            var previousComponent = hasLastPvpAttackTime ? lastPvpAttackTime : null;
            var component = _lastPvpAttackTimeComponentPool.Count > 0 ? _lastPvpAttackTimeComponentPool.Pop() : new LastPvpAttackTimeComponent();
            component.time = newTime;
            ReplaceComponent(MetaGameComponentIds.LastPvpAttackTime, component);
            if (previousComponent != null) {
                _lastPvpAttackTimeComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveLastPvpAttackTime() {
            var component = lastPvpAttackTime;
            RemoveComponent(MetaGameComponentIds.LastPvpAttackTime);
            _lastPvpAttackTimeComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity lastPvpAttackTimeEntity { get { return GetGroup(MetaGameMatcher.LastPvpAttackTime).GetSingleEntity(); } }

        public LastPvpAttackTimeComponent lastPvpAttackTime { get { return lastPvpAttackTimeEntity.lastPvpAttackTime; } }

        public bool hasLastPvpAttackTime { get { return lastPvpAttackTimeEntity != null; } }

        public Entity SetLastPvpAttackTime(long newTime) {
            if (hasLastPvpAttackTime) {
                throw new SingleEntityException(MetaGameMatcher.LastPvpAttackTime);
            }
            var entity = CreateEntity();
            entity.AddLastPvpAttackTime(newTime);
            return entity;
        }

        public Entity ReplaceLastPvpAttackTime(long newTime) {
            var entity = lastPvpAttackTimeEntity;
            if (entity == null) {
                entity = SetLastPvpAttackTime(newTime);
            } else {
                entity.ReplaceLastPvpAttackTime(newTime);
            }

            return entity;
        }

        public void RemoveLastPvpAttackTime() {
            DestroyEntity(lastPvpAttackTimeEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherLastPvpAttackTime;

        public static AllOfMatcher LastPvpAttackTime {
            get {
                if (_matcherLastPvpAttackTime == null) {
                    _matcherLastPvpAttackTime = new MetaGameMatcher(MetaGameComponentIds.LastPvpAttackTime);
                }

                return _matcherLastPvpAttackTime;
            }
        }
    }
