using Content.Features.AIModule.Scripts.Entity;
using Core.WindowServiceModule.Scripts;
using Global.Scripts.Generated;
using System;
using UnityEngine;
using Zenject;

namespace Content.Features.HudModule.Scripts
{
    public class HudSystem : IInitializable, IDisposable
    {
        private IWindowService _windowService;
        private PlayerEntityModel _playerEntityModel;

        public HudSystem(IWindowService windowService, PlayerEntityModel playerEntityModel)
        {
            _windowService = windowService;
            _playerEntityModel = playerEntityModel;
        }

        public void Initialize()
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
            hud.Init(_playerEntityModel);
            await _windowService.OpenWindow<HudWindow>();

        }
    }
}
