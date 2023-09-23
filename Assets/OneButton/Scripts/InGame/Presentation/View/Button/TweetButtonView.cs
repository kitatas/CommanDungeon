using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Base.Presentation.View;
using OneButton.Common;
using UnityEngine;
using UnityEngine.Networking;

namespace OneButton.InGame.Presentation.View
{
    public sealed class TweetButtonView : BaseButtonView
    {
        public async UniTask ShowAsync(float duration, CancellationToken token)
        {
            await Show(duration).WithCancellation(token);
        }

        public async UniTask HideAsync(float duration, CancellationToken token)
        {
            await Hide(duration).WithCancellation(token);
        }

        public void SetUp(RankingType type, int score)
        {
            var tweetText = $"{type.ToName()} でスコア {score} 獲得した！\n";
            Tweet(tweetText);
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