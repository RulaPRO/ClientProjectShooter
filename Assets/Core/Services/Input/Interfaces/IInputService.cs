using System;
using UnityEngine;

namespace Core.Services.Input.Interfaces
{
    public interface IInputService
    {
        event Action OnFireButtonPressed;

        event Action OnButton1Down;
        event Action OnButton2Down;
        event Action OnButton3Down;

        Vector3 Direction { get; }
        float RotationY { get; }
    }
}