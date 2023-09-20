using OneButton.InGame.Data.DataStore;
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
        [SerializeField] private HpView hpView = default;
        [SerializeField] private PlayerView playerView = default;
        [SerializeField] private SlotView slotView = default;
        [SerializeField] private StageView stageView = default;
        [SerializeField] private StepCountView stepCountView = default;
        [SerializeField] private StepView stepView = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<SlotTable>(slotTable);

            // Repository
            builder.Register<SlotRepository>(Lifetime.Scoped);

            // UseCase
            builder.Register<HpUseCase>(Lifetime.Scoped);
            builder.Register<SlotUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);
            builder.Register<StepCountUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<FinishState>(Lifetime.Scoped);
            builder.Register<MoveState>(Lifetime.Scoped);
            builder.Register<SlotState>(Lifetime.Scoped);
            builder.Register<StepState>(Lifetime.Scoped);
            builder.Register<StateController>(Lifetime.Scoped);

            // Presenter
            builder.RegisterEntryPoint<HpPresenter>();
            builder.RegisterEntryPoint<StatePresenter>();
            builder.RegisterEntryPoint<StepCountPresenter>();

            // View
            builder.RegisterInstance<MainButtonView>(mainButtonView);
            builder.RegisterInstance<HpView>(hpView);
            builder.RegisterInstance<PlayerView>(playerView);
            builder.RegisterInstance<SlotView>(slotView);
            builder.RegisterInstance<StageView>(stageView);
            builder.RegisterInstance<StepCountView>(stepCountView);
            builder.RegisterInstance<StepView>(stepView);
        }
    }
}