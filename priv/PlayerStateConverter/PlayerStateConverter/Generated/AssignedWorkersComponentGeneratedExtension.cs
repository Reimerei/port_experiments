using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public AssignedWorkersComponent assignedWorkers { get { return (AssignedWorkersComponent)GetComponent(MetaGameComponentIds.AssignedWorkers); } }

        public bool hasAssignedWorkers { get { return HasComponent(MetaGameComponentIds.AssignedWorkers); } }

        static readonly Stack<AssignedWorkersComponent> _assignedWorkersComponentPool = new Stack<AssignedWorkersComponent>();

        public static void ClearAssignedWorkersComponentPool() {
            _assignedWorkersComponentPool.Clear();
        }

        public Entity AddAssignedWorkers(int newCount) {
            var component = _assignedWorkersComponentPool.Count > 0 ? _assignedWorkersComponentPool.Pop() : new AssignedWorkersComponent();
            component.count = newCount;
            return AddComponent(MetaGameComponentIds.AssignedWorkers, component);
        }

        public Entity ReplaceAssignedWorkers(int newCount) {
            var previousComponent = hasAssignedWorkers ? assignedWorkers : null;
            var component = _assignedWorkersComponentPool.Count > 0 ? _assignedWorkersComponentPool.Pop() : new AssignedWorkersComponent();
            component.count = newCount;
            ReplaceComponent(MetaGameComponentIds.AssignedWorkers, component);
            if (previousComponent != null) {
                _assignedWorkersComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveAssignedWorkers() {
            var component = assignedWorkers;
            RemoveComponent(MetaGameComponentIds.AssignedWorkers);
            _assignedWorkersComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity assignedWorkersEntity { get { return GetGroup(MetaGameMatcher.AssignedWorkers).GetSingleEntity(); } }

        public AssignedWorkersComponent assignedWorkers { get { return assignedWorkersEntity.assignedWorkers; } }

        public bool hasAssignedWorkers { get { return assignedWorkersEntity != null; } }

        public Entity SetAssignedWorkers(int newCount) {
            if (hasAssignedWorkers) {
                throw new SingleEntityException(MetaGameMatcher.AssignedWorkers);
            }
            var entity = CreateEntity();
            entity.AddAssignedWorkers(newCount);
            return entity;
        }

        public Entity ReplaceAssignedWorkers(int newCount) {
            var entity = assignedWorkersEntity;
            if (entity == null) {
                entity = SetAssignedWorkers(newCount);
            } else {
                entity.ReplaceAssignedWorkers(newCount);
            }

            return entity;
        }

        public void RemoveAssignedWorkers() {
            DestroyEntity(assignedWorkersEntity);
        }
    }
}

    public partial class MetaGameMatcher {
        static AllOfMatcher _matcherAssignedWorkers;

        public static AllOfMatcher AssignedWorkers {
            get {
                if (_matcherAssignedWorkers == null) {
                    _matcherAssignedWorkers = new MetaGameMatcher(MetaGameComponentIds.AssignedWorkers);
                }

                return _matcherAssignedWorkers;
            }
        }
    }
