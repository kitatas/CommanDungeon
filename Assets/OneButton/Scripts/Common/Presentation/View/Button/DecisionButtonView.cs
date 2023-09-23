using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Base.Presentation.View;
using UniRx;

namespace OneButton.Common.Presentation.View
{
    public sealed class DecisionButtonView : BaseButtonView
    {
        public async UniTask PushAsync(CancellationToken token)
        {
            await push.ToUniTask(true, token);
        }

        public IObservable<Unit> Decision()
        {
            return push;
        }
    }
}