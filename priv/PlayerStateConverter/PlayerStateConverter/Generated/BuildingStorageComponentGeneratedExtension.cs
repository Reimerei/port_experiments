using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public BuildingStorageComponent buildingStorage { get { return (BuildingStorageComponent)GetComponent(CoreGameComponentIds.BuildingStorage); } }

        public bool hasBuildingStorage { get { return HasComponent(CoreGameComponentIds.BuildingStorage); } }

        static readonly Stack<BuildingStorageComponent> _buildingStorageComponentPool = new Stack<BuildingStorageComponent>();

        public static void ClearBuildingStorageComponentPool() {
            _buildingStorageComponentPool.Clear();
        }

        public Entity AddBuildingStorage(System.Collections.Generic.Dictionary<string, int> newItems) {
            var component = _buildingStorageComponentPool.Count > 0 ? _buildingStorageComponentPool.Pop() : new BuildingStorageComponent();
            component.items = newItems;
            return AddComponent(CoreGameComponentIds.BuildingStorage, component);
        }

        public Entity ReplaceBuildingStorage(System.Collections.Generic.Dictionary<string, int> newItems) {
            var previousComponent = hasBuildingStorage ? buildingStorage : null;
            var component = _buildingStorageComponentPool.Count > 0 ? _buildingStorageComponentPool.Pop() : new BuildingStorageComponent();
            component.items = newItems;
            ReplaceComponent(CoreGameComponentIds.BuildingStorage, component);
            if (previousComponent != null) {
                _buildingStorageComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveBuildingStorage() {
            var component = buildingStorage;
            RemoveComponent(CoreGameComponentIds.BuildingStorage);
            _buildingStorageComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherBuildingStorage;

        public static AllOfMatcher BuildingStorage {
            get {
                if (_matcherBuildingStorage == null) {
                    _matcherBuildingStorage = new CoreGameMatcher(CoreGameComponentIds.BuildingStorage);
                }

                return _matcherBuildingStorage;
            }
        }
    }
