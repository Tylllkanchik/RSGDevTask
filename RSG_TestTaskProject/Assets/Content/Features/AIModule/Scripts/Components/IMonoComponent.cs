using System;

namespace Content.Features.AIModule.Scripts.Components
{
    public interface IMonoComponent
    {
        public Type ComponentType { get; }

        public void Bind(IComponent component);

        public IComponent BindNewComponent();
    }
}
