using Characters;
using UnityEngine;
using Zenject;

namespace Core.Factories
{
    public class WeaponFactory : IFactory<string, WeaponView>
    {
        private DiContainer diContainer;

        [Inject]
        public WeaponFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public WeaponView Create(string id)
        {
            var prefab = LoadWeaponPrefab(id);
            var instance = diContainer.InstantiatePrefabForComponent<WeaponView>(prefab);

            return instance;
        }

        private WeaponView LoadWeaponPrefab(string id)
        {
            return Resources.Load<WeaponView>($"Weapons/{id}");
        }
    }
}