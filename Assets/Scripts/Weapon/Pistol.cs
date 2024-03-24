using UnityEngine;

namespace Weapon
{
    public class Pistol : MonoBehaviour
    {
        public Bullet bulletPrefab; // Префаб пули
        public Transform firePoint; // Точка, откуда будут вылетать пули
        public float bulletSpeed = 20.0f; // Скорость полета пули
        public int bulletDamage = 5; // Скорость полета пули
        public float bulletAccuracy = 2.5f; // Расброс пуль

        private void Update()
        {
            // Проверяем нажатие кнопки мыши (левой кнопки в этом примере)
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(); // Если кнопка мыши нажата, выполняем стрельбу
            }
        }

        private void Shoot()
        {
            var quaternion = Quaternion.Euler(
                0.0f,
                transform.rotation.y + Random.Range(-bulletAccuracy, bulletAccuracy),
                0.0f);
            
            Instantiate(bulletPrefab, firePoint.position, quaternion)
                .SetDirection(transform.rotation)
                .SetSpeed(bulletSpeed)
                .SetDamage(bulletDamage);
        }
    }
}