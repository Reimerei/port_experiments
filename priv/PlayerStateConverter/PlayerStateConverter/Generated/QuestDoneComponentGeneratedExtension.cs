using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly QuestDoneComponent questDoneComponent = new QuestDoneComponent();

        public bool isQuestDone {
            get { return HasComponent(MetaGameComponentIds.QuestDone); }
            set {
                if (value != isQuestDone) {
                    if (value) {
                        AddComponent(MetaGameComponentIds.QuestDone, questDoneComponent);
                    } else {
                        RemoveComponent(MetaGameComponentIds.QuestDone);
                    }
                }
            }
        }

        public Entity IsQuestDone(bool value) {
            isQuestDone = value;
            return this;
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherQuestDone;

        public static AllOfMatcher QuestDone {
            get {
                if (_matcherQuestDone == null) {
                    _matcherQuestDone = new MetaGameMatcher(MetaGameComponentIds.QuestDone);
                }

                return _matcherQuestDone;
            }
        }
    }
