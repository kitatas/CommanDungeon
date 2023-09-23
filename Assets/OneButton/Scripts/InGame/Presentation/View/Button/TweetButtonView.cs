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
            buttonText
                .DOFade(1.0f, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);

            await Show(duration).WithCancellation(token);
        }

        public async UniTask HideAsync(float duration, CancellationToken token)
        {
            buttonText
                .DOFade(0.0f, duration)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);

            await Hide(duration).WithCancellation(token);
        }

        public void SetUp(RankingType type, int score)
        {
            SetNormal();
            pushed += () =>
            {
                SetPress();
                this.Delay(UiConfig.PRESS_TIME, SetNormal);
            };

            var tweetText = $"{type.ToName()} でスコア {score} 獲得した！\n";
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