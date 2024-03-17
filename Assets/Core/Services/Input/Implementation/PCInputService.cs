using Core.Services.Input.Intrfaces;
using UnityEngine;
using Zenject;

namespace Core.Services.Input.Implementation
{
    public class PCInputService : IInputService, ITickable
    {
        public Vector3 Direction { get; private set; }
        public float RotationY { get; private set; }

        public void Tick()
        {
            UpdateDirection();
            UpdateRotation();
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
    }
}