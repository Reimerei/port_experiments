using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public QuestTaskAmountComponent questTaskAmount { get { return (QuestTaskAmountComponent)GetComponent(MetaGameComponentIds.QuestTaskAmount); } }

        public bool hasQuestTaskAmount { get { return HasComponent(MetaGameComponentIds.QuestTaskAmount); } }

        static readonly Stack<QuestTaskAmountComponent> _questTaskAmountComponentPool = new Stack<QuestTaskAmountComponent>();

        public static void ClearQuestTaskAmountComponentPool() {
            _questTaskAmountComponentPool.Clear();
        }

        public Entity AddQuestTaskAmount(int newToComplete, int newDone) {
            var component = _questTaskAmountComponentPool.Count > 0 ? _questTaskAmountComponentPool.Pop() : new QuestTaskAmountComponent();
            component.toComplete = newToComplete;
            component.done = newDone;
            return AddComponent(MetaGameComponentIds.QuestTaskAmount, component);
        }

        public Entity ReplaceQuestTaskAmount(int newToComplete, int newDone) {
            var previousComponent = hasQuestTaskAmount ? questTaskAmount : null;
            var component = _questTaskAmountComponentPool.Count > 0 ? _questTaskAmountComponentPool.Pop() : new QuestTaskAmountComponent();
            component.toComplete = newToComplete;
            component.done = newDone;
            ReplaceComponent(MetaGameComponentIds.QuestTaskAmount, component);
            if (previousComponent != null) {
                _questTaskAmountComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveQuestTaskAmount() {
            var component = questTaskAmount;
            RemoveComponent(MetaGameComponentIds.QuestTaskAmount);
            _questTaskAmountComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherQuestTaskAmount;

        public static AllOfMatcher QuestTaskAmount {
            get {
                if (_matcherQuestTaskAmount == null) {
                    _matcherQuestTaskAmount = new MetaGameMatcher(MetaGameComponentIds.QuestTaskAmount);
                }

                return _matcherQuestTaskAmount;
            }
        }
    }
