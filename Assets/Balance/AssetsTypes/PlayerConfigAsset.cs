using System.Collections.Generic;
using Core.Services.Weapon.Implementation;
using UnityEngine;

namespace Balance.AssetsTypes
{
    [CreateAssetMenu(
        menuName = "Balance/" + nameof(PlayerConfigAsset),
        fileName = nameof(PlayerConfigAsset))]
    public class PlayerConfigAsset : ScriptableObject
    {
        [SerializeField] private float defaultWalkSpeed;
        [SerializeField] private List<WeaponType> startWeapons;

        public List<WeaponType> StartWeapons => startWeapons;
    }
}