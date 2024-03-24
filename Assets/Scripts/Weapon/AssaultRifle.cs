// using System.Threading.Tasks;
// using UnityEngine;
// using Random = UnityEngine.Random;
//
// namespace Weapon
// {
//     public class AssaultRifle : MonoBehaviour
//     {
//         public Bullet bulletPrefab; // Префаб пули
//         public Transform firePoint; // Точка, откуда будут вылетать пули
//         public float bulletSpeed = 20.0f; // Скорость полета пули
//         public int bulletDamage = 5; // Скорость полета пули
//         public float bulletAccuracy = 2.5f; // Расброс пуль
//         public float shootDelay = 0.1f; // Задержка между выстрелами
//         public int magazineSize = 30; // Обьем обоймы
//         public int reloadTimeMs = 5000; // Обьем обоймы
//
//         private bool isDealy;
//         private float delayTimeSec;
//
//         private WeaponMagazine weaponMagazine;
//         private bool isReloading;
//
//         private void Start()
//         {
//             weaponMagazine = new WeaponMagazine(magazineSize);
//         }
//
//         private void Update()
//         {
//             delayTimeSec -= Time.deltaTime;
//             
//             // Проверяем нажатие кнопки мыши (левой кнопки в этом примере)
//             if (Input.GetButton("Fire1"))
//             {
//                 TryShoot(); // Если кнопка мыши нажата, выполняем стрельбу
//             }
//         }
//
//         private void TryShoot()
//         {
//             if (!CanShot())
//             {
//                 return;
//             }
//
//             delayTimeSec = shootDelay;
//             weaponMagazine.TryGetBullet();
//             
//             var quaternion = Quaternion.Euler(
//                 0.0f,
//                 transform.rotation.y + Random.Range(-bulletAccuracy, bulletAccuracy),
//                 0.0f);
//             
//             Instantiate(bulletPrefab, firePoint.position, quaternion)
//                 .SetDirection(transform.rotation)
//                 .SetSpeed(bulletSpeed)
//                 .SetDamage(bulletDamage);
//         }
//
//         private bool CanShot()
//         {
//             if (delayTimeSec > 0.0f)
//             {
//                 return false;
//             }
//
//             if (!weaponMagazine.HasBullets)
//             {
//                 if (!isReloading)
//                 {
//                     ReloadMagazine();
//                 }
//                 
//                 return false;
//             }
//
//             return true;
//         }
//
//         private async void ReloadMagazine()
//         {
//             Debug.LogError("START reload");
//             isReloading = true;
//             
//             await Task.Delay(reloadTimeMs);
//
//             weaponMagazine.Reset();
//             
//             isReloading = false;
//             Debug.LogError("END reload");
//         }
//     }
// }