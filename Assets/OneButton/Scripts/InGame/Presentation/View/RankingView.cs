using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class RankingView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup = default;

        public async UniTask ShowAsync(float duration, CancellationToken token)
        {
            await Fade(1.0f, duration)
                .WithCancellation(token);
        }

        public async UniTask HideAsync(float duration, CancellationToken token)
        {
            await Fade(0.0f, duration)
                .WithCancellation(token);
        }

        private Tween Fade(float endValue, float duration)
        {
            return canvasGroup
                .DOFade(endValue, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }
    }
}