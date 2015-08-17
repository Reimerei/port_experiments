using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public QuestTaskComponent questTask { get { return (QuestTaskComponent)GetComponent(MetaGameComponentIds.QuestTask); } }

        public bool hasQuestTask { get { return HasComponent(MetaGameComponentIds.QuestTask); } }

        static readonly Stack<QuestTaskComponent> _questTaskComponentPool = new Stack<QuestTaskComponent>();

        public static void ClearQuestTaskComponentPool() {
            _questTaskComponentPool.Clear();
        }

        public Entity AddQuestTask(QuestAction newAction, string newType, string newInfo, string newDescription, string newHint) {
            var component = _questTaskComponentPool.Count > 0 ? _questTaskComponentPool.Pop() : new QuestTaskComponent();
            component.action = newAction;
            component.type = newType;
            component.info = newInfo;
            component.description = newDescription;
            component.hint = newHint;
            return AddComponent(MetaGameComponentIds.QuestTask, component);
        }

        public Entity ReplaceQuestTask(QuestAction newAction, string newType, string newInfo, string newDescription, string newHint) {
            var previousComponent = hasQuestTask ? questTask : null;
            var component = _questTaskComponentPool.Count > 0 ? _questTaskComponentPool.Pop() : new QuestTaskComponent();
            component.action = newAction;
            component.type = newType;
            component.info = newInfo;
            component.description = newDescription;
            component.hint = newHint;
            ReplaceComponent(MetaGameComponentIds.QuestTask, component);
            if (previousComponent != null) {
                _questTaskComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveQuestTask() {
            var component = questTask;
            RemoveComponent(MetaGameComponentIds.QuestTask);
            _questTaskComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherQuestTask;

        public static AllOfMatcher QuestTask {
            get {
                if (_matcherQuestTask == null) {
                    _matcherQuestTask = new MetaGameMatcher(MetaGameComponentIds.QuestTask);
                }

                return _matcherQuestTask;
            }
        }
    }
