using System;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Components
{
    public abstract class MonoComponent<T> : MonoBehaviour, IMonoComponent where T : IComponent
    {
        public abstract Type ComponentType { get; } 

        protected T _component;

        public IComponent Component => _component;

        public void Bind(IComponent data)
        {
            if (data is T component)
            {
                _component = component;
                DataBinded();
            }
        }

        public void BindNewComponent()
        {
            Bind(CreateNewComponent());
        }

        protected abstract T CreateNewComponent();

        protected virtual void DataBinded()
        {

        }
    }
}
