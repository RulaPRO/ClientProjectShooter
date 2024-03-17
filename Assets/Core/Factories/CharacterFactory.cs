using Characters;
using UnityEngine;
using Zenject;

namespace Core.Factories
{
    public class CharacterFactory : IFactory<string, CharacterView>
    {
        private DiContainer diContainer;

        [Inject]
        public CharacterFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public CharacterView Create(string id)
        {
            var prefab = LoadCharacterPrefab(id);
            var instance = diContainer.InstantiatePrefabForComponent<CharacterView>(prefab);

            return instance;
        }

        private CharacterView LoadCharacterPrefab(string id)
        {
            return Resources.Load<CharacterView>($"Characters/{id}");
        }
    }
}