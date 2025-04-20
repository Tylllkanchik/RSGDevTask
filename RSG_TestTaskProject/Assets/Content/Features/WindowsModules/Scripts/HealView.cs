using Content.Features.StorageModule.Scripts;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Content.Features.WindowsModules.Scripts
{
    public class HealView : MonoBehaviour
    {
        [SerializeField] private Button _healButton;

        private IStorage _storage;

        public void Init(IStorage storage)
        {
            if (storage == null)
                return;
            _storage = storage;

            _storage.OnItemAdded += StorageItemsCountChanged;
            _storage.OnItemRemoved += StorageItemsCountChanged;
            _storage.OnStorageCleared += HealButtonIntectionChanged;
            HealButtonIntectionChanged();
        }

        public void Dispose()
        {
            if (_storage != null)
            {
                _storage.OnItemAdded -= StorageItemsCountChanged;
                _storage.OnItemRemoved -= StorageItemsCountChanged;
                _storage.OnStorageCleared -= HealButtonIntectionChanged;
            }
        }

        public void UsePotion()
        {

        }

        private void StorageItemsCountChanged(Item item)
        {
            HealButtonIntectionChanged();
        }

        private void HealButtonIntectionChanged()
        {
            int potionsCount = _storage.GetAllItems().Count(i => i.ItemType == ItemType.Potion);
            _healButton.interactable = potionsCount > 0;
        }
    }
}
