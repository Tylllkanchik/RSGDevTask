using Content.Features.AIModule.Scripts.Entity;
using Content.Features.ItemsModule.Scripts.Potion;
using Core.InputModule;
using Core.WindowServiceModule.Scripts;
using System;
using UnityEngine.InputSystem.HID;
using Zenject;

namespace Content.Features.HudModule.Scripts
{
    public class HudSystem : IInitializable, IDisposable
    {
        private IWindowService _windowService;
        private PlayerEntityModel _playerEntityModel;
        private PotionModule _potionModule;
        private IInputListener _inputListener;

        public HudSystem(IWindowService windowService, PlayerEntityModel playerEntityModel, PotionModule potionModule, IInputListener inputListener)
        {
            _windowService = windowService;
            _playerEntityModel = playerEntityModel;
            _potionModule = potionModule;
            _inputListener = inputListener;
        }

        public async void Initialize()
        {
            _playerEntityModel.OnPlayerEntityChanged += PlayerEntityChanged;
        }

        public void Dispose()
        {
            _windowService.CloseWindow<HudWindow>();
            _playerEntityModel.OnPlayerEntityChanged -= PlayerEntityChanged;
        }

        private async void PlayerEntityChanged()
        {
            var hud = await _windowService.LoadWindow<HudWindow>();
            hud.Init(_playerEntityModel, _potionModule, _inputListener);
            await _windowService.OpenWindow<HudWindow>();
        }
    }
}
