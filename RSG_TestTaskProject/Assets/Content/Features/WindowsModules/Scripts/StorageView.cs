using Content.Features.StorageModule.Scripts;
using TMPro;
using UnityEngine;
using System;
using Content.Features.ItemsModule.Scripts;

namespace Content.Features.WindowsModules.Scripts
{
    public class StorageView : MonoBehaviour, IDisposable
    {
        [SerializeField] private TextMeshProUGUI _storageItemsCountText;

        private IStorage _storage;

        public void Init(IStorage storage)
        {
            if (storage == null)
                return;

            _storage = storage;

            _storage.OnItemAdded += StorageItemsCountChanged;
            _storage.OnItemRemoved += StorageItemsCountChanged;
            _storage.OnStorageCleared += UpdateItemsCountText;
            UpdateItemsCountText();
        }

        public void Dispose()
        {
            _storageItemsCountText.text = string.Empty;
            if(_storage != null)
            {
                _storage.OnItemAdded -= StorageItemsCountChanged;
                _storage.OnItemRemoved -= StorageItemsCountChanged;
                _storage.OnStorageCleared -= UpdateItemsCountText;
            }
        }

        private void StorageItemsCountChanged(Item item)
        {
            UpdateItemsCountText();
        }

        private void UpdateItemsCountText()
        {
            _storageItemsCountText.text = "Items count: " + _storage.GetAllItems().Count + " Weignt: " + _storage.StorageWeight + "/" + _storage.MaxStorageWeight;
        }
    }
}
