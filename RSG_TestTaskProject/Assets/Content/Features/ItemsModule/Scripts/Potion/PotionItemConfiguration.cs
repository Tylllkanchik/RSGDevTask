using UnityEngine;

namespace Content.Features.ItemsModule.Scripts.Potion
{
    [CreateAssetMenu(menuName = "Configurations/Inventory/" + nameof(PotionItemConfiguration),
    fileName = nameof(PotionItemConfiguration) + "_Default", order = 0)]
    public class PotionItemConfiguration : ItemConfiguration
    {
        public float HealAmount;
    }
}
