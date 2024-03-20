﻿using Core.Services.Input.Implementation;
using Core.Services.Input.Interfaces;
using Zenject;

namespace Core.Installers
{
    public class InputServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(IInputService), typeof(ITickable))
                .To<PCInputService>()
                .AsSingle()
                .NonLazy();
        }
    }
}