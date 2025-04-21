using Content.Features.AIModule.Scripts.Entity;
using Core.AssetLoaderModule.Core.Scripts;
using Core.WindowServiceModule.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Core.WindowServiceModule
{
    public class WindowServiceInstaller : Installer<WindowServiceInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            var asset = addressablesAssetLoaderService.LoadAsset<GameObject>(Address.Windows.WindowService);

            var windowServiceGameObject = GameObject.Instantiate(asset);
            Container.InjectGameObject(windowServiceGameObject);
            var windowService = windowServiceGameObject.GetComponent<WindowService>();

            Container.Bind<IWindowService>()
                .FromInstance(windowService)
                .AsSingle();
        }
    }
}