using System;
using OneButton.Base.Domain.UseCase;
using UniRx;

namespace OneButton.Boot.Domain.UseCase
{
    public sealed class StateUseCase : BaseModelUseCase<BootState>
    {
        public StateUseCase()
        {
            Set(BootConfig.INIT_STATE);
        }

        public IObservable<BootState> bootState => property.Where(x => x != BootState.None);
    }
}