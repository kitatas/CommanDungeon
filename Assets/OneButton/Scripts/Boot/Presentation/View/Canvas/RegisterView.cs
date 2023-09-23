using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Base.Presentation.View;
using OneButton.Common.Presentation.View;
using TMPro;
using UnityEngine;

namespace OneButton.Boot.Presentation.View
{
    public sealed class RegisterView : BaseCanvasGroupView
    {
        [SerializeField] private TMP_InputField inputField = default;
        [SerializeField] private DecisionButtonView decision = default;

        private string inputName => inputField.text;

        public async UniTask<string> DecisionNameAsync(float animationTime, CancellationToken token)
        {
            inputField.text = GetSampleName();
            await ShowAsync(animationTime, token);

            // 決定ボタン押下待ち
            await decision.PushAsync(token);
            await HideAsync(animationTime, token);

            return inputName;
        }

        private static string GetSampleName()
        {
            return "user" + $"{Random.Range(0, 1000000):000000}";
        }
    }
}