using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public PlayerResourcesComponent playerResources { get { return (PlayerResourcesComponent)GetComponent(MetaGameComponentIds.PlayerResources); } }

        public bool hasPlayerResources { get { return HasComponent(MetaGameComponentIds.PlayerResources); } }

        static readonly Stack<PlayerResourcesComponent> _playerResourcesComponentPool = new Stack<PlayerResourcesComponent>();

        public static void ClearPlayerResourcesComponentPool() {
            _playerResourcesComponentPool.Clear();
        }

        public Entity AddPlayerResources(System.Collections.Generic.Dictionary<string, int> newQuantities, System.Collections.Generic.Dictionary<string, int> newCapacities) {
            var component = _playerResourcesComponentPool.Count > 0 ? _playerResourcesComponentPool.Pop() : new PlayerResourcesComponent();
            component.quantities = newQuantities;
            component.capacities = newCapacities;
            return AddComponent(MetaGameComponentIds.PlayerResources, component);
        }

        public Entity ReplacePlayerResources(System.Collections.Generic.Dictionary<string, int> newQuantities, System.Collections.Generic.Dictionary<string, int> newCapacities) {
            var previousComponent = hasPlayerResources ? playerResources : null;
            var component = _playerResourcesComponentPool.Count > 0 ? _playerResourcesComponentPool.Pop() : new PlayerResourcesComponent();
            component.quantities = newQuantities;
            component.capacities = newCapacities;
            ReplaceComponent(MetaGameComponentIds.PlayerResources, component);
            if (previousComponent != null) {
                _playerResourcesComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemovePlayerResources() {
            var component = playerResources;
            RemoveComponent(MetaGameComponentIds.PlayerResources);
            _playerResourcesComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity playerResourcesEntity { get { return GetGroup(MetaGameMatcher.PlayerResources).GetSingleEntity(); } }

        public PlayerResourcesComponent playerResources { get { return playerResourcesEntity.playerResources; } }

        public bool hasPlayerResources { get { return playerResourcesEntity != null; } }

        public Entity SetPlayerResources(System.Collections.Generic.Dictionary<string, int> newQuantities, System.Collections.Generic.Dictionary<string, int> newCapacities) {
            if (hasPlayerResources) {
                throw new SingleEntityException(MetaGameMatcher.PlayerResources);
            }
            var entity = CreateEntity();
            entity.AddPlayerResources(newQuantities, newCapacities);
            return entity;
        }

        public Entity ReplacePlayerResources(System.Collections.Generic.Dictionary<string, int> newQuantities, System.Collections.Generic.Dictionary<string, int> newCapacities) {
            var entity = playerResourcesEntity;
            if (entity == null) {
                entity = SetPlayerResources(newQuantities, newCapacities);
            } else {
                entity.ReplacePlayerResources(newQuantities, newCapacities);
            }

            return entity;
        }

        public void RemovePlayerResources() {
            DestroyEntity(playerResourcesEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherPlayerResources;

        public static AllOfMatcher PlayerResources {
            get {
                if (_matcherPlayerResources == null) {
                    _matcherPlayerResources = new MetaGameMatcher(MetaGameComponentIds.PlayerResources);
                }

                return _matcherPlayerResources;
            }
        }
    }
