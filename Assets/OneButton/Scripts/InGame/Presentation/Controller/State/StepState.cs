using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;
using UnityEngine;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class StepState : BaseState
    {
        private readonly StepCountUseCase _stepCountUseCase;
        private readonly StageView _stageView;
        private readonly StepView _stepView;

        public StepState(StepCountUseCase stepCountUseCase, StageView stageView, StepView stepView)
        {
            _stepCountUseCase = stepCountUseCase;
            _stageView = stageView;
            _stepView = stepView;
        }

        public override GameState state => GameState.Step;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await (
                _stageView.SwitchAsync(StageConfig.TWEEN_TIME, token),
                _stepView.HideAsync(StageConfig.TWEEN_TIME, token)
            );

            _stepCountUseCase.Increment();

            // TODO: ステージ内アイテムのポップ
            // TODO: 階段位置の変更
            var position = new Vector3(0.5f, 0.5f, 0.0f);
            await _stepView.ShowAsync(position, StageConfig.TWEEN_TIME, token);

            return GameState.Slot;
        }
    }
}