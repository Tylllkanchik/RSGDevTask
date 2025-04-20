using Content.Features.AIModule.Scripts.Components;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.ItemsModule.Scripts.Potion;
using Content.Features.StorageModule.Scripts;
using Content.Features.WindowsModules.Scripts;
using Core.InputModule;
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
        [SerializeField] private PotionsView _potionsView;

        private PlayerEntityModel _playerEntityModel;
        private PotionModule _potionModule;
        private IInputListener _inputListener;

        public void Init(PlayerEntityModel playerEntityModel, PotionModule potionModule, IInputListener inputListener)
        {
            Dispose();
            _playerEntityModel = playerEntityModel;
            _potionModule = potionModule;
            _inputListener = inputListener;

            if (_playerEntityModel.PlayerEntity != null)
            {
                if (_playerEntityModel.PlayerEntity.TryGetEntityComponent(out IStorage storage))
                {
                    _storageView.Init(storage);
                    _potionsView.Init(storage, _potionModule, _playerEntityModel, _inputListener);
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
        }

        public override UniTask Open()
        {
            return base.Open();
        }

        public override UniTask Close()
        {
            Dispose();
            return base.Close();
        }

        private void Dispose()
        {
            _storageView.Dispose();
            _moneyComponentView.Dispose();
            _healthView.Dispose();
            _potionsView.Dispose();
        }
    }
}
