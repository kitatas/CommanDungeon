using OneButton.Base.Presentation.View;
using OneButton.Common.Domain.UseCase;
using OneButton.InGame.Presentation.View;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace OneButton.InGame.Presentation.Presenter
{
    public sealed class ButtonPresenter : IInitializable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly VolumeView _volumeView;

        public ButtonPresenter(SoundUseCase soundUseCase, VolumeView volumeView)
        {
            _soundUseCase = soundUseCase;
            _volumeView = volumeView;
        }

        public void Initialize()
        {
            foreach (var buttonView in Object.FindObjectsByType<BaseButtonView>(FindObjectsSortMode.None))
            {
                buttonView.Init(x => _soundUseCase.PlaySe(x));
            }

            _volumeView.Init(_soundUseCase.bgmVolumeValue, _soundUseCase.seVolumeValue);

            _volumeView.updateBgmVolume
                .Subscribe(_soundUseCase.SetBgmVolume)
                .AddTo(_volumeView);

            _volumeView.updateSeVolume
                .Subscribe(_soundUseCase.SetSeVolume)
                .AddTo(_volumeView);

            _volumeView.releaseVolume
                .Subscribe(x => _soundUseCase.PlaySe(x))
                .AddTo(_volumeView);
        }
    }
}