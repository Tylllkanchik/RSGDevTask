using Content.Features.AIModule.Scripts.Entity;
using System;

namespace Content.Features.EntityComponentModule.Scripts
{
    public interface IMonoComponent
    {
        public Type ComponentType { get; }

        public IComponent Component { get; }

        public void Bind(IComponent component);
    }
}
