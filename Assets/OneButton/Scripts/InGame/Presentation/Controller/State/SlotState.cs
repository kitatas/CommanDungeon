using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class SlotState : BaseState
    {
        private readonly SlotUseCase _slotUseCase;

        private readonly MainButtonView _mainButtonView;
        private readonly SlotView _slotView;

        public SlotState(SlotUseCase slotUseCase, MainButtonView mainButtonView, SlotView slotView)
        {
            _slotUseCase = slotUseCase;
            _mainButtonView = mainButtonView;
            _slotView = slotView;
        }

        public override GameState state => GameState.Slot;

        public override async UniTask InitAsync(CancellationToken token)
        {
            for (int i = 0; i < SlotConfig.REEL_COUNT; i++)
            {
                var reelData = _slotUseCase.GetPatternData(i);
                _slotView.Init(i, reelData.data);
            }

            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            // リール回転開始
            _slotView.Refresh();

            // リール停止 * 3
            for (int i = 0; i < SlotConfig.REEL_COUNT; i++)
            {
                _slotView.SetFocus(i);
                await _mainButtonView.PushAsync(token);
                _slotView.StopReel(i);
            }

            await _mainButtonView.PushAsync(token);

            return GameState.Move;
        }
    }
}