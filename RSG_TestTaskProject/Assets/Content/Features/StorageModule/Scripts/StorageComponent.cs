using Content.Features.EntityComponentModule.Scripts;
using System;

namespace Content.Features.StorageModule.Scripts
{
    public class StorageComponent : MonoComponent<IStorage>
    {
        public override Type ComponentType => typeof(IStorage);
    }
}
