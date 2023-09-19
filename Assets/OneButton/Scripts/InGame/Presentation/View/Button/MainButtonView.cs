using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Base.Presentation.View;

namespace OneButton.InGame.Presentation.View
{
    public sealed class MainButtonView : BaseButtonView
    {
        public async UniTask PushAsync(CancellationToken token)
        {
            await push.ToUniTask(true, token);
        }
    }
}