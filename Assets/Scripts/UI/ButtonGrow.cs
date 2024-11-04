using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ButtonGrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private const float GrowSize = 1.04f;
        private const float AnimationDuration = 0.2f;
        private void OnEnable()
        {
            transform.localScale = Vector3.one;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Tween.Scale(transform, GrowSize, AnimationDuration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Tween.Scale(transform, 1, AnimationDuration);
        }
    }
}
