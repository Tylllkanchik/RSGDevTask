using Content.Features.AIModule.Scripts.Entity;
using Content.Features.PlayerData.Scripts;
using Content.Features.PrefabSpawner;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.LootModule.Scripts {
    public class PlayerSpawner : MonoBehaviour {
        private IEntityFactory _entityFactory;
        private IPrefabsFactory _prefabsFactory;
        private PlayerEntityModel _playerEntityModel;
        private PlayerTransformModel _playerTransformModel;

        [Inject]
        public void InjectDependencies(IPrefabsFactory prefabsFactory, IEntityFactory entityFactory, PlayerEntityModel playerEntityModel, PlayerTransformModel playerTransformModel) {
            _playerEntityModel = playerEntityModel;
            _prefabsFactory = prefabsFactory;
            _entityFactory = entityFactory;
            _playerTransformModel = playerTransformModel;
        }

        private void Start() {
            var playerEntity = _entityFactory.CreateEntity(Address.Prefabs.Player, _playerEntityModel.PlayerComponents);
            _playerEntityModel.PlayerEntity = playerEntity;
            _playerTransformModel.Position = transform.position;
            _prefabsFactory.Create(Address.Prefabs.PlayerCamera);
        }
    }
}