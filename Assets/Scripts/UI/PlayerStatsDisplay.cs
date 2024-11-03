using System;
using System.Collections;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    //I have done a lot of work with Unity UI in the past, so I use PrimeTween which is a unity animation plugin
    //So that is what all the Tween functions and Ease are referring to
    public class PlayerStatsDisplay : MonoBehaviour
    {
        [Header("Stat Sliders")]
        public Slider xpSlider, healthSlider;
        
        [Header("Player Info")]
        public TMP_Text playerName, playerRank;

        [Header("Icons")] 
        public Sprite[] rankIcons;
        public Image currentRankIcon;

        [Header("Animation Variables")] 
        private const float AnimationDuration = 1f;
        private const Ease AnimationEase = Ease.OutCubic;
        
        /// <summary>
        /// Updates the Health Slider value
        /// </summary>
        /// <param name="value">New Health Value</param>
        public void UpdateHealthSlider(int value)
        {
            Tween.UISliderValue(healthSlider, value, AnimationDuration, AnimationEase);
        }

        /// <summary>
        /// Override to update the xp slider setting a new max level and value
        /// </summary>
        /// <param name="value">Added XP Value</param>
        /// <param name="newMax">New Slider Max Value</param>
        /// <param name="newRank">Players new rank index</param>
        public void UpdateXpSlider(int value, int newMax, int newRank)
        {
            StartCoroutine(LevelUpXpCoroutine(value, newMax, newRank));
        }
        
        private IEnumerator LevelUpXpCoroutine(int value, int newMax, int newRank)
        {
            yield return Tween.UISliderValue(xpSlider, xpSlider.maxValue, AnimationDuration, AnimationEase).ToYieldInstruction();
            SetNewXpSliderLimits(newMax);
            SetPlayerRank(newRank);
            yield return Tween.UISliderValue(xpSlider, value, AnimationDuration, AnimationEase).ToYieldInstruction();
        }
        
        /// <summary>
        /// Update the XP Slider value
        /// </summary>
        /// <param name="value">Added XP value</param>
        public void UpdateXpSlider(int value)
        {
            Tween.UISliderValue(xpSlider, value, AnimationDuration, AnimationEase);
        }
        /// <summary>
        /// Update the XP Sliders new max value and set it to the minimum value
        /// </summary>
        /// <param name="newLimit">New Max XP Value</param>
        private void SetNewXpSliderLimits(int newLimit)
        {
            xpSlider.minValue = xpSlider.maxValue;
            xpSlider.maxValue = newLimit;
            xpSlider.value = xpSlider.minValue;
        }
        
        /// <summary>
        /// Set the player name in the top display
        /// </summary>
        /// <param name="pName">Player Name</param>
        public void SetPlayerName(string pName)
        {
            playerName.text = pName;
        }
        
        /// <summary>
        /// Set the Players Rank Text and Icon 
        /// </summary>
        /// <param name="rank">ID of the Rank</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void SetPlayerRank(int rank)
        {
            playerRank.text = rank switch
            {
                0 => "PVT.",
                1 => "PFC.",
                2 => "SPC.",
                3 => "CPL.",
                4 => "SGT.",
                _ => throw new ArgumentOutOfRangeException(nameof(rank), rank, null)
            };

            currentRankIcon.sprite = rankIcons[rank];
        }
        
        /// <summary>
        /// Set the initial values of the Health and XP Sliders
        /// </summary>
        /// <param name="maxHealth">Max Health Value</param>
        /// <param name="xpLimit">Max XP Value</param>
        public void SetInitialStats(int maxHealth, int xpLimit)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
            xpSlider.maxValue = xpLimit;
            xpSlider.value = 0;
            SetPlayerRank(0);
        }
    }
}
