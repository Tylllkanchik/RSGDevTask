using Content.Features.AIModule.Scripts.Components;
using Content.Features.StorageModule.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.WindowsModules.Scripts
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;

        private HealthComponent _healthComponent;

        public void Init(HealthComponent healthComponent)
        {
            if (healthComponent == null)
                return;

            _healthComponent = healthComponent;

            _healthSlider.minValue = 0;
            _healthSlider.maxValue = _healthComponent.MaxHealth;

            _healthComponent.OnHealthChanged += HealthChanged;
            HealthChanged(_healthComponent.Health);
        }

        public void Dispose()
        {
            if (_healthComponent != null)
            {
                _healthComponent.OnHealthChanged -= HealthChanged;
            }
        }

        private void HealthChanged(float healthChanged)
        {
            _healthSlider.value = healthChanged;
        }
    }
}
