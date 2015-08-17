using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly DocksComponent docksComponent = new DocksComponent();

        public bool isDocks {
            get { return HasComponent(CoreGameComponentIds.Docks); }
            set {
                if (value != isDocks) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Docks, docksComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Docks);
                    }
                }
            }
        }

        public Entity IsDocks(bool value) {
            isDocks = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity docksEntity { get { return GetGroup(CoreGameMatcher.Docks).GetSingleEntity(); } }

        public bool isDocks {
            get { return docksEntity != null; }
            set {
                var entity = docksEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isDocks = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherDocks;

        public static AllOfMatcher Docks {
            get {
                if (_matcherDocks == null) {
                    _matcherDocks = new CoreGameMatcher(CoreGameComponentIds.Docks);
                }

                return _matcherDocks;
            }
        }
    }
