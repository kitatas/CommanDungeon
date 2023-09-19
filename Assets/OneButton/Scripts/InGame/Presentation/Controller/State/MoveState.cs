using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.InGame.Presentation.View;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class MoveState : BaseState
    {
        private readonly PlayerView _playerView;
        private readonly SlotView _slotView;

        public MoveState(PlayerView playerView, SlotView slotView)
        {
            _playerView = playerView;
            _slotView = slotView;
        }

        public override GameState state => GameState.Move;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            for (int i = 0; i < SlotConfig.REEL_COUNT; i++)
            {
                var directions = _slotView.GetReelPattern(i).move.ToVector3List();
                foreach (var direction in directions)
                {
                    await _playerView.MoveAsync(direction, token);
                }
            }

            return GameState.Slot;
        }
    }
}