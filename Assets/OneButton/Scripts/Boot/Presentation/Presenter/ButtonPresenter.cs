using OneButton.Base.Presentation.View;
using OneButton.Common.Domain.UseCase;
using UnityEngine;
using VContainer.Unity;

namespace OneButton.Boot.Presentation.Presenter
{
    public sealed class ButtonPresenter : IInitializable
    {
        private readonly SoundUseCase _soundUseCase;

        public ButtonPresenter(SoundUseCase soundUseCase)
        {
            _soundUseCase = soundUseCase;
        }

        public void Initialize()
        {
            foreach (var buttonView in Object.FindObjectsOfType<BaseButtonView>())
            {
                buttonView.Init(x => _soundUseCase.PlaySe(x));
            }
        }
    }
}