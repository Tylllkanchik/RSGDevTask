using System;
using Content.Features.AIModule.Scripts.Components;
using Content.Features.GameFlowStateMachineModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class MoveToSurfaceEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;
        private EntityTransformComponent _entityTransformComponent;
        private Vector3 _teleportPosition;
        private GameFlowStateMachine _gameFlowStateMachine;

        public event Action OnBehaviorEnd;

        public MoveToSurfaceEntityBehaviour(GameFlowStateMachine gameFlowStateMachine) =>
            _gameFlowStateMachine = gameFlowStateMachine;

        public void InitContext(EntityContext entityContext)
        {
            _entityContext = entityContext;
            if (_entityContext.Entity.TryGetEntityComponent(out EntityTransformComponent entityTransformComponent))
            {
                _entityTransformComponent = entityTransformComponent;
            }
        }

        public void SetTelepotPosition(Vector3 teleportPosition) =>
            _teleportPosition = teleportPosition;

        public void Start() {
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;
        }

        public void Process() {
            if (IsNearTheTarget())
                TeleportToSurface();
            else
                MoveToTarget();
        }

        public void Stop() { }

        private void MoveToTarget() =>
            _entityContext.NavMeshAgent.SetDestination(_teleportPosition);

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget() =>
            Vector3.Distance(_entityTransformComponent.Position, _teleportPosition) <= _entityContext.EntityData.InteractDistance;

        private void TeleportToSurface() {
            _gameFlowStateMachine.Enter<EnterSurfaceFlowState>();
            StopMoving();
            OnBehaviorEnd?.Invoke();
        }
    }
}