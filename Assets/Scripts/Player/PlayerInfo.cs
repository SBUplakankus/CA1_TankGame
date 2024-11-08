using System;
using UI;
using UnityEngine;
using World;

namespace Player
{
    public class PlayerInfo : MonoBehaviour
    {
        [Header("Player Info")]
        public string playerName;

        [Header("Stat Limits")] 
        public int maxHealth;
        public int xpToLevelUp;
        
        [Header("Current Stats")]
        private int _playerHealth;
        private int _playerXp;
        private int _playerRank;

        [Header("Scripts")] 
        public PlayerStatsDisplay statsDisplay;
        private CameraShake _cameraShake;

        private void Start()
        {
            _playerHealth = maxHealth;
            statsDisplay.SetInitialStats(maxHealth, xpToLevelUp);
            _cameraShake = CameraShake.Instance;
        }

        private void OnEnable()
        {
            Collectible.OnCollectibleHit += HandleCollectibleInteraction;
        }

        private void OnDisable()
        {
            Collectible.OnCollectibleHit -= HandleCollectibleInteraction;
        }

        private void HandleCollectibleInteraction(Collectible.CollectibleType type, int amount)
        {
            switch (type)
            {
                case Collectible.CollectibleType.Health:
                    AddHealth(amount);
                    break;
                case Collectible.CollectibleType.Xp:
                    AddXp(amount);
                    break;
                case Collectible.CollectibleType.Damage:
                    RemoveHealth(amount);
                    _cameraShake.ShakePlayerCamera(0.6f,1);
                    break;
                default:
                    Debug.LogError("Collectible Enum Error");
                    break;
                    
            }
        }
        
        /// <summary>
        /// Add health to the player
        /// </summary>
        /// <param name="value">Health Amount</param>
        private void AddHealth(int value)
        {
            if(_playerHealth >= maxHealth) return;
            
            if (_playerHealth + value >= maxHealth)
            {
                _playerHealth = maxHealth;
            }
            else
            {
                _playerHealth += value;
            }
            
            statsDisplay.UpdateHealthSlider(_playerHealth);
        }
        
        /// <summary>
        /// Add Xp to the players current amount
        /// </summary>
        /// <param name="value">Added Xp</param>
        private void AddXp(int value)
        {
            _playerXp += value;
            
            if (_playerXp < xpToLevelUp)
            {
                
                statsDisplay.UpdateXpSlider(_playerXp);
            }
            else
            {
                RankUp();
                statsDisplay.UpdateXpSlider(_playerXp, xpToLevelUp, _playerRank);
            }
        }

        private void RemoveHealth(int value)
        {
            _playerHealth -= value;
            if (_playerHealth < 0)
            {
                UIController.Instance.ShowGameOverScreen();
            }
            else
            {
                statsDisplay.UpdateHealthSlider(_playerHealth);
            }
        }
        
        /// <summary>
        /// Rank up the player
        /// </summary>
        private void RankUp()
        {
            _playerRank++;
            switch (_playerRank)
            {
                case 1:
                    xpToLevelUp = 250;
                    break;
                case 2:
                    xpToLevelUp = 600;
                    break;
                case 3: 
                    xpToLevelUp = 1000;
                    break;
                case 4:
                    xpToLevelUp = 1500;
                    break;
                case 5:
                    xpToLevelUp = 2250;
                    break;
                default:
                    Debug.LogError("Invalid Rank");
                    break;
            }
        }
    }
}
