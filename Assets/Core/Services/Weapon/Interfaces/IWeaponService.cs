using System;
using System.Collections.Generic;
using Core.Services.Weapon.Implementation;

namespace Core.Services.Weapon.Interfaces
{
    public interface IWeaponService
    {
        event Action<WeaponType> OnWeaponShoot;
        event Action<WeaponType> OnWeaponSelect;

        WeaponType SelectedWeapon { get; }
        List<WeaponType> AvailableWeapons();
    }
}