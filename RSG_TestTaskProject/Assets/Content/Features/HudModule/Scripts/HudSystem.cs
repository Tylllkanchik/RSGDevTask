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

        public HudSystem(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Initialize()
        {
            _windowService.OpenWindow<HudWindow>();
        }

        public void Dispose()
        {
            _windowService.CloseWindow<HudWindow>();
        }
    }
}
