using System;
using OneButton.Base.Domain.UseCase;
using UniRx;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class StepCountUseCase : BaseModelUseCase<int>
    {
        public IObservable<int> stepCount => property.SkipLatestValueOnSubscribe();

        public void Increment()
        {
            Set(property.Value + 1);
        }
    }
}