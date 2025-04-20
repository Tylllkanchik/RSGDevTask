using Content.Features.AIModule.Scripts.Components;
using Content.Features.PrefabSpawner;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity
{
    public class EntityFactory : IEntityFactory
    {
        private IPrefabsFactory _prefabsFactory;

        [Inject]
        public void InjectDependencies(IPrefabsFactory prefabsFactory)
        {
            _prefabsFactory = prefabsFactory;
        }

        public IEntity CreateEntity(string prefabAddress, List<IComponent> entityComponents)
        {
            GameObject prefabInstance = _prefabsFactory.Create(prefabAddress);
            IEntity entity = prefabInstance.GetComponent<IEntity>();
            entity.Bind(entityComponents);

            return entity;
        }
    }
}
