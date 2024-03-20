using Balance.AssetsTypes;
using UnityEngine;

namespace Characters
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private Bullet prefabBullet;

        private WeaponConfigAsset config;

        public void Initialize(WeaponConfigAsset config)
        {
            this.config = config;
        }

        public void StartShoot()
        {
            var quaternion = Quaternion.Euler(
                0.0f,
                transform.rotation.y + Random.Range(-config.ShootAccuracy, config.ShootAccuracy),
                0.0f);
            
            Instantiate(prefabBullet, transform.position, quaternion)
                .SetDirection(transform.rotation)
                .SetSpeed(config.BulletSpeed)
                .SetDamage(config.BalletDamage);
        }
    }
}