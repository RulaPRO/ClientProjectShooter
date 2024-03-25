using System;
using Core.Services.Character.Implementation;
using Core.Services.Character.Interfaces;
using UI.Elements;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterView : MonoBehaviour, IDamageable
    {
        [SerializeField] private CharacterUI characterUI;

        private ICharacterService characterService;

        private string characterId;

        [Inject]
        public void Construct(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        private void OnDestroy()
        {
            characterService.Characters[characterId].HealthService.OnHealthEnd -= OnHealthEnd;
        }

        public void Initialize(string id)
        {
            characterId = id;

            characterService.Characters[characterId].HealthService.OnHealthEnd += OnHealthEnd;
            characterUI.Initialize(id);
        }

        public CharacterFractionType Fraction => characterService.Characters[characterId].Fraction;

        public void ApplyDamage(int value)
        {
            characterService.Characters[characterId].HealthService.DecreaseHealth(value);
        }

        private void OnHealthEnd()
        {
            Destroy(gameObject);
        }
    }
}