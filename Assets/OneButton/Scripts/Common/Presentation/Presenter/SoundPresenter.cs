using OneButton.Common.Domain.UseCase;
using OneButton.Common.Presentation.View;
using UniRx;
using VContainer.Unity;

namespace OneButton.Common.Presentation.Presenter
{
    public sealed class SoundPresenter : IInitializable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly SoundView _soundView;

        public SoundPresenter(SoundUseCase soundUseCase, SoundView soundView)
        {
            _soundUseCase = soundUseCase;
            _soundView = soundView;
        }

        public void Initialize()
        {
            _soundUseCase.playBgm
                .Subscribe(x => _soundView.PlayBgm(x.clip, x.delay))
                .AddTo(_soundView);
        }
    }
}