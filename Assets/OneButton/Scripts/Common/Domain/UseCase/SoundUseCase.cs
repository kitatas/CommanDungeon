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

        public SoundUseCase(SaveRepository saveRepository, SoundRepository soundRepository)
        {
            _saveRepository = saveRepository;
            _soundRepository = soundRepository;

            _playBgm = new Subject<SoundEntity>();
        }

        public IObservable<SoundEntity> playBgm => _playBgm;

        public void PlayBgm(BgmType type, float delay = 0.0f)
        {
            var data = _soundRepository.FindBgm(type);
            var soundEntity = new SoundEntity(data.clip, delay);
            _playBgm?.OnNext(soundEntity);
        }
    }
}