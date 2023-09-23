using System;
using DG.Tweening;
using OneButton.Common;
using UniEx;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.Base.Presentation.View
{
    public abstract class BaseButtonView : MonoBehaviour
    {
        [SerializeField] private Button button = default;
        [SerializeField] private SeType seType = SeType.Decision;
        [SerializeField] private bool isPlayScaleAnimation = true;
        [SerializeField] private bool isPlaySe = true;

        private readonly float _duration = 0.1f;

        private bool _isInit;

        public Action pushed;

        public void Init(Action<SeType> playSe)
        {
            if (_isInit) return;
            _isInit = true;

            if (isPlayScaleAnimation)
            {
                var rectTransform = button.transform.ToRectTransform();
                var scale = rectTransform.localScale;

                pushed += () =>
                {
                    // 押下時のアニメーション
                    DOTween.Sequence()
                        .Append(rectTransform
                            .DOScale(scale * 0.8f, _duration))
                        .Append(rectTransform
                            .DOScale(scale, _duration))
                        .SetLink(gameObject);
                };
            }

            if (isPlaySe)
            {
                pushed += () => playSe?.Invoke(seType);
            }

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

        public virtual void Activate(bool value)
        {
            button.interactable = value;
        }

        public void SetImage(Sprite sprite)
        {
            button.image.sprite = sprite;
        }
    }
}