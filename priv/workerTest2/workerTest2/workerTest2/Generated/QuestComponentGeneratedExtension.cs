using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public QuestComponent quest { get { return (QuestComponent)GetComponent(MetaGameComponentIds.Quest); } }

        public bool hasQuest { get { return HasComponent(MetaGameComponentIds.Quest); } }

        static readonly Stack<QuestComponent> _questComponentPool = new Stack<QuestComponent>();

        public static void ClearQuestComponentPool() {
            _questComponentPool.Clear();
        }

        public Entity AddQuest(string newId) {
            var component = _questComponentPool.Count > 0 ? _questComponentPool.Pop() : new QuestComponent();
            component.id = newId;
            return AddComponent(MetaGameComponentIds.Quest, component);
        }

        public Entity ReplaceQuest(string newId) {
            var previousComponent = hasQuest ? quest : null;
            var component = _questComponentPool.Count > 0 ? _questComponentPool.Pop() : new QuestComponent();
            component.id = newId;
            ReplaceComponent(MetaGameComponentIds.Quest, component);
            if (previousComponent != null) {
                _questComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveQuest() {
            var component = quest;
            RemoveComponent(MetaGameComponentIds.Quest);
            _questComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherQuest;

        public static AllOfMatcher Quest {
            get {
                if (_matcherQuest == null) {
                    _matcherQuest = new MetaGameMatcher(MetaGameComponentIds.Quest);
                }

                return _matcherQuest;
            }
        }
    }
