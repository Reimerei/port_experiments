using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public StartEndTimeComponent startEndTime { get { return (StartEndTimeComponent)GetComponent(CoreGameComponentIds.StartEndTime); } }

        public bool hasStartEndTime { get { return HasComponent(CoreGameComponentIds.StartEndTime); } }

        static readonly Stack<StartEndTimeComponent> _startEndTimeComponentPool = new Stack<StartEndTimeComponent>();

        public static void ClearStartEndTimeComponentPool() {
            _startEndTimeComponentPool.Clear();
        }

        public Entity AddStartEndTime(System.DateTime newStart, System.DateTime newEnd) {
            var component = _startEndTimeComponentPool.Count > 0 ? _startEndTimeComponentPool.Pop() : new StartEndTimeComponent();
            component.start = newStart;
            component.end = newEnd;
            return AddComponent(CoreGameComponentIds.StartEndTime, component);
        }

        public Entity ReplaceStartEndTime(System.DateTime newStart, System.DateTime newEnd) {
            var previousComponent = hasStartEndTime ? startEndTime : null;
            var component = _startEndTimeComponentPool.Count > 0 ? _startEndTimeComponentPool.Pop() : new StartEndTimeComponent();
            component.start = newStart;
            component.end = newEnd;
            ReplaceComponent(CoreGameComponentIds.StartEndTime, component);
            if (previousComponent != null) {
                _startEndTimeComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveStartEndTime() {
            var component = startEndTime;
            RemoveComponent(CoreGameComponentIds.StartEndTime);
            _startEndTimeComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherStartEndTime;

        public static AllOfMatcher StartEndTime {
            get {
                if (_matcherStartEndTime == null) {
                    _matcherStartEndTime = new CoreGameMatcher(CoreGameComponentIds.StartEndTime);
                }

                return _matcherStartEndTime;
            }
        }
    }
