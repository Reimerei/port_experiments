using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly HousingComponent housingComponent = new HousingComponent();

        public bool isHousing {
            get { return HasComponent(CoreGameComponentIds.Housing); }
            set {
                if (value != isHousing) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Housing, housingComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Housing);
                    }
                }
            }
        }

        public Entity IsHousing(bool value) {
            isHousing = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherHousing;

        public static AllOfMatcher Housing {
            get {
                if (_matcherHousing == null) {
                    _matcherHousing = new CoreGameMatcher(CoreGameComponentIds.Housing);
                }

                return _matcherHousing;
            }
        }
    }
