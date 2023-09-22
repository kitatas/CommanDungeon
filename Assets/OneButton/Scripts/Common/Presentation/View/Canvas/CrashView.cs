using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Base.Presentation.View;
using TMPro;
using UnityEngine;

namespace OneButton.Common.Presentation.View
{
    public sealed class CrashView : BaseCanvasGroupView
    {
        [SerializeField] private TextMeshProUGUI messageText = default;
        [SerializeField] private ExceptionButtonView exceptionButton = default;

        public async UniTask ShowAndPushAsync(string message, float duration, CancellationToken token)
        {
            messageText.text = $"{message}";

            await ShowAsync(duration, token);

            await exceptionButton.PushAsync(token);
        }
    }
}