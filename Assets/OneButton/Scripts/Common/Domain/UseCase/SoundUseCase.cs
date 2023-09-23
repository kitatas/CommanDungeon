using System;
using OneButton.Common.Data.Entity;
using OneButton.Common.Domain.Repository;
using UniRx;

namespace OneButton.Common.Domain.UseCase
{
    public sealed class SoundUseCase
    {
        private readonly SaveRepository _saveRepository;
        private readonly SoundRepository _soundRepository;

        private readonly Subject<SoundEntity> _playBgm;
        private readonly Subject<SoundEntity> _playSe;
        private readonly ReactiveProperty<float> _bgmVolume;
        private readonly ReactiveProperty<float> _seVolume;

        public SoundUseCase(SaveRepository saveRepository, SoundRepository soundRepository)
        {
            _saveRepository = saveRepository;
            _soundRepository = soundRepository;

            var data = _saveRepository.Load();
            _playBgm = new Subject<SoundEntity>();
            _playSe = new Subject<SoundEntity>();
            _bgmVolume = new ReactiveProperty<float>(data.bgmVolume);
            _seVolume = new ReactiveProperty<float>(data.seVolume);
        }

        public IObservable<SoundEntity> playBgm => _playBgm;
        public IObservable<SoundEntity> playSe => _playSe;
        public IObservable<float> bgmVolume => _bgmVolume;
        public IObservable<float> seVolume => _seVolume;
        public float bgmVolumeValue => _bgmVolume.Value;
        public float seVolumeValue => _seVolume.Value;

        public void PlayBgm(BgmType type, float delay = 0.0f)
        {
            var data = _soundRepository.FindBgm(type);
            var soundEntity = new SoundEntity(data.clip, delay);
            _playBgm?.OnNext(soundEntity);
        }

        public void PlaySe(SeType type, float delay = 0.0f)
        {
            var data = _soundRepository.FindSe(type);
            var soundEntity = new SoundEntity(data.clip, delay);
            _playSe?.OnNext(soundEntity);
        }

        public void SetBgmVolume(float value)
        {
            _bgmVolume.Value = value;
            _saveRepository.SaveBgm(value);
        }

        public void SetSeVolume(float value)
        {
            _seVolume.Value = value;
            _saveRepository.SaveSe(value);
        }
    }
}