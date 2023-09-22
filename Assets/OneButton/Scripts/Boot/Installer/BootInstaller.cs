using OneButton.Boot.Domain.UseCase;
using OneButton.Boot.Presentation.Controller;
using OneButton.Boot.Presentation.Presenter;
using VContainer;
using VContainer.Unity;

namespace OneButton.Boot.Installer
{
    public sealed class BootInstaller : LifetimeScope
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