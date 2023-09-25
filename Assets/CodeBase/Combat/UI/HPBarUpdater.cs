using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Combat.UI
{
    public class HpBarUpdater : MonoBehaviour
    {
        public Health.Health health;
        public Slider hpBarSlider;
        private bool _ishealthNotNull;
        private bool _ishpBarSliderNotNull;

        private void Start()
        {
            _ishpBarSliderNotNull = hpBarSlider != null;
            _ishealthNotNull = health != null;
            UpdateHpBar();
        }

        private void Update()
        {
            UpdateHpBar();
        }

        private void UpdateHpBar()
        {
            if (_ishealthNotNull && _ishpBarSliderNotNull)
            {
                hpBarSlider.value = (float)health.HealthValue / health.MaxHealth;
            }
        }
    }
}