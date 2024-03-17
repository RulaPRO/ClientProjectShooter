using UnityEngine;

namespace Core.Services.Input.Intrfaces
{
    public interface IInputService
    {
        Vector3 Direction { get; }
        float RotationY { get; }
    }
}