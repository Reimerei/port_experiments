using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public WorkersProductionComponent workersProduction { get { return (WorkersProductionComponent)GetComponent(MetaGameComponentIds.WorkersProduction); } }

        public bool hasWorkersProduction { get { return HasComponent(MetaGameComponentIds.WorkersProduction); } }

        static readonly Stack<WorkersProductionComponent> _workersProductionComponentPool = new Stack<WorkersProductionComponent>();

        public static void ClearWorkersProductionComponentPool() {
            _workersProductionComponentPool.Clear();
        }

        public Entity AddWorkersProduction(System.DateTime newStartTime) {
            var component = _workersProductionComponentPool.Count > 0 ? _workersProductionComponentPool.Pop() : new WorkersProductionComponent();
            component.startTime = newStartTime;
            return AddComponent(MetaGameComponentIds.WorkersProduction, component);
        }

        public Entity ReplaceWorkersProduction(System.DateTime newStartTime) {
            var previousComponent = hasWorkersProduction ? workersProduction : null;
            var component = _workersProductionComponentPool.Count > 0 ? _workersProductionComponentPool.Pop() : new WorkersProductionComponent();
            component.startTime = newStartTime;
            ReplaceComponent(MetaGameComponentIds.WorkersProduction, component);
            if (previousComponent != null) {
                _workersProductionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveWorkersProduction() {
            var component = workersProduction;
            RemoveComponent(MetaGameComponentIds.WorkersProduction);
            _workersProductionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity workersProductionEntity { get { return GetGroup(MetaGameMatcher.WorkersProduction).GetSingleEntity(); } }

        public WorkersProductionComponent workersProduction { get { return workersProductionEntity.workersProduction; } }

        public bool hasWorkersProduction { get { return workersProductionEntity != null; } }

        public Entity SetWorkersProduction(System.DateTime newStartTime) {
            if (hasWorkersProduction) {
                throw new SingleEntityException(MetaGameMatcher.WorkersProduction);
            }
            var entity = CreateEntity();
            entity.AddWorkersProduction(newStartTime);
            return entity;
        }

        public Entity ReplaceWorkersProduction(System.DateTime newStartTime) {
            var entity = workersProductionEntity;
            if (entity == null) {
                entity = SetWorkersProduction(newStartTime);
            } else {
                entity.ReplaceWorkersProduction(newStartTime);
            }

            return entity;
        }

        public void RemoveWorkersProduction() {
            DestroyEntity(workersProductionEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherWorkersProduction;

        public static AllOfMatcher WorkersProduction {
            get {
                if (_matcherWorkersProduction == null) {
                    _matcherWorkersProduction = new MetaGameMatcher(MetaGameComponentIds.WorkersProduction);
                }

                return _matcherWorkersProduction;
            }
        }
    }
