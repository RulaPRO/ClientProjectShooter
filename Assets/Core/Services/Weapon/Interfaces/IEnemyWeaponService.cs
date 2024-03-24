namespace Core.Services.Weapon.Interfaces
{
    public interface IEnemyWeaponService : IWeaponService
    {
        void TryShoot();
    }
}