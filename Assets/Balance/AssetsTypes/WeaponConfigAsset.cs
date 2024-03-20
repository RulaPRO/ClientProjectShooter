using Core.Services.Weapon.Implementation;
using UnityEngine;

namespace Balance.AssetsTypes
{
    [CreateAssetMenu(
        menuName = "Balance/" + nameof(WeaponConfigAsset),
        fileName = nameof(WeaponConfigAsset))]
    public class WeaponConfigAsset : ScriptableObject
    {
        [SerializeField] private WeaponType weaponType; // Тип оружия
        [SerializeField] private int balletDamage; // Урон пули
        [SerializeField] private float bulletRange; // Дальность полета пули
        [SerializeField] private float bulletSpeed; // Скорость полета пули
        [SerializeField] private float shootAccuracy; // Расброс пуль
        [SerializeField] private int shootDelayMs; // Задержка между выстрелами
        [SerializeField] private int magazineSize; // Обьем обоймы
        [SerializeField] private int reloadTimeMs; // Время перезарядки

        public WeaponType WeaponType => weaponType;
        public int BalletDamage => balletDamage;
        public float BulletRange => bulletRange;
        public float BulletSpeed => bulletSpeed;
        public float ShootAccuracy => shootAccuracy;
        public int ShootDelayMs => shootDelayMs;
        public int MagazineSize => magazineSize;
        public int ReloadTimeMs => reloadTimeMs;


    }
}