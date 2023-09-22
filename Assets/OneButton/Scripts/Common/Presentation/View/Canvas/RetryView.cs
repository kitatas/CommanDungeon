using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Base.Presentation.View;
using TMPro;
using UnityEngine;

namespace OneButton.Common.Presentation.View
{
    public sealed class RetryView : BaseCanvasGroupView
    {
        [SerializeField] private TextMeshProUGUI messageText = default;
        [SerializeField] private DecisionButtonView decisionButton = default;

        public async UniTask ShowAndHideAsync(string message, float duration, CancellationToken token)
        {
            messageText.text = $"{message}";

            await ShowAsync(duration, token);

            await decisionButton.PushAsync(token);

            await HideAsync(duration, token);
        }
    }
}