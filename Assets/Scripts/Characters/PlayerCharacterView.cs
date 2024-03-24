using System.Collections.Generic;
using Balance.AssetsTypes;
using Core.Factories;
using Core.Services.Character.Implementation;
using Core.Services.Weapon.Implementation;
using Core.Services.Weapon.Interfaces;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class PlayerCharacterView : CharacterView
    {
        [SerializeField] private Transform weaponDummy;

        private IPlayerWeaponService playerWeaponService;
        private WeaponFactory weaponFactory;
        private WeaponsConfig weaponsConfig;

        private Dictionary<WeaponType, WeaponView> weapons = new();

        private WeaponView selectedWeapon;

        [Inject]
        public void Construct(
            IPlayerWeaponService playerWeaponService,
            WeaponFactory weaponFactory,
            WeaponsConfig weaponsConfig)
        {
            this.playerWeaponService = playerWeaponService;
            this.weaponFactory = weaponFactory;
            this.weaponsConfig = weaponsConfig;

            CreateWeapons();
            ShowWeapon(playerWeaponService.SelectedWeapon);

            playerWeaponService.OnWeaponShoot += OnWeaponShoot;
            playerWeaponService.OnWeaponSelect += OnWeaponSelect;
        }

        private void OnDestroy()
        {
            playerWeaponService.OnWeaponShoot -= OnWeaponShoot;
            playerWeaponService.OnWeaponSelect -= OnWeaponSelect;
        }

        private void CreateWeapons()
        {
            foreach (var weaponType in playerWeaponService.AvailableWeapons())
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
            weapons[weaponType].StartShoot(CharacterFractionType.Player);
        }

        private void OnWeaponSelect(WeaponType weaponType)
        {
            HideCurrentWeapon();
            ShowWeapon(weaponType);
        }

        private void HideCurrentWeapon()
        {
            selectedWeapon.gameObject.SetActive(false);
        }

        private void ShowWeapon(WeaponType weaponType)
        {
            selectedWeapon = weapons[weaponType];
            selectedWeapon.gameObject.SetActive(true);
        }
    }
}