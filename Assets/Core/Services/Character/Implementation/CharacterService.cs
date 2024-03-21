using System.Collections.Generic;
using Core.Factories;
using Core.Services.Character.Interfaces;
using UnityEngine;
using Zenject;

namespace Core.Services.Character.Implementation
{
    public class CharacterService : ICharacterService
    {
        private CharacterFactory characterFactory;

        public Dictionary<string, ICharacter> Characters { get; }

        [Inject]
        public CharacterService(CharacterFactory characterFactory)
        {
            this.characterFactory = characterFactory;

            Characters = new Dictionary<string, ICharacter>();
        }

        public ICharacter SpawnEnemy(Vector3 position)
        {
            var character = new Character();
            Characters.Add(character.Sid, character);

            character
                .SetView(characterFactory.Create("EnemyCharacterView"))
                .SetPosition(position);

            return character;
        }
    }
}