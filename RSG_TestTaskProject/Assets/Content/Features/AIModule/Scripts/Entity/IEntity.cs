using Content.Features.EntityComponentModule.Scripts;
using System.Collections.Generic;

namespace Content.Features.AIModule.Scripts.Entity {
    public interface IEntity {
        public void Bind(List<IComponent> components);
        public bool TryGetEntityComponent<T>(out T component) where T : IComponent;
        public void SetBehaviour(IEntityBehaviour entityBehaviour);
    }
}