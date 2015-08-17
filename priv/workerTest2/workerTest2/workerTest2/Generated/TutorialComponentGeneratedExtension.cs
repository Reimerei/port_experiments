using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly TutorialComponent tutorialComponent = new TutorialComponent();

        public bool isTutorial {
            get { return HasComponent(MetaGameComponentIds.Tutorial); }
            set {
                if (value != isTutorial) {
                    if (value) {
                        AddComponent(MetaGameComponentIds.Tutorial, tutorialComponent);
                    } else {
                        RemoveComponent(MetaGameComponentIds.Tutorial);
                    }
                }
            }
        }

        public Entity IsTutorial(bool value) {
            isTutorial = value;
            return this;
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherTutorial;

        public static AllOfMatcher Tutorial {
            get {
                if (_matcherTutorial == null) {
                    _matcherTutorial = new MetaGameMatcher(MetaGameComponentIds.Tutorial);
                }

                return _matcherTutorial;
            }
        }
    }
