using System;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.ItemsModule.Scripts {
    public class ItemConfiguration : ScriptableObject {
        public ItemType ItemType;
        public string Name;
        public Sprite Icon;
        public int SellPrice;
        public float Weight;
        public int BuyPrice;
    }
}