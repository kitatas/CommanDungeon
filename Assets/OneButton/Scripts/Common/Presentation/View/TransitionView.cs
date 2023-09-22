using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.Common.Presentation.View
{
    public sealed class TransitionView : MonoBehaviour
    {
        [SerializeField] private Image maskUp = default;
        [SerializeField] private Image maskDown = default;
        [SerializeField] private Image raycastBlocker = default;

        public async UniTask FadeInAsync(float duration, CancellationToken token)
        {
            raycastBlocker.raycastTarget = true;

            await DOTween.Sequence()
                .Append(maskUp.rectTransform
                    .DOAnchorPosY(0.0f, duration))
                .Join(maskDown.rectTransform
                    .DOAnchorPosY(0.0f, duration))
                .SetEase(Ease.OutQuart)
                .SetLink(gameObject)
                .WithCancellation(token);
        }

        public async UniTask FadeOutAsync(float duration, CancellationToken token)
        {
            await DOTween.Sequence()
                .Append(maskUp.rectTransform
                    .DOAnchorPosY(360.0f, duration))
                .Join(maskDown.rectTransform
                    .DOAnchorPosY(-360.0f, duration))
                .SetEase(Ease.OutQuart)
                .SetLink(gameObject)
                .WithCancellation(token);

            raycastBlocker.raycastTarget = false;
        }
    }
}