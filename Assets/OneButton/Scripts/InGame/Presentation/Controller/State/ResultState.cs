using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;
using OneButton.Common.Domain.UseCase;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class ResultState : BaseState
    {
        private readonly CoinUseCase _coinUseCase;
        private readonly ScoreUseCase _scoreUseCase;
        private readonly SlotMatchUseCase _slotMatchUseCase;
        private readonly SoundUseCase _soundUseCase;
        private readonly StepCountUseCase _stepCountUseCase;
        private readonly ResultView _resultView;

        public ResultState(CoinUseCase coinUseCase, ScoreUseCase scoreUseCase, SlotMatchUseCase slotMatchUseCase,
            SoundUseCase soundUseCase, StepCountUseCase stepCountUseCase, ResultView resultView)
        {
            _coinUseCase = coinUseCase;
            _scoreUseCase = scoreUseCase;
            _slotMatchUseCase = slotMatchUseCase;
            _soundUseCase = soundUseCase;
            _stepCountUseCase = stepCountUseCase;
            _resultView = resultView;
        }

        public override GameState state => GameState.Result;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _soundUseCase.PlayBgm(BgmType.Main);
            _resultView.Init();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _soundUseCase.PlayBgm(BgmType.Result);
            await _resultView.ShowAsync(ScoreConfig.SHOW_TIME, token);

            Action<SeType> playSe = x => _soundUseCase.PlaySe(x);
            await _resultView.ShowMatchScoreAsync(_slotMatchUseCase.currentValue, ScoreConfig.SHOW_TIME, playSe, token);
            await _resultView.ShowCoinScoreAsync(_coinUseCase.currentValue, ScoreConfig.SHOW_TIME, playSe, token);
            await _resultView.ShowFloorScoreAsync(_stepCountUseCase.currentValue, ScoreConfig.SHOW_TIME, playSe, token);

            _soundUseCase.PlaySe(SeType.LastScore);
            await _resultView.TweenLastScoreAsync(_scoreUseCase.score, ScoreConfig.SHOW_TIME, token);
            await UniTask.Delay(TimeSpan.FromSeconds(ScoreConfig.SHOW_TIME), cancellationToken: token);

            return GameState.Ranking;
        }
    }
}