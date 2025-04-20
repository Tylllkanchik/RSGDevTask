using Content.Features.ItemsModule.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Content.Features.StorageModule.Scripts {
    public class StandardStorage : IStorage {
        
        private List<Item> _items = new List<Item>();
        private float _storageWeight = 0f;
        private float _maxStorageWeight = 0f;

        public float StorageWeight => _storageWeight;
        public float MaxStorageWeight => _maxStorageWeight;

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;
        public event Action OnStorageCleared;

        public StandardStorage(StandardStorageConfiguration standardStorageConfiguration) 
        {
            _maxStorageWeight = standardStorageConfiguration.MaxStorageWeight;
        }

        public List<Item> GetAllItems() =>
            _items.ToList();

        public bool TryAddItem(Item item)
        {
            if (_items.Contains(item))
                return false;

            float newStorageWeight = _storageWeight + item.Weight;
            if(newStorageWeight <= _maxStorageWeight)
            {
                _storageWeight = newStorageWeight;
                _items.Add(item);
                OnItemAdded?.Invoke(item);
            }

            return false;
        }

        public void RemoveItem(Item item) {
            if(_items.Contains(item) is false)
                return;

            _storageWeight -= item.Weight;
            _items.Remove(item);
            OnItemRemoved?.Invoke(item);
        }

        public void RemoveItems(List<Item> items) {
            foreach (Item item in items)
                RemoveItem(item);
        }

        public void RemoveAllItems() {
            _items.Clear();
            _storageWeight = 0;
            OnStorageCleared?.Invoke();
        }
    }
}