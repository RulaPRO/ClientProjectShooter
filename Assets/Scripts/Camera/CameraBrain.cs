using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 10f;
    [SerializeField] private float height = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private float currentRotation = 0f;

    void Update()
    {
        currentRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        var rotation = Quaternion.Euler(0f, currentRotation, 0f);
        var position = target.position - (rotation * Vector3.forward * distance);
        position.y = target.position.y + height;
        transform.position = position;
        transform.LookAt(target.position);
    }
}