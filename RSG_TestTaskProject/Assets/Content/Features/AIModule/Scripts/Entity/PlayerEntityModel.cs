using Content.Features.MoneyModule.Scripts;
using Content.Features.StorageModule.Scripts;
using System;
using System.Collections.Generic;

namespace Content.Features.AIModule.Scripts.Entity {
    public class PlayerEntityModel {

        private List<IComponent> _playerComponents = new List<IComponent>();
        private IEntity _playerEntity;

        public IEntity PlayerEntity {
            get =>
                _playerEntity;
            set {
                if(_playerEntity == value)
                    return;
                
                _playerEntity = value;
                OnPlayerEntityChanged?.Invoke();
            }
        }

        public List<IComponent> PlayerComponents => _playerComponents;

        public PlayerEntityModel(IStorageFactory storageFactory)
        {
            _playerComponents.Add(storageFactory.GetStorage());
            _playerComponents.Add(new MoneyComponent());
        }

        public event Action OnPlayerEntityChanged;
    }
}