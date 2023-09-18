using System;
using OneButton.Base.Domain.UseCase;
using UniRx;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class StateUseCase : BaseModelUseCase<GameState>
    {
        public StateUseCase()
        {
            Set(GameConfig.INIT_STATE);
        }

        public IObservable<GameState> gameState => property.Where(x => x != GameState.None);

        public bool IsState(GameState state)
        {
            return property.Value == state;
        }
    }
}