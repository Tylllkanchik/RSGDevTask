using Content.Features.AIModule.Scripts.Components;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.StorageModule.Scripts;
using System.Linq;
using UnityEngine;

namespace Content.Features.ItemsModule.Scripts.Potion
{
    public class PotionModule
    {
        private PotionItemConfiguration _potionItemConfiguration;

        public PotionModule(ItemsConfiguration itemsConfiguration)
        {
            var configuration = itemsConfiguration.GetItemConfiguration(ItemType.Potion);
            _potionItemConfiguration = configuration as PotionItemConfiguration;
        }

        public void UsePotion(IEntity target)
        {
            if(target.TryGetEntityComponent(out IStorage storage) && target.TryGetEntityComponent(out HealthComponent healthComponent))
            {
                var item = storage.GetAllItems().FirstOrDefault(i => i.ItemType == ItemType.Potion);
                if (item != null)
                {
                    storage.RemoveItem(item);
                    healthComponent.SetHealth(healthComponent.Health + _potionItemConfiguration.HealAmount);
                }
            }
        }
    }
}
