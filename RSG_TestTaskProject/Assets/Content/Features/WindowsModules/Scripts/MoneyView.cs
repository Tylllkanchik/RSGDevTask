using Content.Features.AIModule.Scripts.Components;
using Content.Features.StorageModule.Scripts;
using TMPro;
using UnityEngine;

namespace Content.Features.WindowsModules.Scripts
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyAmountText;

        private MoneyComponent _moneyComponent;

        public void Init(MoneyComponent moneyComponent)
        {
            if (moneyComponent == null)
                return;

            _moneyComponent = moneyComponent;

            _moneyComponent.OnMoneyChanged += MoneyAmountChanged;
            MoneyAmountChanged(_moneyComponent.Amount);
        }

        public void Dispose()
        {
            _moneyAmountText.text = string.Empty;
            if (_moneyComponent != null)
            {
                _moneyComponent.OnMoneyChanged -= MoneyAmountChanged;
            }
        }

        private void MoneyAmountChanged(int moneyAmount)
        {
            _moneyAmountText.text = "Money: " + moneyAmount;
        }
    }
}
