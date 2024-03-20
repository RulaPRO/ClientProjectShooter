using System;
using System.Collections.Generic;
using System.Linq;
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

        public WeaponType SelectedWeapon => selectedWeapon;

        [Inject]
        public WeaponService(
            IInputService inputService,
            PlayerConfigAsset playerConfig,
            WeaponsConfig weaponsConfig)
        {
            this.inputService = inputService;

            inputService.OnFireButtonPressed += TryShoot;
            inputService.OnButton1Down += TrySelectPistol;
            inputService.OnButton2Down += TrySelectShotgun;
            inputService.OnButton3Down += TrySelectAssaultRiffle;

            foreach (var weaponType in playerConfig.StartWeapons)
            {
                weapons.Add(weaponType, new Weapon(weaponsConfig.GetConfig(weaponType)));
            }

            selectedWeapon = playerConfig.StartWeapons.First();
        }

        public List<WeaponType> AvailableWeapons()
        {
            return weapons.Keys.ToList();
        }

        public void Dispose()
        {
            inputService.OnFireButtonPressed -= TryShoot;
            inputService.OnButton1Down -= TrySelectPistol;
            inputService.OnButton2Down -= TrySelectShotgun;
            inputService.OnButton3Down -= TrySelectAssaultRiffle;
        }

        private void TryShoot()
        {
            if (weapons[selectedWeapon].TryShoot())
            {
                OnWeaponShoot?.Invoke();
            }
        }

        private void TrySelectWeapon(WeaponType weaponType)
        {
            selectedWeapon = weaponType;
            
            OnWeaponSelect?.Invoke(weaponType);
        }

        private void TrySelectPistol()
        {
            TrySelectWeapon(WeaponType.Pistol);
        }

        private void TrySelectShotgun()
        {
            TrySelectWeapon(WeaponType.Shotgun);
        }

        private void TrySelectAssaultRiffle()
        {
            TrySelectWeapon(WeaponType.AssaultRifle);
        }
    }
}