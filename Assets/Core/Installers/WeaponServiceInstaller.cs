using Core.Factories;
using Core.Services.Weapon.Implementation;
using Core.Services.Weapon.Interfaces;
using Zenject;

namespace Core.Installers
{
    public class WeaponServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<WeaponFactory>()
                .FromNew()
                .AsSingle();

            Container
                .Bind<IPlayerWeaponService>()
                .To<PlayerWeaponService>()
                .FromNew()
                .AsSingle()
                .NonLazy();

            Container
                .Bind(typeof(IEnemyWeaponService), typeof(ITickable))
                .To<EnemyWeaponService>()
                .AsCached();
        }
    }
}