using System;

namespace Content.Features.AIModule.Scripts.Components
{
    public interface IMonoComponent
    {
        public Type ComponentType { get; }

        public IComponent Component { get; }

        public void Bind(IComponent component);

        public void BindNewComponent();
    }
}
