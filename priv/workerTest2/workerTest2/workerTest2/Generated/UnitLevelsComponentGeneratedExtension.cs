using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public UnitLevelsComponent unitLevels { get { return (UnitLevelsComponent)GetComponent(MetaGameComponentIds.UnitLevels); } }

        public bool hasUnitLevels { get { return HasComponent(MetaGameComponentIds.UnitLevels); } }

        static readonly Stack<UnitLevelsComponent> _unitLevelsComponentPool = new Stack<UnitLevelsComponent>();

        public static void ClearUnitLevelsComponentPool() {
            _unitLevelsComponentPool.Clear();
        }

        public Entity AddUnitLevels(System.Collections.Generic.Dictionary<string, int> newValues) {
            var component = _unitLevelsComponentPool.Count > 0 ? _unitLevelsComponentPool.Pop() : new UnitLevelsComponent();
            component.values = newValues;
            return AddComponent(MetaGameComponentIds.UnitLevels, component);
        }

        public Entity ReplaceUnitLevels(System.Collections.Generic.Dictionary<string, int> newValues) {
            var previousComponent = hasUnitLevels ? unitLevels : null;
            var component = _unitLevelsComponentPool.Count > 0 ? _unitLevelsComponentPool.Pop() : new UnitLevelsComponent();
            component.values = newValues;
            ReplaceComponent(MetaGameComponentIds.UnitLevels, component);
            if (previousComponent != null) {
                _unitLevelsComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveUnitLevels() {
            var component = unitLevels;
            RemoveComponent(MetaGameComponentIds.UnitLevels);
            _unitLevelsComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity unitLevelsEntity { get { return GetGroup(MetaGameMatcher.UnitLevels).GetSingleEntity(); } }

        public UnitLevelsComponent unitLevels { get { return unitLevelsEntity.unitLevels; } }

        public bool hasUnitLevels { get { return unitLevelsEntity != null; } }

        public Entity SetUnitLevels(System.Collections.Generic.Dictionary<string, int> newValues) {
            if (hasUnitLevels) {
                throw new SingleEntityException(MetaGameMatcher.UnitLevels);
            }
            var entity = CreateEntity();
            entity.AddUnitLevels(newValues);
            return entity;
        }

        public Entity ReplaceUnitLevels(System.Collections.Generic.Dictionary<string, int> newValues) {
            var entity = unitLevelsEntity;
            if (entity == null) {
                entity = SetUnitLevels(newValues);
            } else {
                entity.ReplaceUnitLevels(newValues);
            }

            return entity;
        }

        public void RemoveUnitLevels() {
            DestroyEntity(unitLevelsEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherUnitLevels;

        public static AllOfMatcher UnitLevels {
            get {
                if (_matcherUnitLevels == null) {
                    _matcherUnitLevels = new MetaGameMatcher(MetaGameComponentIds.UnitLevels);
                }

                return _matcherUnitLevels;
            }
        }
    }
