using System;

namespace Core.Services.Character.Interfaces
{
    public interface IHealthService
    {
        event Action<int> OnHealthChange;
        int HealthCurrent { get; }
        int HealthMax { get; }

        void Initialize(int healthMax);

        void DecreaseHealth(int value);
        void IncreaseHealth(int value);
    }
}