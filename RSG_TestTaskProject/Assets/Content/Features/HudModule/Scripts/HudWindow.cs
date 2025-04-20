using Content.Features.AIModule.Scripts.Components;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.StorageModule.Scripts;
using Content.Features.WindowsModules.Scripts;
using Core.WindowServiceModule.Scripts;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Content.Features.HudModule.Scripts
{
    public class HudWindow : Window
    {
        [SerializeField] private StorageView _storageView;
        [SerializeField] private MoneyView _moneyComponentView;
        [SerializeField] private HealthView _healthView;

        private PlayerEntityModel _playerEntityModel;

        public void Init(PlayerEntityModel playerEntityModel)
        {
            _playerEntityModel = playerEntityModel;
        }

        public override UniTask Open()
        {
            if(_playerEntityModel.PlayerEntity != null)
            {
                if (_playerEntityModel.PlayerEntity.TryGetEntityComponent(out IStorage storage))
                {
                    _storageView.Init(storage);
                }

                if (_playerEntityModel.PlayerEntity.TryGetEntityComponent(out MoneyComponent moneyComponent))
                {
                    _moneyComponentView.Init(moneyComponent);
                }

                if (_playerEntityModel.PlayerEntity.TryGetEntityComponent(out HealthComponent healthComponent))
                {
                    _healthView.Init(healthComponent);
                }
            }

            return base.Open();
        }

        public override UniTask Close()
        {
            _storageView.Dispose();
            _moneyComponentView.Dispose();
            _healthView.Dispose();
            return base.Close();
        }
    }
}
