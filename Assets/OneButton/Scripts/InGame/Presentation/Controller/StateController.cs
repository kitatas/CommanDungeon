using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class StateController
    {
        private readonly List<BaseState> _states;

        public StateController(SlotState slot, MoveState move, StepState step, FinishState finish, ResultState result,
            RankingState ranking)
        {
            _states = new List<BaseState>
            {
                slot,
                move,
                step,
                finish,
                result,
                ranking,
            };
        }

        public async UniTaskVoid InitAsync(CancellationToken token)
        {
            foreach (var state in _states)
            {
                state.InitAsync(token).Forget();
            }

            await UniTask.Yield(token);
        }

        public async UniTask<GameState> TickAsync(GameState state, CancellationToken token)
        {
            var currentState = _states.Find(x => x.state == state);
            if (currentState == null)
            {
                throw new Exception(ExceptionConfig.NOT_FOUND_STATE);
            }

            return await currentState.TickAsync(token);
        }
    }
}