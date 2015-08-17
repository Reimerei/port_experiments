using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly ArsenalComponent arsenalComponent = new ArsenalComponent();

        public bool isArsenal {
            get { return HasComponent(CoreGameComponentIds.Arsenal); }
            set {
                if (value != isArsenal) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Arsenal, arsenalComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Arsenal);
                    }
                }
            }
        }

        public Entity IsArsenal(bool value) {
            isArsenal = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity arsenalEntity { get { return GetGroup(CoreGameMatcher.Arsenal).GetSingleEntity(); } }

        public bool isArsenal {
            get { return arsenalEntity != null; }
            set {
                var entity = arsenalEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isArsenal = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherArsenal;

        public static AllOfMatcher Arsenal {
            get {
                if (_matcherArsenal == null) {
                    _matcherArsenal = new CoreGameMatcher(CoreGameComponentIds.Arsenal);
                }

                return _matcherArsenal;
            }
        }
    }
