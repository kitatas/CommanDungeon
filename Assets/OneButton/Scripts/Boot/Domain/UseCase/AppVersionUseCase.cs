using System.Threading;
using Cysharp.Threading.Tasks;

namespace OneButton.Boot.Domain.UseCase
{
    public sealed class AppVersionUseCase
    {
        // TODO:
        public async UniTask<bool> CheckUpdateAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
            return false;
        }
    }
}