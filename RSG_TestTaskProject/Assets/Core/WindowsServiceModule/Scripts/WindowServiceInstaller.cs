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

            Container.Bind<IWindowService>()
                .FromInstance(GameObject.Instantiate(asset).GetComponent<WindowService>())
                .AsSingle();
        }
    }
}