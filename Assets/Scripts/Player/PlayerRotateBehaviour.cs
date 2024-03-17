using Core.Services.Input.Intrfaces;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class PlayerRotateBehaviour : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5.0f;
        
        private IInputService inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            this.inputService = inputService;
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0f, inputService.RotationY * rotationSpeed, 0.0f);
        }
    }
}