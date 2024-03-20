using System.Collections.Generic;
using Core.Services.Weapon.Implementation;
using UnityEngine;

namespace Balance.AssetsTypes
{
    [CreateAssetMenu(
        menuName = "Config/" + nameof(WeaponsConfig),
        fileName = nameof(WeaponsConfig))]
    public class WeaponsConfig : ScriptableObject
    {
        [SerializeField] private List<WeaponConfigAsset> configs;

        public WeaponConfigAsset GetConfig(WeaponType weaponType)
        {
            return configs.Find(_ => _.WeaponType == weaponType);
        }
    }
}