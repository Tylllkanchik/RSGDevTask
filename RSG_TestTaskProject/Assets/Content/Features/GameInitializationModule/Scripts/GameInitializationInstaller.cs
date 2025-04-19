using Zenject;
using Content.Features.HudModule.Scripts;

namespace Content.Features.GameInitializationModule
{
    public class GameInitializationInstaller : Installer<GameInitializationInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HudSystem>()
                     .AsSingle();
        }
    }
}
