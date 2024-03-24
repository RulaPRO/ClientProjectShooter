using System.Collections.Generic;
using System.Linq;
using Balance.AssetsTypes;
using Core.Factories;
using Core.Services.Character.Implementation;
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
        private Dictionary<string, CharacterView> targets = new();

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
            charactersChecker.OnEnemyEnterInRange += OnEnemyEnterInRange;
            charactersChecker.OnEnemyExitFromRange += OnEnemyExitFromRange;
        }

        private void OnDestroy()
        {
            enemyWeaponService.OnWeaponShoot -= OnWeaponShoot;
            charactersChecker.OnEnemyEnterInRange -= OnEnemyEnterInRange;
            charactersChecker.OnEnemyExitFromRange -= OnEnemyExitFromRange;
        }

        private void Update()
        {
            if (targets.Count > 0)
            {
                transform.LookAt(targets.First().Value.transform);
                enemyWeaponService.TryShoot();
            }
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

        private void ShowWeapon(WeaponType weaponType)
        {
            selectedWeapon = weapons[weaponType];
            selectedWeapon.gameObject.SetActive(true);
        }

        private void OnWeaponShoot(WeaponType weaponType)
        {
            weapons[weaponType].StartShoot(CharacterFractionType.Enemy);
        }

        private void OnEnemyEnterInRange(CharacterView characterView)
        {
            targets.Add(characterView.name, characterView);
        }

        private void OnEnemyExitFromRange(CharacterView characterView)
        {
            targets.Remove(characterView.name);
        }
    }
}