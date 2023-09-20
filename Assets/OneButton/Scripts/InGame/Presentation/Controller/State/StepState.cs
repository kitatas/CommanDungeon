using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.InGame.Presentation.View;
using UnityEngine;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class StepState : BaseState
    {
        private readonly StageView _stageView;
        private readonly StepView _stepView;

        public StepState(StageView stageView, StepView stepView)
        {
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

            return GameState.Slot;
        }
    }
}