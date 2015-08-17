using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public ResearchComponent research { get { return (ResearchComponent)GetComponent(CoreGameComponentIds.Research); } }

        public bool hasResearch { get { return HasComponent(CoreGameComponentIds.Research); } }

        static readonly Stack<ResearchComponent> _researchComponentPool = new Stack<ResearchComponent>();

        public static void ClearResearchComponentPool() {
            _researchComponentPool.Clear();
        }

        public Entity AddResearch(string newValue) {
            var component = _researchComponentPool.Count > 0 ? _researchComponentPool.Pop() : new ResearchComponent();
            component.value = newValue;
            return AddComponent(CoreGameComponentIds.Research, component);
        }

        public Entity ReplaceResearch(string newValue) {
            var previousComponent = hasResearch ? research : null;
            var component = _researchComponentPool.Count > 0 ? _researchComponentPool.Pop() : new ResearchComponent();
            component.value = newValue;
            ReplaceComponent(CoreGameComponentIds.Research, component);
            if (previousComponent != null) {
                _researchComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveResearch() {
            var component = research;
            RemoveComponent(CoreGameComponentIds.Research);
            _researchComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreGameMatcher {
        static AllOfMatcher _matcherResearch;

        public static AllOfMatcher Research {
            get {
                if (_matcherResearch == null) {
                    _matcherResearch = new CoreGameMatcher(CoreGameComponentIds.Research);
                }

                return _matcherResearch;
            }
        }
    }
