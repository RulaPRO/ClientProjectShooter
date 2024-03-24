using Core.Services.Character.Interfaces;
using UnityEngine;
using Zenject;

namespace Core.AppRunner
{
    public class EntryPoint : IInitializable
    {
        private readonly ICharacterService characterService;

        public EntryPoint(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        public void Initialize()
        {
            characterService.SpawnPlayer(Vector3.zero);
        }
    }
}