using System;
using Characters;
using Core.Services.Character.Interfaces;
using UnityEngine;

namespace Core.Services.Character.Implementation
{
    public class Character : ICharacter
    {
        public string Sid { get; }
        public CharacterView CharacterView { get; private set; }
        public IHealthService HealthService { get; }

        public Character()
        {
            Sid = Guid.NewGuid().ToString();

            HealthService = new HealthService();
            HealthService.Initialize(100);
        }

        public ICharacter SetView(CharacterView characterView)
        {
            CharacterView = characterView;
            CharacterView.Initialize(Sid);

            return this;
        }

        public ICharacter SetPosition(Vector3 value)
        {
            CharacterView.transform.position = value;

            return this;
        }
    }
}