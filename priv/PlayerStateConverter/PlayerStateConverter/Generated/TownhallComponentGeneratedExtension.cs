using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly TownhallComponent townhallComponent = new TownhallComponent();

        public bool isTownhall {
            get { return HasComponent(CoreGameComponentIds.Townhall); }
            set {
                if (value != isTownhall) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Townhall, townhallComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Townhall);
                    }
                }
            }
        }

        public Entity IsTownhall(bool value) {
            isTownhall = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity townhallEntity { get { return GetGroup(CoreGameMatcher.Townhall).GetSingleEntity(); } }

        public bool isTownhall {
            get { return townhallEntity != null; }
            set {
                var entity = townhallEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isTownhall = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherTownhall;

        public static AllOfMatcher Townhall {
            get {
                if (_matcherTownhall == null) {
                    _matcherTownhall = new CoreGameMatcher(CoreGameComponentIds.Townhall);
                }

                return _matcherTownhall;
            }
        }
    }
