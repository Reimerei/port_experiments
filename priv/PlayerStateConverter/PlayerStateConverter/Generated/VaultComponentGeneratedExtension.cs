using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly VaultComponent vaultComponent = new VaultComponent();

        public bool isVault {
            get { return HasComponent(CoreGameComponentIds.Vault); }
            set {
                if (value != isVault) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.Vault, vaultComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.Vault);
                    }
                }
            }
        }

        public Entity IsVault(bool value) {
            isVault = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity vaultEntity { get { return GetGroup(CoreGameMatcher.Vault).GetSingleEntity(); } }

        public bool isVault {
            get { return vaultEntity != null; }
            set {
                var entity = vaultEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isVault = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherVault;

        public static AllOfMatcher Vault {
            get {
                if (_matcherVault == null) {
                    _matcherVault = new CoreGameMatcher(CoreGameComponentIds.Vault);
                }

                return _matcherVault;
            }
        }
    }
