using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;
using UniRx;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class SlotState : BaseState
    {
        private readonly SlotUseCase _slotUseCase;
        private readonly StepCountUseCase _stepCountUseCase;
        private readonly MainButtonView _mainButtonView;
        private readonly SlotView _slotView;
        private readonly TitleView _titleView;

        public SlotState(SlotUseCase slotUseCase, StepCountUseCase stepCountUseCase, MainButtonView mainButtonView,
            SlotView slotView, TitleView titleView)
        {
            _slotUseCase = slotUseCase;
            _stepCountUseCase = stepCountUseCase;
            _mainButtonView = mainButtonView;
            _slotView = slotView;
            _titleView = titleView;
        }

        public override GameState state => GameState.Slot;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _slotView.Init();
            _stepCountUseCase.difficulty
                .Subscribe(_ =>
                {
                    var slotData = _slotUseCase.GetSlotData();
                    _slotView.SetUp(slotData.data);
                })
                .AddTo(token);

            _titleView.InitAsync(UiConfig.POPUP_TIME, token).Forget();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            // リール回転開始
            _slotView.Refresh();
            _mainButtonView.Activate(true);

            // リール停止 * 3
            for (int i = 0; i < SlotConfig.REEL_COUNT; i++)
            {
                _slotView.SetFocus(i);
                await _mainButtonView.PushAsync(token);
                _slotView.StopReel(i);
            }

            _mainButtonView.Activate(false);

            return GameState.Move;
        }
    }
}