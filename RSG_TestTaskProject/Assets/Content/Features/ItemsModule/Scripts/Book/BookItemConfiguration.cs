using Content.Features.ItemsModule.Scripts.Potion;
using UnityEngine;

namespace Content.Features.ItemsModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Inventory/" + nameof(BookItemConfiguration),
        fileName = nameof(BookItemConfiguration) + "_Default", order = 0)]
    public class BookItemConfiguration : ItemConfiguration
    {

    }
}
