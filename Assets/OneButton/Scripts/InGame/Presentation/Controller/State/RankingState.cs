using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;
using OneButton.Common.Domain.UseCase;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;

namespace OneButton.InGame.Presentation.Controller
{
    public sealed class RankingState : BaseState
    {
        private readonly RankingUseCase _rankingUseCase;
        private readonly SceneUseCase _sceneUseCase;
        private readonly MainButtonView _mainButtonView;
        private readonly RankingView _rankingView;

        public RankingState(RankingUseCase rankingUseCase, SceneUseCase sceneUseCase, MainButtonView mainButtonView,
            RankingView rankingView)
        {
            _rankingUseCase = rankingUseCase;
            _sceneUseCase = sceneUseCase;
            _mainButtonView = mainButtonView;
            _rankingView = rankingView;
        }

        public override GameState state => GameState.Ranking;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _rankingView.HideAsync(0.0f, token).Forget();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            // ランキングのレコード取得
            var records = await _rankingUseCase.GetRankingAsync(token);
            _rankingView.SetUp(records);

            await _rankingView.ShowAsync(UiConfig.POPUP_TIME, token);

            await _mainButtonView.PushAsync(token);
            _sceneUseCase.Load(SceneName.Main, LoadType.Fade);

            return GameState.None;
        }
    }
}