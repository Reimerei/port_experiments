using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly ProductionPausedComponent productionPausedComponent = new ProductionPausedComponent();

        public bool isProductionPaused {
            get { return HasComponent(CoreGameComponentIds.ProductionPaused); }
            set {
                if (value != isProductionPaused) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.ProductionPaused, productionPausedComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.ProductionPaused);
                    }
                }
            }
        }

        public Entity IsProductionPaused(bool value) {
            isProductionPaused = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherProductionPaused;

        public static AllOfMatcher ProductionPaused {
            get {
                if (_matcherProductionPaused == null) {
                    _matcherProductionPaused = new CoreGameMatcher(CoreGameComponentIds.ProductionPaused);
                }

                return _matcherProductionPaused;
            }
        }
    }
