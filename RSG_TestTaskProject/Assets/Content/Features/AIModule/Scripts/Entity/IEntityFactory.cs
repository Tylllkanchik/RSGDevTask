using System.Collections.Generic;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity
{
    public interface IEntityFactory
    {
        public IEntity CreateEntity(string prefabAddress, List<IComponent> entityComponents);
    }
}
