using System;
using OneButton.Base.Domain.UseCase;
using OneButton.InGame.Data.Entity;
using UniRx;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class StepCountUseCase : BaseModelUseCase<int>
    {
        private readonly StepCountEntity _stepCountEntity;
        private readonly ReactiveProperty<Difficulty> _difficulty;

        public StepCountUseCase(StepCountEntity stepCountEntity)
        {
            _stepCountEntity = stepCountEntity;
            _difficulty = new ReactiveProperty<Difficulty>();
        }

        public IObservable<int> stepCount => property.SkipLatestValueOnSubscribe();

        public IReadOnlyReactiveProperty<Difficulty> difficulty => _difficulty;

        public void Increment()
        {
            Set(currentValue + 1);
            _stepCountEntity.Set(currentValue);

            _difficulty.Value = _stepCountEntity.GetDifficulty();
        }
    }
}