﻿using UnityEngine;

namespace Camera
{
    public class LookAtCamera : MonoBehaviour
    {
        private UnityEngine.Camera mainCamera;

        private void Start()
        {
            mainCamera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            transform.LookAt(mainCamera.transform);
        }
    }
}