using System.Threading;
using Cysharp.Threading.Tasks;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class RankingState : BaseState
    {
        public override GameState state => GameState.Ranking;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.Yield(token);

            return GameState.None;
        }
    }
}