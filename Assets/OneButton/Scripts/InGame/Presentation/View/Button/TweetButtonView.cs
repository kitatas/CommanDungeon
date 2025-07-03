using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using OneButton.Base.Presentation.View;
using OneButton.Common;
using TMPro;
using UniEx;
using UnityEngine;
using UnityEngine.Networking;

namespace OneButton.InGame.Presentation.View
{
    public sealed class TweetButtonView : BaseButtonView
    {
        [SerializeField] private Sprite normal = default;
        [SerializeField] private Sprite press = default;
        [SerializeField] private TextMeshProUGUI buttonText = default;

        public async UniTask ShowAsync(float duration, CancellationToken token)
        {
            await (
                FadeButtonText(1.0f, duration).WithCancellation(token),
                Show(duration).WithCancellation(token)
            );
        }

        public async UniTask HideAsync(float duration, CancellationToken token)
        {
            await (
                FadeButtonText(0.0f, duration).WithCancellation(token),
                Hide(duration).WithCancellation(token)
            );
        }

        private Tween FadeButtonText(float endValue, float duration)
        {
            return buttonText
                .DOFade(endValue, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        public void SetUp(RankingType type, int stepCount, int score)
        {
            SetNormal();
            pushed += () =>
            {
                SetPress();
                this.Delay(UiConfig.PRESS_TIME, SetNormal);
            };

            var tweetText = $"{type.ToName()} で B{stepCount}F まで到達した！\nスコアは {score}\n";
            Tweet(tweetText);
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

        private void Tweet(string tweetText)
        {
#if UNITY_WEBGL
            tweetText += $"#{GameConfig.GAME_ID} #unity1week\n";
            pushed += () => naichilab.UnityRoomTweet.Tweet(GameConfig.GAME_ID, tweetText);
#elif UNITY_ANDROID
            tweetText += $"#{GameConfig.GAME_ID}\n";
            tweetText += $"{UrlConfig.APP}";
            var url = $"https://twitter.com/intent/tweet?text={UnityWebRequest.EscapeURL(tweetText)}";
            pushed += () => Application.OpenURL(url);
#endif
        }
    }
}