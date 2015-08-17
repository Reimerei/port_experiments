using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly FortressComponent fortressComponent = new FortressComponent();

        public bool isFortress {
            get { return HasComponent(CoreGameComponentIds.Fortress); }
            set {
                if (value != isFortress) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Fortress, fortressComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Fortress);
                    }
                }
            }
        }

        public Entity IsFortress(bool value) {
            isFortress = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity fortressEntity { get { return GetGroup(CoreGameMatcher.Fortress).GetSingleEntity(); } }

        public bool isFortress {
            get { return fortressEntity != null; }
            set {
                var entity = fortressEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isFortress = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherFortress;

        public static AllOfMatcher Fortress {
            get {
                if (_matcherFortress == null) {
                    _matcherFortress = new CoreGameMatcher(CoreGameComponentIds.Fortress);
                }

                return _matcherFortress;
            }
        }
    }
