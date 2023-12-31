using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using OneButton.Common;
using TMPro;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleLabel = default;
        [SerializeField] private TextMeshProUGUI scoreRate = default;
        [SerializeField] private TextMeshProUGUI mul = default;
        [SerializeField] private TextMeshProUGUI scoreCount = default;

        public void Init()
        {
            titleLabel.text = "";
            scoreRate.text = "";
            mul.text = "";
            scoreCount.text = "";
        }

        public async UniTask ShowTitleAsync(string title, float duration, Action<SeType> playSe,
            CancellationToken token)
        {
            playSe?.Invoke(SeType.LastScore);
            await titleLabel
                .DOText(title, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject)
                .WithCancellation(token);

            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
        }

        public async UniTask ShowValueAsync(int rate, int count, float duration, Action<SeType> playSe,
            CancellationToken token)
        {
            playSe?.Invoke(SeType.Result);
            scoreRate.text = $"{rate}";
            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);

            playSe?.Invoke(SeType.Result);
            mul.text = $"x";
            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);

            playSe?.Invoke(SeType.Result);
            scoreCount.text = $"{count}";
            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
        }
    }
}