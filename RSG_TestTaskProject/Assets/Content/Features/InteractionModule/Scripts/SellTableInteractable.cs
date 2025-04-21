using Content.Features.AIModule.Scripts.Components;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.ItemsModule.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.InteractionModule
{
    public class SellTableInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemType _itemType;

        [Inject]
        private IItemFactory _itemFactory;

        public void Interact(IEntity entity)
        {
            if(entity.TryGetEntityComponent(out MoneyComponent moneyComponent))
            {
                var item = _itemFactory.GetItem(_itemType);
                if(moneyComponent.Amount >= item.BuyPrice)
                {
                    if (entity.TryGetEntityComponent(out IStorage storage))
                    {
                        if (storage.TryAddItem(item))
                        {
                            moneyComponent.RemoveMoney(item.BuyPrice);
                        }
                    }
                }
            }
        }
    }
}
