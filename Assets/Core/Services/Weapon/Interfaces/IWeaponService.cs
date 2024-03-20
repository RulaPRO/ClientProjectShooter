using System;
using Core.Services.Weapon.Implementation;

namespace Core.Services.Weapon.Interfaces
{
    public interface IWeaponService
    {
        event Action OnWeaponShoot;
        event Action<WeaponType> OnWeaponSelect;

        void TrySelectWeapon(WeaponType weaponType);
    }
}