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
                var patternData = _slotView.GetReelPattern(i);

                // ハート付きのコマンドはハート消費なしで行動
                if (patternData.pattern != PatternType.Heart)
                {
                    // 1回行動のハート減少
                    _hpUseCase.Decrease(1);
                }

                var directions = patternData.move.ToVector3List();
                foreach (var direction in directions)
                {
                    await _playerView.MoveAsync(direction, token);

                    // 階段に到達
                    if (_stepView.IsEqualPosition(_playerView.currentPosition))
                    {
                        _slotView.SetFocus(-1);

                        // 階段到達で3回復
                        _hpUseCase.Increase(StageConfig.REACH_STEP_BONUS);
                        return GameState.Step;
                    }
                }

                if (_hpUseCase.IsDead())
                {
                    return GameState.Finish;
                }
            }

            return GameState.Slot;
        }
    }
}