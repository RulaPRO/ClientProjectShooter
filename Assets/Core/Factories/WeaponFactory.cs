using Characters;
using Core.Services.Weapon.Implementation;
using UnityEngine;
using Zenject;

namespace Core.Factories
{
    public class WeaponFactory : IFactory<WeaponType, WeaponView>
    {
        private DiContainer diContainer;

        [Inject]
        public WeaponFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public WeaponView Create(WeaponType weaponType)
        {
            var prefab = LoadWeaponPrefab(weaponType);
            var instance = diContainer.InstantiatePrefabForComponent<WeaponView>(prefab);

            return instance;
        }

        private WeaponView LoadWeaponPrefab(WeaponType weaponType)
        {
            return Resources.Load<WeaponView>($"Weapons/WeaponView{weaponType.ToString()}");
        }
    }
}