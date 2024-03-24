using Core.Services.Weapon.Interfaces;

namespace Core.Services.Weapon.Implementation
{
    public class WeaponMagazine : IWeaponMagazine
    {
        private int maxMagazineSize;
        private int currentMagazineSize;

        public bool IsEmpty => currentMagazineSize == 0;

        public WeaponMagazine(int maxMagazineSize)
        {
            this.maxMagazineSize = maxMagazineSize;

            currentMagazineSize = maxMagazineSize;
        }

        public void RemoveOneAmmo()
        {
            if (currentMagazineSize > 0)
            {
                currentMagazineSize--;
            }
        }
    }
}