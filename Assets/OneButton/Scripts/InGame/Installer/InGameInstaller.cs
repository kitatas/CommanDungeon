using OneButton.InGame.Data.DataStore;
using OneButton.InGame.Domain.Repository;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.Controller;
using OneButton.InGame.Presentation.Presenter;
using VContainer;
using VContainer.Unity;

namespace OneButton.InGame.Installer
{
    public sealed class InGameInstaller : LifetimeScope
    {
        [SerializeField] private SlotTable slotTable = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<SlotTable>(slotTable);

            // Repository
            builder.Register<SlotRepository>(Lifetime.Scoped);

            // UseCase
            builder.Register<SlotUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<StateController>(Lifetime.Scoped);

            // Presenter
            builder.RegisterEntryPoint<StatePresenter>();
        }
    }
}