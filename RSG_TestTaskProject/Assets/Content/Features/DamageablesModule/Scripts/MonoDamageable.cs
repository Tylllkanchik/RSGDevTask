using System;
using Content.Features.AIModule.Scripts.Components;
using Content.Features.InteractionModule;
using UnityEngine;

namespace Content.Features.DamageablesModule.Scripts {
    public class MonoDamageable : MonoComponent<HealthComponent>, IDamageable {
        [SerializeField] private DamageableType _damageableType;
        [SerializeField] private AttackInteractable _attackInteractable;
    
        public DamageableType DamageableType =>
            _damageableType;
        public bool IsActive =>
            _component.Health > 0;
        public AttackInteractable Interactable =>
            _attackInteractable;

        public override Type ComponentType => typeof(HealthComponent);

        public event Action OnDamaged;
        public event Action OnKilled;

        public void Damage(float damage) {
            _component.SetHealth(_component.Health - damage);
            OnDamaged?.Invoke();

            if (_component.Health > 0)
                return;

            OnKilled?.Invoke();
            Destroy(gameObject);
        }

        protected override HealthComponent CreateNewComponent()
        {
            return new HealthComponent(100);
        }
    }
}