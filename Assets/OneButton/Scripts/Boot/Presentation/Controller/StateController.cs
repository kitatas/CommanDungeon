using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;

namespace OneButton.Boot.Presentation.Controller
{
    public sealed class StateController
    {
        private readonly List<BaseState> _states;

        public StateController(LoadState load, LoginState login)
        {
            _states = new List<BaseState>
            {
                load,
                login,
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

        public async UniTask<BootState> TickAsync(BootState state, CancellationToken token)
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