using Content.Features.StorageModule.Scripts;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Content.Features.ItemsModule.Scripts;
using TMPro;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.ItemsModule.Scripts.Potion;
using Core.InputModule;

namespace Content.Features.WindowsModules.Scripts
{
    public class PotionsView : MonoBehaviour
    {
        [SerializeField] private Button _potionButton;
        [SerializeField] private TextMeshProUGUI _potionsCount;

        private IStorage _storage;
        private PotionModule _potionsModule;
        private PlayerEntityModel _playerEntityModel;
        private IInputListener _inputListener;

        public void Init(IStorage storage, PotionModule potionModule, PlayerEntityModel playerEntityModel, IInputListener inputListener)
        {
            if (storage == null)
                return;

            _playerEntityModel = playerEntityModel;
            _potionsModule = potionModule;
            _storage = storage;
            _inputListener = inputListener;

            _storage.OnItemAdded += StorageItemsCountChanged;
            _storage.OnItemRemoved += StorageItemsCountChanged;
            _storage.OnStorageCleared += HealButtonIntectionChanged;

            HealButtonIntectionChanged();
            _potionButton.onClick.AddListener(UsePotion);
            _inputListener.OnUsePotionPerformed += UsePotion;
        }

        public void Dispose()
        {
            if (_storage != null)
            {
                _storage.OnItemAdded -= StorageItemsCountChanged;
                _storage.OnItemRemoved -= StorageItemsCountChanged;
                _storage.OnStorageCleared -= HealButtonIntectionChanged;
            }

            if(_inputListener != null)
                _inputListener.OnUsePotionPerformed -= UsePotion;
            _potionButton.onClick.RemoveListener(UsePotion);
        }

        public void UsePotion()
        {
            _potionsModule.UsePotion(_playerEntityModel.PlayerEntity);
        }

        private void StorageItemsCountChanged(Item item)
        {
            HealButtonIntectionChanged();
        }

        private void HealButtonIntectionChanged()
        {
            int potionsCount = _storage.GetAllItems().Count(i => i.ItemType == ItemType.Potion);
            _potionButton.interactable = potionsCount > 0;
            _potionsCount.text = potionsCount.ToString();
        }
    }
}
