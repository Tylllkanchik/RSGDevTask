using Content.Features.PrefabSpawner;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity
{
    public class EntityFactoryInstaller : Installer<EntityFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EntityFactory>()
                     .AsSingle();
        }
    }
}
