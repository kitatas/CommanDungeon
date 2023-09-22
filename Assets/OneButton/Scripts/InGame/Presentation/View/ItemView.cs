using DG.Tweening;
using UniEx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public abstract class ItemView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = default;

        public abstract PatternType pattern { get; }
        public Vector3 currentPosition => transform.position;

        public void PickUp()
        {
            this.DelayFrame(1, () => Destroy(gameObject));
        }

        public Tween Show(float duration)
        {
            return spriteRenderer
                .DOFade(1.0f, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        public Tween Hide(float duration)
        {
            return spriteRenderer
                .DOFade(0.0f, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        public void HideTween(float duration)
        {
            DOTween.Sequence()
                .Append(transform
                    .DOMoveY(transform.position.y + StageConfig.HIDE_STEP_HEIGHT, duration)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject))
                .Join(Hide(duration))
                .OnComplete(() => Destroy(gameObject));
        }
    }
}