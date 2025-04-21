using System;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Components
{
    public abstract class MonoComponent<T> : MonoBehaviour, IMonoComponent where T : IComponent
    {
        protected T _component;

        public abstract Type ComponentType { get; }
        public T Component => _component;

        public event Action OnComponentBind;

        public void Bind(IComponent data)
        {
            if (data is T component)
            {
                _component = component;
                DataBinded();
            }
        }

        public IComponent BindNewComponent()
        {
            Bind(CreateNewComponent());
            return _component;
        }

        protected abstract T CreateNewComponent();

        protected virtual void DataBinded()
        {

        }
    }
}
