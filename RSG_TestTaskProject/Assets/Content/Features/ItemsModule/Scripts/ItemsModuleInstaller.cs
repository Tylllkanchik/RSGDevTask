using Content.Features.ItemsModule.Scripts.Potion;
using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using Zenject;

namespace Content.Features.ItemsModule.Scripts
{
    public class ItemsModuleInstaller : Installer<ItemsModuleInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            Container.Bind<ItemsConfiguration>()
                .FromScriptableObject(addressablesAssetLoaderService.LoadAsset<ItemsConfiguration>(Address.Configurations.ItemsConfiguration_Default))
                .AsSingle();

            Container.Bind<IItemFactory>()
                .To<ItemFactory>()
                .AsSingle();

            Container.Bind<PotionModule>()
                .AsSingle();
        }
    }
}