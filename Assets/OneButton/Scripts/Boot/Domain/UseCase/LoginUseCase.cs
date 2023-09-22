using System.Threading;
using Cysharp.Threading.Tasks;

namespace OneButton.Boot.Domain.UseCase
{
    public sealed class LoginUseCase
    {
        // TODO:
        public async UniTask<bool> LoginAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
            return true;
        }

        // TODO:
        public async UniTask<bool> RegisterAsync(string name, CancellationToken token)
        {
            await UniTask.Yield(token);
            return true;
        }
    }
}