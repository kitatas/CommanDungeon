using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Base.Presentation.View;
using OneButton.Common.Presentation.View;
using UnityEngine;

namespace OneButton.Boot.Presentation.View
{
    public sealed class UpdateView : BaseCanvasGroupView
    {
        [SerializeField] private DecisionButtonView decision = default;

        public async UniTaskVoid SetUp(string appUrl, float duration, CancellationToken token)
        {
            decision.pushed += () => Application.OpenURL(appUrl);
            ShowAsync(duration, token).Forget();
            await UniTask.Yield(token);
        }
    }
}