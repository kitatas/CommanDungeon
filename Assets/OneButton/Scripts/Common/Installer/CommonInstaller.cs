using OneButton.Common.Data.DataStore;
using OneButton.Common.Data.Entity;
using OneButton.Common.Domain.Repository;
using OneButton.Common.Domain.UseCase;
using OneButton.Common.Presentation.Controller;
using OneButton.Common.Presentation.Presenter;
using OneButton.Common.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OneButton.Common.Installer
{
    public sealed class CommonInstaller : LifetimeScope
    {
        [SerializeField] private BgmTable bgmTable = default;
        [SerializeField] private SeTable seTable = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<BgmTable>(bgmTable);
            builder.RegisterInstance<SeTable>(seTable);

            // Entity
            builder.Register<UserEntity>(Lifetime.Singleton);

            // Repository
            builder.Register<PlayFabRepository>(Lifetime.Singleton);
            builder.Register<SaveRepository>(Lifetime.Singleton);
            builder.Register<SoundRepository>(Lifetime.Singleton);

            // UseCase
            builder.Register<LoadingUseCase>(Lifetime.Singleton);
            builder.Register<SceneUseCase>(Lifetime.Singleton);
            builder.Register<SoundUseCase>(Lifetime.Singleton);

            // Controller
            builder.Register<ExceptionController>(Lifetime.Singleton);

            // Presenter
            builder.RegisterEntryPoint<LoadingPresenter>();
            builder.RegisterEntryPoint<ScenePresenter>();
            builder.RegisterEntryPoint<SoundPresenter>();

            // View
            builder.RegisterInstance<CrashView>(FindFirstObjectByType<CrashView>());
            builder.RegisterInstance<LoadingView>(FindFirstObjectByType<LoadingView>());
            builder.RegisterInstance<RetryView>(FindFirstObjectByType<RetryView>());
            builder.RegisterInstance<RebootView>(FindFirstObjectByType<RebootView>());
            builder.RegisterInstance<SoundView>(FindFirstObjectByType<SoundView>());
            builder.RegisterInstance<TransitionView>(FindFirstObjectByType<TransitionView>());
        }
    }
}