using System;
using Content.Features.AIModule.Scripts.Components;
using Content.Features.LootModule.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class GatherLootEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;
        private Loot _loot;
        private ILootService _lootService;
        private EntityTransformComponent _entityTransformComponent;

        public event Action OnBehaviorEnd;

        public GatherLootEntityBehaviour(ILootService lootService) =>
            _lootService = lootService;

        public void InitContext(EntityContext entityContext)
        {
            _entityContext = entityContext;
            if (_entityContext.Entity.TryGetEntityComponent(out EntityTransformComponent entityTransformComponent))
            {
                _entityTransformComponent = entityTransformComponent;
            }
        }

        public void SetLoot(Loot loot) =>
            _loot = loot;

        public void Start() {
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;
        }

        public void Process() {
            if(IsNearTheTarget())
                CollectLoot();
            else
                MoveToTarget();
        }

        public void Stop() { }

        private void MoveToTarget() =>
            _entityContext.NavMeshAgent.SetDestination(_loot.transform.position);

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget() =>
            Vector3.Distance(_entityTransformComponent.Position, _loot.transform.position) <= _entityContext.EntityData.InteractDistance;

        private void CollectLoot() {
            if (_entityContext.Entity.TryGetEntityComponent(out IStorage storage))
            {
                _lootService.CollectLoot(_loot, storage);
                _loot.DestroyLoot();
                StopMoving();
                OnBehaviorEnd?.Invoke();
            }
        }
    }
}