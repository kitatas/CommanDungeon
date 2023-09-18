using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.Controller;
using OneButton.InGame.Presentation.Presenter;
using VContainer;
using VContainer.Unity;

namespace OneButton.InGame.Installer
{
    public sealed class InGameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // UseCase
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<StateController>(Lifetime.Scoped);

            // Presenter
            builder.RegisterEntryPoint<StatePresenter>();
        }
    }
}