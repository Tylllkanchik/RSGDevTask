using Content.Features.EntityComponentModule.Scripts;
using System;

namespace Content.Features.MoneyModule.Scripts
{
    public class MonoMoneyComponent : MonoComponent<MoneyComponent>
    {
        public override Type ComponentType => typeof(MoneyComponent);
    }
}
