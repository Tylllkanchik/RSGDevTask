using Content.Features.ItemsModule.Scripts;
using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using Zenject;

namespace Content.Features.StorageModule.Scripts {
    public class StorageModuleInstaller : Installer<StorageModuleInstaller> {
        public override void InstallBindings() {
            IAddressablesAssetLoaderService addressablesAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();

            Container.Bind<StoragesConfiguration>()
                .FromScriptableObject(addressablesAssetLoaderService.LoadAsset<StoragesConfiguration>(Address.Configurations.StoragesConfiguration_Default))
                .AsSingle();
        
            Container.Bind<IStorageFactory>()
                .To<StorageFactory>()
                .AsSingle();
        }
    }
}