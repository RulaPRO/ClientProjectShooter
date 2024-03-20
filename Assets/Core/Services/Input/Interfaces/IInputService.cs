using System;
using UnityEngine;

namespace Core.Services.Input.Interfaces
{
    public interface IInputService
    {
        event Action OnFireButtonPressed;

        Vector3 Direction { get; }
        float RotationY { get; }
    }
}