using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Base.Presentation.View;

namespace OneButton.Common.Presentation.View
{
    public sealed class ExceptionButtonView : BaseButtonView
    {
        public async UniTask PushAsync(CancellationToken token)
        {
            await push.ToUniTask(true, token);
        }
    }
}