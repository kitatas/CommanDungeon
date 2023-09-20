using System.Threading;
using Cysharp.Threading.Tasks;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class FinishState : BaseState
    {
        public override GameState state => GameState.Finish;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            // TODO: ランキング送信
            await UniTask.Yield(token);

            return GameState.None;
        }
    }
}