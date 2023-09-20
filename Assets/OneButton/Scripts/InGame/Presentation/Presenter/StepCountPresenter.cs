using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;
using UniRx;
using VContainer.Unity;

namespace OneButton.InGame.Presentation.Presenter
{
    public sealed class StepCountPresenter : IInitializable
    {
        private readonly StepCountUseCase _stepCountUseCase;
        private readonly StepCountView _stepCountView;

        public StepCountPresenter(StepCountUseCase stepCountUseCase, StepCountView stepCountView)
        {
            _stepCountUseCase = stepCountUseCase;
            _stepCountView = stepCountView;
        }

        public void Initialize()
        {
            _stepCountUseCase.stepCount
                .Subscribe(_stepCountView.Render)
                .AddTo(_stepCountView);
        }
    }
}