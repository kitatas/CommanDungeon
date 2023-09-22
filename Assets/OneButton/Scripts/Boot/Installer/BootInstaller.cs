using OneButton.Boot.Domain.UseCase;
using OneButton.Boot.Presentation.Controller;
using OneButton.Boot.Presentation.Presenter;
using OneButton.Boot.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OneButton.Boot.Installer
{
    public sealed class BootInstaller : LifetimeScope
    {
        [SerializeField] private RegisterView registerView = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // UseCase
            builder.Register<LoginUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<LoadState>(Lifetime.Scoped);
            builder.Register<LoginState>(Lifetime.Scoped);
            builder.Register<StateController>(Lifetime.Scoped);

            // Presenter
            builder.RegisterEntryPoint<StatePresenter>();

            // View
            builder.RegisterInstance<RegisterView>(registerView);
        }
    }
}