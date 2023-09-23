using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.InGame.Domain.UseCase;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class FinishState : BaseState
    {
        private readonly CoinUseCase _coinUseCase;
        private readonly ScoreUseCase _scoreUseCase;
        private readonly SlotMatchUseCase _slotMatchUseCase;
        private readonly StepCountUseCase _stepCountUseCase;
        private readonly UserRecordUseCase _userRecordUseCase;

        public FinishState(CoinUseCase coinUseCase, ScoreUseCase scoreUseCase, SlotMatchUseCase slotMatchUseCase,
            StepCountUseCase stepCountUseCase, UserRecordUseCase userRecordUseCase)
        {
            _coinUseCase = coinUseCase;
            _scoreUseCase = scoreUseCase;
            _slotMatchUseCase = slotMatchUseCase;
            _stepCountUseCase = stepCountUseCase;
            _userRecordUseCase = userRecordUseCase;
        }

        public override GameState state => GameState.Finish;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _scoreUseCase.Reset();
            _scoreUseCase.Add(_stepCountUseCase.currentValue * ScoreConfig.FLOOR_RATE);
            _scoreUseCase.Add(_coinUseCase.currentValue * ScoreConfig.COIN_RATE);
            _scoreUseCase.Add(_slotMatchUseCase.currentValue * ScoreConfig.SLOT_MATCH_RATE);

            // ランキング送信
            await _userRecordUseCase.SendScoreAsync(_scoreUseCase.score, token);

            return GameState.Result;
        }
    }
}