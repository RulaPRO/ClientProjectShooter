using System;

namespace Core.Services.Weapon.Interfaces
{
    public interface IWeapon
    {
        event Action OnWeaponShoot;
        void TryShoot();
    }
}