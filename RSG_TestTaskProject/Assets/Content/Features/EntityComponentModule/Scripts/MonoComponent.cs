using Content.Features.AIModule.Scripts.Entity;
using System;
using UnityEngine;

namespace Content.Features.EntityComponentModule.Scripts
{
    public abstract class MonoComponent<T> : MonoBehaviour, IMonoComponent where T : IComponent
    {
        public abstract Type ComponentType { get; } 

        private T _component;

        public IComponent Component => _component;

        public void Bind(IComponent data)
        {
            if (data is T component)
            {
                _component = component;
            }
        }
    }
}
