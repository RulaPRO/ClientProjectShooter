using System;
using Balance.AssetsTypes;
using Core.Services.Weapon.Implementation;

namespace Core.Services.Weapon.Interfaces
{
    public interface IWeapon
    {
        event Action<WeaponType> OnWeaponShoot;

        WeaponConfigAsset WeaponConfigAsset { get; }
        IWeaponMagazine WeaponMagazine { get; }

        void TryShoot();
    }
}