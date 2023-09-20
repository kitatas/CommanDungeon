using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class ResultState : BaseState
    {
        private readonly CoinUseCase _coinUseCase;
        private readonly ScoreUseCase _scoreUseCase;
        private readonly SlotMatchUseCase _slotMatchUseCase;
        private readonly StepCountUseCase _stepCountUseCase;
        private readonly ResultView _resultView;

        public ResultState(CoinUseCase coinUseCase, ScoreUseCase scoreUseCase, SlotMatchUseCase slotMatchUseCase,
            StepCountUseCase stepCountUseCase, ResultView resultView)
        {
            _coinUseCase = coinUseCase;
            _scoreUseCase = scoreUseCase;
            _slotMatchUseCase = slotMatchUseCase;
            _stepCountUseCase = stepCountUseCase;
            _resultView = resultView;
        }

        public override GameState state => GameState.Result;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _resultView.Init();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await _resultView.ShowAsync(ScoreConfig.SHOW_TIME, token);

            await _resultView.ShowCoinScoreAsync(_coinUseCase.currentValue, ScoreConfig.SHOW_TIME, token);
            await _resultView.ShowMatchScoreAsync(_slotMatchUseCase.currentValue, ScoreConfig.SHOW_TIME, token);
            await _resultView.ShowFloorScoreAsync(_stepCountUseCase.currentValue, ScoreConfig.SHOW_TIME, token);

            await _resultView.TweenLastScoreAsync(_scoreUseCase.score, ScoreConfig.SHOW_TIME, token);

            return GameState.Ranking;
        }
    }
}