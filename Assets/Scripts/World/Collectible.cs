using System;
using UnityEngine;

namespace World
{
    public class Collectible : MonoBehaviour
    {
        public enum CollectibleType {Health, Xp, Damage}
        public static event Action<CollectibleType, int> OnCollectibleHit;

        public CollectibleType collectibleType;
        public int valueGiven;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            OnCollectibleHit?.Invoke(collectibleType, valueGiven);
            gameObject.SetActive(false);
        }
    }
}
