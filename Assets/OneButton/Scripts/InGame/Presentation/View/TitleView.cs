using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.InGame.Presentation.View.Canvas;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class TitleView : MonoBehaviour
    {
        [SerializeField] private MenuView config = default;
        [SerializeField] private MenuView information = default;
        [SerializeField] private MenuView caution = default;

        public async UniTaskVoid InitAsync(float duration, CancellationToken token)
        {
            config.InitAsync(duration, token).Forget();
            information.InitAsync(duration, token).Forget();
            caution.InitAsync(duration, token).Forget();

            await UniTask.Yield(token);
        }
    }
}