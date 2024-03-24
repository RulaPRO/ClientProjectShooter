using System;
using Core.Services.Character.Interfaces;
using UnityEngine;

namespace Core.Services.Character.Implementation
{
    public class HealthService : IHealthService
    {
        public event Action<int> OnHealthChange;
        public event Action OnHealthEnd;

        public int HealthCurrent { get; private set; }
        public int HealthMax { get; private set; }
        
        public void Initialize(int healthMax)
        {
            HealthMax = healthMax;
            HealthCurrent = healthMax;
        }

        public void DecreaseHealth(int value)
        {
            HealthCurrent = Mathf.Clamp(HealthCurrent - value, 0, HealthMax);

            OnHealthChange?.Invoke(HealthCurrent);

            if (HealthCurrent == 0)
            {
                OnHealthEnd?.Invoke();
            }
        }

        public void IncreaseHealth(int value)
        {
            HealthCurrent = Mathf.Clamp(HealthCurrent + value, 0, HealthMax);

            OnHealthChange?.Invoke(HealthCurrent);
        }
    }
}