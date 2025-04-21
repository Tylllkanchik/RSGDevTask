using System;

namespace Content.Features.AIModule.Scripts.Components
{
    public class HealthComponent : IComponent
    {
        public float Health { get; private set; }
        public float MaxHealth { get; private set; }

        public event Action<float> OnHealthChanged;

        public HealthComponent(float maxHealth)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
        }

        public void SetHealth(float health)
        {
            Health = health;
            OnHealthChanged?.Invoke(Health);
        }
    }
}