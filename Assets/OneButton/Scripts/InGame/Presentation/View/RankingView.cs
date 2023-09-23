using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniEx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class RankingView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup = default;
        [SerializeField] private RectTransform viewport = default;

        [SerializeField] private RankingRecordView rankingRecordView = default;

        public void SetUp(List<Common.Data.Entity.RankingRecordEntity> recordEntities)
        {
            recordEntities.Each(x =>
            {
                var record = Instantiate(rankingRecordView, viewport);
                record.SetData(x);
            });
        }

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