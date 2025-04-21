using System;
using Content.Features.AIModule.Scripts.Components;
using Content.Features.InteractionModule;
using UnityEngine;

namespace Content.Features.DamageablesModule.Scripts {
    [RequireComponent(typeof(MonoHealthComponent))]
    public class MonoDamageable : MonoBehaviour, IDamageable {
        [SerializeField] private float _startHealth;
        [SerializeField] private DamageableType _damageableType;
        [SerializeField] private AttackInteractable _attackInteractable;

        private MonoHealthComponent _monoHealthComponent;

        public DamageableType DamageableType =>
            _damageableType;
        public bool IsActive =>
            _monoHealthComponent.Component.Health > 0;
        public AttackInteractable Interactable =>
            _attackInteractable;

        public event Action OnDamaged;
        public event Action OnKilled;

        private void Awake()
        {
            _monoHealthComponent = GetComponent<MonoHealthComponent>();
        }

        public void Damage(float damage) {
            _monoHealthComponent.Component.SetHealth(_monoHealthComponent.Component.Health - damage);
            OnDamaged?.Invoke();

            if (_monoHealthComponent.Component.Health > 0)
                return;

            OnKilled?.Invoke();
            Destroy(gameObject);
        }
    }
}