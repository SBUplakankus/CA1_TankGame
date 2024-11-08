using System;
using UnityEngine;

namespace World
{
    public class EndGame : MonoBehaviour
    {
        public static event Action OnGameWin;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
        
            OnGameWin?.Invoke();
        }
    }
}
