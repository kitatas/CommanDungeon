using System;
using OneButton.Base.Domain.UseCase;
using OneButton.InGame.Data.Entity;
using UniRx;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class StepCountUseCase : BaseModelUseCase<int>
    {
        private readonly StepCountEntity _stepCountEntity;

        public StepCountUseCase(StepCountEntity stepCountEntity)
        {
            _stepCountEntity = stepCountEntity;
        }

        public IObservable<int> stepCount => property.SkipLatestValueOnSubscribe();

        public void Increment()
        {
            Set(currentValue + 1);
            _stepCountEntity.Set(currentValue);
        }
    }
}