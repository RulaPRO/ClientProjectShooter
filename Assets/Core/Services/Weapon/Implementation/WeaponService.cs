using System;
using System.Collections.Generic;
using Balance.AssetsTypes;
using Core.Services.Input.Interfaces;
using Core.Services.Weapon.Interfaces;
using Zenject;

namespace Core.Services.Weapon.Implementation
{
    public class WeaponService : IWeaponService, IDisposable
    {
        public event Action OnWeaponShoot;
        public event Action<WeaponType> OnWeaponSelect;

        private Dictionary<WeaponType, IWeapon> weapons = new ();

        private WeaponType selectedWeapon;
        private readonly IInputService inputService;


        [Inject]
        public WeaponService(IInputService inputService, WeaponsConfig weaponsConfig)
        {
            this.inputService = inputService;

            inputService.OnFireButtonPressed += TryShoot;
            
            selectedWeapon = WeaponType.ASSAULT_RIFLE;
            
            weapons.Add(WeaponType.ASSAULT_RIFLE, new Weapon(weaponsConfig.GetConfig(WeaponType.ASSAULT_RIFLE)));
        }

        private void TryShoot()
        {
            weapons[selectedWeapon].TryShoot();
        }

        public void TrySelectWeapon(WeaponType weaponType)
        {
            selectedWeapon = weaponType;
        }

        public void Dispose()
        {
            inputService.OnFireButtonPressed -= TryShoot;
        }
    }
}