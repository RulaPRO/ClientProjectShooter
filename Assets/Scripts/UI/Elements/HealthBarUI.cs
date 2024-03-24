using Core.Services.Character.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Elements
{
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Slider healthBarSlider;

        private ICharacterService characterService;

        private IHealthService healthSystem;

        private void OnDestroy()
        {
            healthSystem.OnHealthChange -= UpdateHealthSystemUI;
        }

        [Inject]
        public void Construct(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        public void Initialize(string id)
        {
            healthSystem = characterService.Characters[id].HealthService;
            
            healthBarSlider.maxValue = healthSystem.HealthMax;
            healthBarSlider.value = healthSystem.HealthCurrent;

            healthSystem.OnHealthChange += UpdateHealthSystemUI;
        }

        private void UpdateHealthSystemUI(int healthCurrent)
        {
            healthBarSlider.value = healthCurrent;
        }
    }
}