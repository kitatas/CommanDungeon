using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using OneButton.Base.Presentation.View;
using OneButton.Common;
using TMPro;
using UniEx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class MainButtonView : BaseButtonView
    {
        [SerializeField] private Sprite normal = default;
        [SerializeField] private Sprite press = default;
        [SerializeField] private TextMeshProUGUI buttonText = default;

        public void Init()
        {
            SetNormal();
            pushed += () =>
            {
                SetPress();
                this.Delay(UiConfig.PRESS_TIME, SetNormal);
            };
        }

        private void SetNormal()
        {
            SetImage(normal);
            buttonText.rectTransform
                .DOAnchorPosY(UiConfig.MAIN_BUTTON_TEXT_DEFAULT_HEIGHT, 0.0f);
        }

        private void SetPress()
        {
            SetImage(press);
            buttonText.rectTransform
                .DOAnchorPosY(UiConfig.MAIN_BUTTON_TEXT_PRESS_HEIGHT, 0.0f);
        }

        public override void Activate(bool value)
        {
            base.Activate(value);

            var alpha = value ? 1.0f : 0.5f;
            buttonText.SetColorA(alpha);
        }

        public async UniTask PushAsync(CancellationToken token)
        {
            await push.ToUniTask(true, token);
        }
    }
}