using System;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Components
{
    public class MonoHealthComponent : MonoComponent<HealthComponent>
    {
        [SerializeField] private float _startHealth = 10;

        public override Type ComponentType => typeof(HealthComponent);

        protected override HealthComponent CreateNewComponent()
        {
            return new HealthComponent(_startHealth);
        }
    }
}
