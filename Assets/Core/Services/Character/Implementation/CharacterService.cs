using System.Collections.Generic;
using Core.Factories;
using Core.Services.Character.Interfaces;
using UnityEngine;
using Zenject;

namespace Core.Services.Character.Implementation
{
    public class CharacterService : ICharacterService
    {
        public Dictionary<string, ICharacter> Characters { get; }

        [Inject]
        public CharacterService(CharacterFactory characterFactory)
        {
            Characters = new Dictionary<string, ICharacter>();

            var character = new Character()
                .SetView(characterFactory.Create("EnemyView"))
                .SetPosition(Vector3.zero);

            Characters.Add(character.Sid, character);
        }
    }
}