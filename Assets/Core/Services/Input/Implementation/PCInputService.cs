using System;
using Core.Services.Input.Interfaces;
using UnityEngine;
using Zenject;

namespace Core.Services.Input.Implementation
{
    public class PCInputService : IInputService, ITickable
    {
        public event Action OnFireButtonPressed;
        public event Action OnButton1Down;
        public event Action OnButton2Down;
        public event Action OnButton3Down;

        public Vector3 Direction { get; private set; }
        public float RotationY { get; private set; }

        public void Tick()
        {
            UpdateDirection();
            UpdateRotation();

            UpdateFireState();

            UpdateKey1State();
            UpdateKey2State();
            UpdateKey3State();
        }

        private void UpdateDirection()
        {
            var horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
            var verticalInput = UnityEngine.Input.GetAxis("Vertical");
            Direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        }

        private void UpdateRotation()
        {
            RotationY += UnityEngine.Input.GetAxis("Mouse X");
        }

        private void UpdateFireState()
        {
            if (UnityEngine.Input.GetButton("Fire1"))
            {
                OnFireButtonPressed?.Invoke();
            }
        }

        private void UpdateKey1State()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                OnButton1Down?.Invoke();
            }
        }

        private void UpdateKey2State()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                OnButton2Down?.Invoke();
            }
        }

        private void UpdateKey3State()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
            {
                OnButton3Down?.Invoke();
            }
        }
    }
}