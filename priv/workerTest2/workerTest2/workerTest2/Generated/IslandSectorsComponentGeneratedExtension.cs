using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public IslandSectorsComponent islandSectors { get { return (IslandSectorsComponent)GetComponent(MetaGameComponentIds.IslandSectors); } }

        public bool hasIslandSectors { get { return HasComponent(MetaGameComponentIds.IslandSectors); } }

        static readonly Stack<IslandSectorsComponent> _islandSectorsComponentPool = new Stack<IslandSectorsComponent>();

        public static void ClearIslandSectorsComponentPool() {
            _islandSectorsComponentPool.Clear();
        }

        public Entity AddIslandSectors(bool[,] newSectors) {
            var component = _islandSectorsComponentPool.Count > 0 ? _islandSectorsComponentPool.Pop() : new IslandSectorsComponent();
            component.sectors = newSectors;
            return AddComponent(MetaGameComponentIds.IslandSectors, component);
        }

        public Entity ReplaceIslandSectors(bool[,] newSectors) {
            var previousComponent = hasIslandSectors ? islandSectors : null;
            var component = _islandSectorsComponentPool.Count > 0 ? _islandSectorsComponentPool.Pop() : new IslandSectorsComponent();
            component.sectors = newSectors;
            ReplaceComponent(MetaGameComponentIds.IslandSectors, component);
            if (previousComponent != null) {
                _islandSectorsComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveIslandSectors() {
            var component = islandSectors;
            RemoveComponent(MetaGameComponentIds.IslandSectors);
            _islandSectorsComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity islandSectorsEntity { get { return GetGroup(MetaGameMatcher.IslandSectors).GetSingleEntity(); } }

        public IslandSectorsComponent islandSectors { get { return islandSectorsEntity.islandSectors; } }

        public bool hasIslandSectors { get { return islandSectorsEntity != null; } }

        public Entity SetIslandSectors(bool[,] newSectors) {
            if (hasIslandSectors) {
                throw new SingleEntityException(MetaGameMatcher.IslandSectors);
            }
            var entity = CreateEntity();
            entity.AddIslandSectors(newSectors);
            return entity;
        }

        public Entity ReplaceIslandSectors(bool[,] newSectors) {
            var entity = islandSectorsEntity;
            if (entity == null) {
                entity = SetIslandSectors(newSectors);
            } else {
                entity.ReplaceIslandSectors(newSectors);
            }

            return entity;
        }

        public void RemoveIslandSectors() {
            DestroyEntity(islandSectorsEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherIslandSectors;

        public static AllOfMatcher IslandSectors {
            get {
                if (_matcherIslandSectors == null) {
                    _matcherIslandSectors = new MetaGameMatcher(MetaGameComponentIds.IslandSectors);
                }

                return _matcherIslandSectors;
            }
        }
    }
