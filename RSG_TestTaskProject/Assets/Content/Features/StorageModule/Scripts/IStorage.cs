using Content.Features.AIModule.Scripts.Components;
using Content.Features.ItemsModule.Scripts;
using System;
using System.Collections.Generic;

namespace Content.Features.StorageModule.Scripts {
    public interface IStorage : IComponent {
        public float StorageWeight { get; }
        public float MaxStorageWeight { get; }

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;
        public event Action OnStorageCleared;

        public List<Item> GetAllItems();
    
        public bool TryAddItem(Item item);

        public void RemoveItem(Item item);
        public void RemoveItems(List<Item> items);
        public void RemoveAllItems();
    }
}