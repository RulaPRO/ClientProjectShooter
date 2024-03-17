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

        public Character()
        {
            Sid = Guid.NewGuid().ToString();
        }

        public ICharacter SetView(CharacterView characterView)
        {
            CharacterView = characterView;

            return this;
        }

        public ICharacter SetPosition(Vector3 value)
        {
            CharacterView.transform.position = value;

            return this;
        }
    }
}