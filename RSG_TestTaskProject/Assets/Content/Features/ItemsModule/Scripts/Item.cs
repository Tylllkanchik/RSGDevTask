using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.ItemsModule.Scripts {
    public class Item {
        public ItemType ItemType { get; private set; }
        public string Name { get; private set; }
        public Sprite Icon { get; private set; }
        public int Price { get; private set; }
        public float Weight { get; private set; }

        public Item(ItemType itemType, string name, Sprite icon, int price, float weight) {
            ItemType = itemType;
            Name = name;
            Icon = icon;
            Price = price;
            Weight = weight;
        }
    
        public Item(ItemConfiguration itemConfiguration) {
            ItemType = itemConfiguration.ItemType;
            Name = itemConfiguration.Name;
            Icon = itemConfiguration.Icon;
            Price = itemConfiguration.Price;
            Weight = itemConfiguration.Weight;
        }
    }
}