using Core.Services.Input.Interfaces;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10.0f;
        
        private IInputService inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            this.inputService = inputService;
        }

        private void Update()
        {
            transform.Translate(inputService.Direction * moveSpeed * Time.deltaTime);
        }
    }
}