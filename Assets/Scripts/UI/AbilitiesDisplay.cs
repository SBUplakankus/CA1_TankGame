using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AbilitiesDisplay : MonoBehaviour
    {
        public Slider jumpSlider, dashSlider;

        public void ResetJumpSlider(float cooldown)
        {
            jumpSlider.value = 0;
            Tween.UISliderValue(jumpSlider, jumpSlider.maxValue, cooldown);
        }

        public void ResetDashSlider(float cooldown)
        {
            dashSlider.value = 0;
            Tween.UISliderValue(dashSlider, dashSlider.maxValue, cooldown);
        }
    }
}
