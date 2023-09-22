using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.Base.Presentation.View
{
    public abstract class BaseButtonView : MonoBehaviour
    {
        [SerializeField] private Button button = default;

        public void Init()
        {
            push.Subscribe(_ =>
                {
                    // play animation
                    // play se
                })
                .AddTo(this);
        }

        protected IObservable<Unit> push => button.OnClickAsObservable();
    }
}