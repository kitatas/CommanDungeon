using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using OneButton.Common;
using TMPro;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class ResultView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup = default;
        [SerializeField] private ScoreView floorScore = default;
        [SerializeField] private ScoreView coinScore = default;
        [SerializeField] private ScoreView matchScore = default;
        [SerializeField] private TextMeshProUGUI lastScore = default;

        public void Init()
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.0f;
            floorScore.Init();
            coinScore.Init();
            matchScore.Init();
            lastScore.text = "";
        }

        public async UniTask ShowAsync(float duration, CancellationToken token)
        {
            canvasGroup.blocksRaycasts = true;

            await DOTween.Sequence()
                .Append(canvasGroup
                    .DOFade(1.0f, duration)
                    .SetEase(Ease.OutBack))
                .SetLink(gameObject)
                .WithCancellation(token);
        }

        public async UniTask ShowFloorScoreAsync(int score, float duration, Action<SeType> playSe,
            CancellationToken token)
        {
            await floorScore.ShowTitleAsync("フロアとうたつボーナス", duration, playSe, token);
            await floorScore.ShowValueAsync(ScoreConfig.FLOOR_RATE, score, duration, playSe, token);
        }

        public async UniTask ShowCoinScoreAsync(int score, float duration, Action<SeType> playSe,
            CancellationToken token)
        {
            await coinScore.ShowTitleAsync("コインまいすうボーナス", duration, playSe, token);
            await coinScore.ShowValueAsync(ScoreConfig.COIN_RATE, score, duration, playSe, token);
        }

        public async UniTask ShowMatchScoreAsync(int score, float duration, Action<SeType> playSe,
            CancellationToken token)
        {
            await matchScore.ShowTitleAsync("コマンドいっちボーナス", duration, playSe, token);
            await matchScore.ShowValueAsync(ScoreConfig.SLOT_MATCH_RATE, score, duration, playSe, token);
        }

        public async UniTask TweenLastScoreAsync(int score, float duration, CancellationToken token)
        {
            await DOTween
                .To(
                    () => 0,
                    x => lastScore.text = $"{x}",
                    score,
                    duration
                )
                .SetEase(Ease.Linear)
                .SetLink(gameObject)
                .WithCancellation(token);
        }
    }
}