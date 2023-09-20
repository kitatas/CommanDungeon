using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class MoveState : BaseState
    {
        private readonly HpUseCase _hpUseCase;
        private readonly PlayerView _playerView;
        private readonly SlotView _slotView;
        private readonly StepView _stepView;

        public MoveState(HpUseCase hpUseCase, PlayerView playerView, SlotView slotView, StepView stepView)
        {
            _hpUseCase = hpUseCase;
            _playerView = playerView;
            _slotView = slotView;
            _stepView = stepView;
        }

        public override GameState state => GameState.Move;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _hpUseCase.Increase(PlayerConfig.MAX_HP);
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            for (int i = 0; i < SlotConfig.REEL_COUNT; i++)
            {
                _slotView.SetFocus(i);
                var directions = _slotView.GetReelPattern(i).move.ToVector3List();
                foreach (var direction in directions)
                {
                    await _playerView.MoveAsync(direction, token);

                    // 階段に到達
                    if (_stepView.IsGoal(_playerView.currentPosition))
                    {
                        return GameState.Step;
                    }
                }

                // 1回行動のHP減少
                _hpUseCase.Decrease(1);
                if (_hpUseCase.IsDead())
                {
                    // TODO: ゲーム終了
                    return GameState.None;
                }
            }

            return GameState.Slot;
        }
    }
}