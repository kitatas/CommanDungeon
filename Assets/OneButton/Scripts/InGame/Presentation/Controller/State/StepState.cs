using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;
using OneButton.Common.Domain.UseCase;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class StepState : BaseState
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly StepCountUseCase _stepCountUseCase;
        private readonly FloorItemView _floorItemView;
        private readonly PlayerView _playerView;
        private readonly StageView _stageView;
        private readonly StepView _stepView;

        public StepState(SoundUseCase soundUseCase, StepCountUseCase stepCountUseCase, FloorItemView floorItemView,
            PlayerView playerView, StageView stageView, StepView stepView)
        {
            _soundUseCase = soundUseCase;
            _stepCountUseCase = stepCountUseCase;
            _floorItemView = floorItemView;
            _playerView = playerView;
            _stageView = stageView;
            _stepView = stepView;
        }

        public override GameState state => GameState.Step;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _floorItemView.Init();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _soundUseCase.PlaySe(SeType.NextFloor);
            _floorItemView.HideAll(StageConfig.TWEEN_TIME);
            await (
                _stageView.SwitchAsync(StageConfig.TWEEN_TIME, token),
                _stepView.HideAsync(StageConfig.TWEEN_TIME, token)
            );

            _stepCountUseCase.Increment();

            // 次フロアの階段位置抽選
            _stepView.LotNextPosition(_playerView);

            // 次フロア内のアイテム抽選
            // 階段位置とは被らないようにする
            _floorItemView.LotItems(_playerView, _stepView);

            // 出現
            _floorItemView.ShowAll(StageConfig.TWEEN_TIME);
            await _stepView.ShowAsync(StageConfig.TWEEN_TIME, token);

            return GameState.Slot;
        }
    }
}