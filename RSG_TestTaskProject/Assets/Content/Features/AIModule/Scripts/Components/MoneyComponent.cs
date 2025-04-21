using System;

namespace Content.Features.AIModule.Scripts.Components
{
    public class MoneyComponent : IComponent
    {
        public int Amount { get; private set; }

        public Action<int> OnMoneyChanged;

        public void AddMoney(int amount)
        {
            Amount += amount;

            OnMoneyChanged?.Invoke(Amount);
        }

        public void RemoveMoney(int amount)
        {
            Amount -= amount;

            OnMoneyChanged?.Invoke(Amount);
        }
    }
}