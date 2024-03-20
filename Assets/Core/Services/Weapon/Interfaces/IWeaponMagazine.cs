namespace Core.Services.Weapon.Interfaces
{
    public interface IWeaponMagazine
    {
        bool IsEmpty { get; }
        void RemoveOneAmmo();
    }
}