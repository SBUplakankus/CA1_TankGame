using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

namespace UI
{
    public class CameraShake : MonoBehaviour
    {
        public static CameraShake Instance;
        private Camera _camera;

        private void Awake()
        {
            Instance = this;
            _camera = GetComponent<Camera>();
        }

        public void ShakePlayerCamera(float amount, float duration)
        {
            Tween.ShakeCamera(_camera, amount, duration);
        }
    }
}
