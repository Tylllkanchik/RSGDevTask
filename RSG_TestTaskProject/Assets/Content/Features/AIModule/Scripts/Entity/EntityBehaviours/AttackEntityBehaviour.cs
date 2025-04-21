using System;
using Content.Features.AIModule.Scripts.Components;
using Content.Features.DamageablesModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class AttackEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;
        private EntityTransformComponent _entityTransformComponent;
        private EntityTransformComponent _targetTransformComponent;
        private IDamageable _targetDamageable;

        public event Action OnBehaviorEnd;

        public void InitContext(EntityContext entityContext)
        {
            _entityContext = entityContext;
            if (_entityContext.Entity.TryGetEntityComponent(out EntityTransformComponent entityTransformComponent))
            {
                _entityTransformComponent = entityTransformComponent;
            }
        }

        public void SetTarget(MonoEntity monoEntity)
        {
            _targetDamageable = monoEntity.GetComponent<IDamageable>();
            if (monoEntity.TryGetEntityComponent(out EntityTransformComponent entityTransformComponent))
            {
                _targetTransformComponent = entityTransformComponent;
            }
        }
        
        public void Start() {
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;
            _entityContext.EntityAnimator.OnAttackTriggered += OnAttackTriggered;
        }

        public void Process() {
            if(_targetDamageable.IsActive is false) {
                OnBehaviorEnd?.Invoke();
                return;
            }

            if(IsNearTheTarget())
                StartAttacking();
            else
                MoveToTarget();
        }

        public void Stop() =>
            _entityContext.EntityAnimator.OnAttackTriggered -= OnAttackTriggered;

        private void MoveToTarget() {
            if(_targetDamageable.IsActive is false)
                return;
            
            _entityContext.EntityAnimator.SetIsAttacking(false);
            _entityContext.NavMeshAgent.SetDestination(_targetTransformComponent.Position);
        }

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget() {
            if (_targetDamageable.IsActive is false)
                return false;
            
            return Vector3.Distance(_entityTransformComponent.Position, _targetTransformComponent.Position) <= _entityContext.EntityData.AttackDistance;
        }

        private void StartAttacking() {
            _entityContext.EntityAnimator.SetIsAttacking(true);
            StopMoving();
        }

        private void OnAttackTriggered() =>
            _targetDamageable.Damage(_entityContext.EntityData.Damage);
    }
}