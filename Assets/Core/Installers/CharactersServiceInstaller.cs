using Core.Factories;
using Core.Services.Character.Implementation;
using Core.Services.Character.Interfaces;
using Zenject;

namespace Core.Installers
{
    public class CharactersServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CharacterFactory>()
                .FromNew()
                .AsSingle();

            Container
                .Bind<ICharacterService>()
                .To<CharacterService>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}