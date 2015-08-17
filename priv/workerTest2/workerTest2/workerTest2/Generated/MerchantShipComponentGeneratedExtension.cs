using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly MerchantShipComponent merchantShipComponent = new MerchantShipComponent();

        public bool isMerchantShip {
            get { return HasComponent(CoreGameComponentIds.MerchantShip); }
            set {
                if (value != isMerchantShip) {
                    if (value) {
                        AddComponent(CoreGameComponentIds.MerchantShip, merchantShipComponent);
                    } else {
                        RemoveComponent(CoreGameComponentIds.MerchantShip);
                    }
                }
            }
        }

        public Entity IsMerchantShip(bool value) {
            isMerchantShip = value;
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherMerchantShip;

        public static AllOfMatcher MerchantShip {
            get {
                if (_matcherMerchantShip == null) {
                    _matcherMerchantShip = new CoreGameMatcher(CoreGameComponentIds.MerchantShip);
                }

                return _matcherMerchantShip;
            }
        }
    }
