using System.Collections.Generic;
using Balance.AssetsTypes;
using Core.Factories;
using Core.Services.Weapon.Implementation;
using Core.Services.Weapon.Interfaces;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class EnemyCharacterView : CharacterView
    {
        [SerializeField] private Transform weaponDummy;
        [SerializeField] private CharactersChecker charactersChecker;

        private IEnemyWeaponService enemyWeaponService;
        private WeaponFactory weaponFactory;
        private WeaponsConfig weaponsConfig;

        private Dictionary<WeaponType, WeaponView> weapons = new();

        private WeaponView selectedWeapon;

        [Inject]
        public void Construct(
            IEnemyWeaponService enemyWeaponService,
            WeaponFactory weaponFactory,
            WeaponsConfig weaponsConfig)
        {
            this.enemyWeaponService = enemyWeaponService;
            this.weaponFactory = weaponFactory;
            this.weaponsConfig = weaponsConfig;

            CreateWeapons();
            ShowWeapon(enemyWeaponService.SelectedWeapon);

            enemyWeaponService.OnWeaponShoot += OnWeaponShoot;
            charactersChecker.OnEnemyInRange += LookAtEnemy;
        }

        private void LookAtEnemy(GameObject enemyGameObject)
        {
            transform.LookAt(enemyGameObject.transform);
        }

        private void OnDestroy()
        {
            enemyWeaponService.OnWeaponShoot -= OnWeaponShoot;
        }

        private void CreateWeapons()
        {
            foreach (var weaponType in enemyWeaponService.AvailableWeapons())
            {
                var weaponView = weaponFactory.Create(weaponType);
                weaponView.Initialize(weaponsConfig.GetConfig(weaponType));
                weaponView.transform.SetParent(weaponDummy);
                weaponView.transform.localPosition = Vector3.zero;
                weaponView.gameObject.SetActive(false);

                weapons.Add(weaponType, weaponView);
            }
        }

        private void OnWeaponShoot(WeaponType weaponType)
        {
            weapons[weaponType].StartShoot();
        }

        private void ShowWeapon(WeaponType weaponType)
        {
            selectedWeapon = weapons[weaponType];
            selectedWeapon.gameObject.SetActive(true);
        }
    }
}