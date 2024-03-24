using System;
using Core.Services.Character.Interfaces;

namespace Core.Services.Character.Implementation
{
    public class HealthService : IHealthService
    {
        public event Action<int> OnHealthChange;

        public int HealthCurrent { get; private set; }
        public int HealthMax { get; private set; }
        
        public void Initialize(int healthMax)
        {
            HealthMax = healthMax;
            HealthCurrent = healthMax;
        }

        public void DecreaseHealth(int value)
        {
            HealthCurrent -= value;

            OnHealthChange?.Invoke(HealthCurrent);
        }

        public void IncreaseHealth(int value)
        {
            HealthCurrent += value;

            OnHealthChange?.Invoke(HealthCurrent);
        }
    }
}