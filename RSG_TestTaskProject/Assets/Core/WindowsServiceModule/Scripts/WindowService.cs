using Core.AssetLoaderModule.Core.Scripts;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.WindowServiceModule.Scripts
{
    public class WindowService : MonoBehaviour, IWindowService
    {
        private IAddressablesAssetLoaderService _addressablesAssetLoaderService;

        [SerializeField] private Transform _canvasRoot;

        private Dictionary<string, Window> _loadedWindows = new Dictionary<string, Window>();
        private Dictionary<string, Window> _openedWindows = new Dictionary<string, Window>();

        [Inject]
        public void InjectDependencies(IAddressablesAssetLoaderService addressablesAssetLoaderService)
        {
            _addressablesAssetLoaderService = addressablesAssetLoaderService;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        async UniTask<Window> IWindowService.LoadWindow<T>()
        {
            return await LoadWindow<T>();
        }

        async UniTask<Window> IWindowService.OpenWindow<T>()
        {
            var windowName = nameof(T);
            if (_openedWindows.ContainsKey(windowName))
                return _openedWindows[windowName];

            var window = await LoadWindow<T>();
            
            await window.Open();
            return window;
        }

        async UniTask IWindowService.CloseWindow<T>()
        {
            var windowName = nameof(T);
            if (!_openedWindows.ContainsKey(windowName))
                return;

            var window = _openedWindows[windowName];
            await window.Close();
            _openedWindows.Remove(windowName);
        }

        bool IWindowService.TryGetWindow<T>(out T window)
        {
            window = null;
            var windowName = nameof(T);

            if (_loadedWindows.ContainsKey(windowName))
            {
                window = _loadedWindows[windowName] as T;
                return true;
            }

            return false;
        }

        private async UniTask<Window> LoadWindow<T>() where T : Window
        {
            var windowName = nameof(T);
            if (!_loadedWindows.ContainsKey(windowName))
            {
                var window = await _addressablesAssetLoaderService.LoadAssetAsync<Window>(windowName);
                _loadedWindows.Add(windowName, window);
                return window;
            }
            else
            {
                return _loadedWindows[windowName];
            }
        }
    }
}
