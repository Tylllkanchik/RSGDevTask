using Content.Features.AIModule.Scripts.Components;
using System.Collections.Generic;

namespace Content.Features.AIModule.Scripts.Entity
{
    public interface IEntityFactory
    {
        public IEntity CreateEntity(string prefabAddress, List<IComponent> entityComponents);
    }
}
