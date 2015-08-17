using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly StorageComponent storageComponent = new StorageComponent();

        public bool isStorage {
            get { return HasComponent(CoreGameComponentIds.Storage); }
            set {
                if (value != isStorage) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Storage, storageComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Storage);
                    }
                }
            }
        }

        public Entity IsStorage(bool value) {
            isStorage = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity storageEntity { get { return GetGroup(CoreGameMatcher.Storage).GetSingleEntity(); } }

        public bool isStorage {
            get { return storageEntity != null; }
            set {
                var entity = storageEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isStorage = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherStorage;

        public static AllOfMatcher Storage {
            get {
                if (_matcherStorage == null) {
                    _matcherStorage = new CoreGameMatcher(CoreGameComponentIds.Storage);
                }

                return _matcherStorage;
            }
        }
    }
