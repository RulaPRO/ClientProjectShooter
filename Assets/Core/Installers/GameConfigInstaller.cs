using Balance.AssetsTypes;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
    public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
    {
        [SerializeField] private WeaponsConfig weapons;

        public override void InstallBindings()
        {
            Container
                .Bind<WeaponsConfig>()
                .FromInstance(weapons);
        }
    }
}