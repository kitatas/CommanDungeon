using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.Base.Presentation.View
{
    public abstract class BaseButtonView : MonoBehaviour
    {
        [SerializeField] private Button button = default;

        public Action pushed;

        public void Init()
        {
            // play animation
            // play se

            push.Subscribe(_ => pushed?.Invoke())
                .AddTo(this);
        }

        protected IObservable<Unit> push => button.OnClickAsObservable();
    }
}