using System;
using System.Threading.Tasks;
using Balance.AssetsTypes;
using Core.Services.Weapon.Interfaces;

namespace Core.Services.Weapon.Implementation
{
    public class Weapon : IWeapon
    {
        public event Action<WeaponType> OnWeaponShoot;

        public WeaponConfigAsset WeaponConfigAsset { get; }
        public IWeaponMagazine WeaponMagazine { get; private set; }

        private bool isShootingDelay;
        private bool isWeaponReloading;

        public Weapon(WeaponConfigAsset weaponConfigAsset)
        {
            WeaponConfigAsset = weaponConfigAsset;
            WeaponMagazine = new WeaponMagazine(weaponConfigAsset.MagazineSize);
        }

        public void TryShoot()
        {
            if (isShootingDelay)
            {
                return;
            }

            if (isWeaponReloading)
            {
                return;
            }

            if (WeaponMagazine.IsEmpty)
            {
                StartReloadMagazine();

                return;
            }

            WeaponMagazine.RemoveOneAmmo();
            StartShotDelay();

            OnWeaponShoot?.Invoke(WeaponConfigAsset.WeaponType);
        }

        private async void StartShotDelay()
        {
            isShootingDelay = true;

            await Task.Delay(WeaponConfigAsset.ShootDelayMs);

            isShootingDelay = false;
        }

        private async void StartReloadMagazine()
        {
            isWeaponReloading = true;

            await Task.Delay(WeaponConfigAsset.ReloadTimeMs);

            WeaponMagazine = new WeaponMagazine(WeaponConfigAsset.MagazineSize);

            isWeaponReloading = false;
        }
    }
}