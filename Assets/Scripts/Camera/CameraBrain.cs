using Core.Services.Character.Interfaces;
using UnityEngine;
using Zenject;

public class CameraBrain : MonoBehaviour
{
    [SerializeField] private float distance = 10f;
    [SerializeField] private float height = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private float currentRotation = 0f;
    
    private ICharacterService characterService;

    [Inject]
    public void Construct(ICharacterService characterService)
    {
        this.characterService = characterService;
    }

    void Update()
    {
        if (!TryGetTargetPosition(out var targetPosition))
        {
            return;
        }

        currentRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        var rotation = Quaternion.Euler(0f, currentRotation, 0f);
        var position = targetPosition - (rotation * Vector3.forward * distance);
        position.y = targetPosition.y + height;
        transform.position = position;
        transform.LookAt(targetPosition);
    }

    private bool TryGetTargetPosition(out Vector3 position)
    {
        if (characterService.Player == null)
        {
            position = default;
            return false;
        }

        var targetPosition = characterService.Player.CharacterView.transform.position;
        position = new Vector3(
            targetPosition.x,
            targetPosition.y + height,
            targetPosition.z);
        return true;
    }
}