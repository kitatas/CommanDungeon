using OneButton.InGame.Data.DataStore;
using OneButton.InGame.Data.Entity;
using OneButton.InGame.Domain.Repository;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.Controller;
using OneButton.InGame.Presentation.Presenter;
using OneButton.InGame.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OneButton.InGame.Installer
{
    public sealed class InGameInstaller : LifetimeScope
    {
        [SerializeField] private SlotTable slotTable = default;

        [SerializeField] private MainButtonView mainButtonView = default;
        [SerializeField] private TweetButtonView tweetButtonView = default;
        [SerializeField] private CoinView coinView = default;
        [SerializeField] private FloorItemView floorItemView = default;
        [SerializeField] private HpView hpView = default;
        [SerializeField] private PlayerView playerView = default;
        [SerializeField] private RankingView rankingView = default;
        [SerializeField] private ResultView resultView = default;
        [SerializeField] private SlotView slotView = default;
        [SerializeField] private StageView stageView = default;
        [SerializeField] private StepCountView stepCountView = default;
        [SerializeField] private StepView stepView = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<SlotTable>(slotTable);

            // Entity
            builder.Register<StepCountEntity>(Lifetime.Scoped);

            // Repository
            builder.Register<SlotRepository>(Lifetime.Scoped);

            // UseCase
            builder.Register<CoinUseCase>(Lifetime.Scoped);
            builder.Register<HpUseCase>(Lifetime.Scoped);
            builder.Register<RankingUseCase>(Lifetime.Scoped);
            builder.Register<ScoreUseCase>(Lifetime.Scoped);
            builder.Register<SlotMatchUseCase>(Lifetime.Scoped);
            builder.Register<SlotUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);
            builder.Register<StepCountUseCase>(Lifetime.Scoped);
            builder.Register<UserRecordUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<FinishState>(Lifetime.Scoped);
            builder.Register<MoveState>(Lifetime.Scoped);
            builder.Register<RankingState>(Lifetime.Scoped);
            builder.Register<ResultState>(Lifetime.Scoped);
            builder.Register<SlotState>(Lifetime.Scoped);
            builder.Register<StepState>(Lifetime.Scoped);
            builder.Register<StateController>(Lifetime.Scoped);

            // Presenter
            builder.RegisterEntryPoint<ButtonPresenter>();
            builder.RegisterEntryPoint<CoinPresenter>();
            builder.RegisterEntryPoint<HpPresenter>();
            builder.RegisterEntryPoint<StatePresenter>();
            builder.RegisterEntryPoint<StepCountPresenter>();

            // View
            builder.RegisterInstance<MainButtonView>(mainButtonView);
            builder.RegisterInstance<TweetButtonView>(tweetButtonView);
            builder.RegisterInstance<FloorItemView>(floorItemView);
            builder.RegisterInstance<CoinView>(coinView);
            builder.RegisterInstance<HpView>(hpView);
            builder.RegisterInstance<PlayerView>(playerView);
            builder.RegisterInstance<RankingView>(rankingView);
            builder.RegisterInstance<ResultView>(resultView);
            builder.RegisterInstance<SlotView>(slotView);
            builder.RegisterInstance<StageView>(stageView);
            builder.RegisterInstance<StepCountView>(stepCountView);
            builder.RegisterInstance<StepView>(stepView);
        }
    }
}