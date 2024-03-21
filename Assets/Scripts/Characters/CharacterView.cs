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

        public void Initialize(string id)
        {
            characterId = id;
            
            characterUI.Initialize(id);
        }

        public void ApplyDamage(int value)
        {
            characterService.Characters[characterId].Health.DecreaseHealth(value);
        }
    }
}