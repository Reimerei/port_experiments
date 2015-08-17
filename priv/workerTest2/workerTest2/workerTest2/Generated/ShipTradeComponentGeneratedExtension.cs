using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public ShipTradeComponent shipTrade { get { return (ShipTradeComponent)GetComponent(CoreGameComponentIds.ShipTrade); } }

        public bool hasShipTrade { get { return HasComponent(CoreGameComponentIds.ShipTrade); } }

        static readonly Stack<ShipTradeComponent> _shipTradeComponentPool = new Stack<ShipTradeComponent>();

        public static void ClearShipTradeComponentPool() {
            _shipTradeComponentPool.Clear();
        }

        public Entity AddShipTrade(System.Collections.Generic.Dictionary<string, int> newSoldItems, System.Collections.Generic.Dictionary<string, int> newBoughtItems, int newDebit, int newCredit) {
            var component = _shipTradeComponentPool.Count > 0 ? _shipTradeComponentPool.Pop() : new ShipTradeComponent();
            component.soldItems = newSoldItems;
            component.boughtItems = newBoughtItems;
            component.debit = newDebit;
            component.credit = newCredit;
            return AddComponent(CoreGameComponentIds.ShipTrade, component);
        }

        public Entity ReplaceShipTrade(System.Collections.Generic.Dictionary<string, int> newSoldItems, System.Collections.Generic.Dictionary<string, int> newBoughtItems, int newDebit, int newCredit) {
            var previousComponent = hasShipTrade ? shipTrade : null;
            var component = _shipTradeComponentPool.Count > 0 ? _shipTradeComponentPool.Pop() : new ShipTradeComponent();
            component.soldItems = newSoldItems;
            component.boughtItems = newBoughtItems;
            component.debit = newDebit;
            component.credit = newCredit;
            ReplaceComponent(CoreGameComponentIds.ShipTrade, component);
            if (previousComponent != null) {
                _shipTradeComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveShipTrade() {
            var component = shipTrade;
            RemoveComponent(CoreGameComponentIds.ShipTrade);
            _shipTradeComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherShipTrade;

        public static AllOfMatcher ShipTrade {
            get {
                if (_matcherShipTrade == null) {
                    _matcherShipTrade = new CoreGameMatcher(CoreGameComponentIds.ShipTrade);
                }

                return _matcherShipTrade;
            }
        }
    }
