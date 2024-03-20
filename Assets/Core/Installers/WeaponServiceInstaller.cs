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
                .Bind<IWeaponService>()
                .To<WeaponService>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}