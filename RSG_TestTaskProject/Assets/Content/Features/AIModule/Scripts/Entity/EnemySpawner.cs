using Content.Features.AIModule.Scripts.Components;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.PlayerData.Scripts;
using Content.Features.PrefabSpawner;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.LootModule.Scripts {
    public class EnemySpawner : MonoBehaviour {
        private IEntityFactory _entityFactory;
        private IEntityDataService _entityDataService;

        [Inject]
        public void InjectDependencies(IEntityFactory entityFactory, IEntityDataService entityDataService)
        {
            _entityFactory = entityFactory;
            _entityDataService = entityDataService;
        }

        private void Start()
        {
            var enemyComponents = new System.Collections.Generic.List<AIModule.Scripts.Components.IComponent>();
            EntityTransformComponent entityTransformComponent = new EntityTransformComponent(transform.position, Quaternion.identity);
            HealthComponent healthComponent = new HealthComponent(_entityDataService.GetEntityData(EntityType.Enemy).StartHealth);

            enemyComponents.Add(entityTransformComponent);
            enemyComponents.Add(healthComponent);

            var enemy = _entityFactory.CreateEntity(Address.Prefabs.Standard_Enemy, enemyComponents);
        }
    }
}