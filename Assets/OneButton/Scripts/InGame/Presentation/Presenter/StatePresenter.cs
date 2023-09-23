using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;
using OneButton.Common.Presentation.Controller;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.Controller;
using UniRx;
using VContainer.Unity;

namespace OneButton.InGame.Presentation.Presenter
{
    public sealed class StatePresenter : IInitializable, IDisposable
    {
        private readonly StateUseCase _stateUseCase;
        private readonly StateController _stateController;
        private readonly ExceptionController _exceptionController;
        private readonly CancellationTokenSource _tokenSource;

        public StatePresenter(StateUseCase stateUseCase, StateController stateController,
            ExceptionController exceptionController)
        {
            _stateUseCase = stateUseCase;
            _stateController = stateController;
            _exceptionController = exceptionController;
            _tokenSource = new CancellationTokenSource();
        }

        public void Initialize()
        {
            _stateController.InitAsync(_tokenSource.Token).Forget();

            _stateUseCase.gameState
                .Subscribe(x => ExecAsync(x, _tokenSource.Token).Forget())
                .AddTo(_tokenSource.Token);
        }

        private async UniTask ExecAsync(GameState state, CancellationToken token)
        {
            try
            {
                var nextState = await _stateController.TickAsync(state, token);
                _stateUseCase.Set(nextState);
            }
            catch (Exception e)
            {
                var type = await _exceptionController.ShowExceptionAsync(e, _tokenSource.Token);
                if (type == ExceptionType.Retry)
                {
                    await ExecAsync(state, token);
                }

                throw;
            }
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }
    }
}