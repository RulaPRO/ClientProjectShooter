using System;
using System.Collections.Generic;
using System.Linq;
using Balance.AssetsTypes;
using Core.Services.Weapon.Interfaces;
using Zenject;

namespace Core.Services.Weapon.Implementation
{
    public class EnemyWeaponService : IEnemyWeaponService, ITickable, IDisposable
    {
        public event Action<WeaponType> OnWeaponShoot;
        public event Action<WeaponType> OnWeaponSelect;
        
        private Dictionary<WeaponType, IWeapon> weapons = new ();
        
        public WeaponType SelectedWeapon { get; }


        [Inject]
        public EnemyWeaponService(WeaponsConfig weaponsConfig)
        {
            var length = Enum.GetValues(typeof(WeaponType)).Length;
            var range = UnityEngine.Random.Range(1, length);
            var weaponType = (WeaponType)range;
            var weaponConfigAsset = weaponsConfig.GetConfig(weaponType);

            var weapon = new Weapon(weaponConfigAsset);
            weapon.OnWeaponShoot += StartShoot;
            weapons.Add(weaponType, weapon);

            SelectedWeapon = weaponType;
        }

        public List<WeaponType> AvailableWeapons()
        {
            return weapons.Keys.ToList();
        }

        public void Tick()
        {
            TryShoot();
        }

        private void TryShoot()
        {
            weapons[SelectedWeapon].TryShoot();
        }

        private void StartShoot(WeaponType weaponType)
        {
            OnWeaponShoot?.Invoke(SelectedWeapon);
        }

        public void Dispose()
        {
            foreach (var weapon in weapons.Values)
            {
                weapon.OnWeaponShoot -= StartShoot;
            }
        }
    }
}