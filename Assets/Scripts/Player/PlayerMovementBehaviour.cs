using Core.Services.Input.Intrfaces;
using UnityEngine;
using Zenject;

namespace Characters
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