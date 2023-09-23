using System;
using DG.Tweening;
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

        public Tween Show(float duration)
        {
            return DOTween.Sequence()
                .Append(button.image
                    .DOFade(1.0f, duration)
                    .SetEase(Ease.Linear))
                .OnComplete(() => Activate(true))
                .SetLink(gameObject);
        }

        public Tween Hide(float duration)
        {
            Activate(false);
            return DOTween.Sequence()
                .Append(button.image
                    .DOFade(0.0f, duration)
                    .SetEase(Ease.Linear))
                .SetLink(gameObject);
        }

        public void Activate(bool value)
        {
            button.interactable = value;
        }
    }
}