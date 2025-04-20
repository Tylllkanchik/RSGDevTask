using System;
using Content.Features.AIModule.Scripts.Components;
using Content.Features.ShopModule.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class SellItemsEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;
        private EntityTransformComponent _entityTransformComponent;
        private Trader _trader;
        
        public event Action OnBehaviorEnd;
        public void InitContext(EntityContext entityContext)
        {
            _entityContext = entityContext;
            if (_entityContext.Entity.TryGetEntityComponent(out EntityTransformComponent entityTransformComponent))
            {
                _entityTransformComponent = entityTransformComponent;
            }
        }
        
        public void SetTrader(Trader trader) =>
            _trader = trader;

        public void Start() =>
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;

        public void Process() {
            if(IsNearTheTarget())
                SellItems();
            else
                MoveToTarget();
        }

        public void Stop() { }

        private void MoveToTarget() =>
            _entityContext.NavMeshAgent.SetDestination(_trader.transform.position);

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget() =>
            Vector3.Distance(_entityTransformComponent.Position, _trader.transform.position) <= _entityContext.EntityData.InteractDistance;

        private void SellItems() {
            if (_entityContext.Entity.TryGetEntityComponent(out IStorage storage) && _entityContext.Entity.TryGetEntityComponent(out MoneyComponent moneyComponent))
            {
                var sum = _trader.SellAllItemsFromStorage(storage);
                moneyComponent.AddMoney(sum);
                StopMoving();
                OnBehaviorEnd?.Invoke();
            }
        }
    }
}