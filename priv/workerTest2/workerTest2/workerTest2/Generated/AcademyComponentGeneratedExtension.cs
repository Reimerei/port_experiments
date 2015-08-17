using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly AcademyComponent academyComponent = new AcademyComponent();

        public bool isAcademy {
            get { return HasComponent(CoreGameComponentIds.Academy); }
            set {
                if (value != isAcademy) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Academy, academyComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Academy);
                    }
                }
            }
        }

        public Entity IsAcademy(bool value) {
            isAcademy = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity academyEntity { get { return GetGroup(CoreGameMatcher.Academy).GetSingleEntity(); } }

        public bool isAcademy {
            get { return academyEntity != null; }
            set {
                var entity = academyEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isAcademy = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherAcademy;

        public static AllOfMatcher Academy {
            get {
                if (_matcherAcademy == null) {
                    _matcherAcademy = new CoreGameMatcher(CoreGameComponentIds.Academy);
                }

                return _matcherAcademy;
            }
        }
    }
