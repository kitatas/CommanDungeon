using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Base.Presentation.View;
using OneButton.Common.Presentation.View;
using UnityEngine;

namespace OneButton.InGame.Presentation.View.Canvas
{
    public sealed class MenuView : BaseCanvasGroupView
    {
        [SerializeField] private DecisionButtonView open = default;
        [SerializeField] private DecisionButtonView close = default;

        public async UniTaskVoid InitAsync(float duration, CancellationToken token)
        {
            open.pushed += () => ShowAsync(duration, token).Forget();
            close.pushed += () => HideAsync(duration, token).Forget();

            HideAsync(0.0f, token).Forget();
            await UniTask.Yield(token);
        }
    }
}