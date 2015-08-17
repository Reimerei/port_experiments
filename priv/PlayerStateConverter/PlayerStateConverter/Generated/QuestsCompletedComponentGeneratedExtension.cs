using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public QuestsCompletedComponent questsCompleted { get { return (QuestsCompletedComponent)GetComponent(MetaGameComponentIds.QuestsCompleted); } }

        public bool hasQuestsCompleted { get { return HasComponent(MetaGameComponentIds.QuestsCompleted); } }

        static readonly Stack<QuestsCompletedComponent> _questsCompletedComponentPool = new Stack<QuestsCompletedComponent>();

        public static void ClearQuestsCompletedComponentPool() {
            _questsCompletedComponentPool.Clear();
        }

        public Entity AddQuestsCompleted(System.Collections.Generic.HashSet<string> newIds) {
            var component = _questsCompletedComponentPool.Count > 0 ? _questsCompletedComponentPool.Pop() : new QuestsCompletedComponent();
            component.ids = newIds;
            return AddComponent(MetaGameComponentIds.QuestsCompleted, component);
        }

        public Entity ReplaceQuestsCompleted(System.Collections.Generic.HashSet<string> newIds) {
            var previousComponent = hasQuestsCompleted ? questsCompleted : null;
            var component = _questsCompletedComponentPool.Count > 0 ? _questsCompletedComponentPool.Pop() : new QuestsCompletedComponent();
            component.ids = newIds;
            ReplaceComponent(MetaGameComponentIds.QuestsCompleted, component);
            if (previousComponent != null) {
                _questsCompletedComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveQuestsCompleted() {
            var component = questsCompleted;
            RemoveComponent(MetaGameComponentIds.QuestsCompleted);
            _questsCompletedComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity questsCompletedEntity { get { return GetGroup(MetaGameMatcher.QuestsCompleted).GetSingleEntity(); } }

        public QuestsCompletedComponent questsCompleted { get { return questsCompletedEntity.questsCompleted; } }

        public bool hasQuestsCompleted { get { return questsCompletedEntity != null; } }

        public Entity SetQuestsCompleted(System.Collections.Generic.HashSet<string> newIds) {
            if (hasQuestsCompleted) {
                throw new SingleEntityException(MetaGameMatcher.QuestsCompleted);
            }
            var entity = CreateEntity();
            entity.AddQuestsCompleted(newIds);
            return entity;
        }

        public Entity ReplaceQuestsCompleted(System.Collections.Generic.HashSet<string> newIds) {
            var entity = questsCompletedEntity;
            if (entity == null) {
                entity = SetQuestsCompleted(newIds);
            } else {
                entity.ReplaceQuestsCompleted(newIds);
            }

            return entity;
        }

        public void RemoveQuestsCompleted() {
            DestroyEntity(questsCompletedEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherQuestsCompleted;

        public static AllOfMatcher QuestsCompleted {
            get {
                if (_matcherQuestsCompleted == null) {
                    _matcherQuestsCompleted = new MetaGameMatcher(MetaGameComponentIds.QuestsCompleted);
                }

                return _matcherQuestsCompleted;
            }
        }
    }
