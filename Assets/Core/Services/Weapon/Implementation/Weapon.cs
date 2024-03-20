using System;
using System.Threading.Tasks;
using Balance.AssetsTypes;
using Core.Services.Weapon.Interfaces;

namespace Core.Services.Weapon.Implementation
{
    public class Weapon : IWeapon
    {
        public event Action OnWeaponShoot;

        private WeaponConfigAsset weaponConfigAsset;
        private WeaponMagazine weaponMagazine;

        private bool isShootingDelay;
        private bool isWeaponReloading;

        public Weapon(WeaponConfigAsset weaponConfigAsset)
        {
            this.weaponConfigAsset = weaponConfigAsset;

            weaponMagazine = new WeaponMagazine(weaponConfigAsset.MagazineSize);
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

            if (weaponMagazine.IsEmpty)
            {
                StartReloadMagazine();

                return;
            }

            weaponMagazine.RemoveOneAmmo();
            StartShotDelay();

            OnWeaponShoot?.Invoke();
        }

        private async void StartShotDelay()
        {
            isShootingDelay = true;

            await Task.Delay(weaponConfigAsset.ShootDelayMs);

            isShootingDelay = false;
        }

        private async void StartReloadMagazine()
        {
            isWeaponReloading = true;

            await Task.Delay(weaponConfigAsset.ReloadTimeMs);

            weaponMagazine = new WeaponMagazine(weaponConfigAsset.MagazineSize);

            isWeaponReloading = false;
        }
    }
}