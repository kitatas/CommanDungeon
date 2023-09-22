using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Boot.Domain.UseCase;
using OneButton.Boot.Presentation.View;
using OneButton.Common;
using OneButton.Common.Domain.UseCase;

namespace OneButton.Boot.Presentation.Controller
{
    public sealed class CheckState : BaseState
    {
        private readonly AppVersionUseCase _appVersionUseCase;
        private readonly LoadingUseCase _loadingUseCase;
        private readonly SceneUseCase _sceneUseCase;
        private readonly UpdateView _updateView;

        public CheckState(AppVersionUseCase appVersionUseCase, LoadingUseCase loadingUseCase, SceneUseCase sceneUseCase,
            UpdateView updateView)
        {
            _appVersionUseCase = appVersionUseCase;
            _loadingUseCase = loadingUseCase;
            _sceneUseCase = sceneUseCase;
            _updateView = updateView;
        }

        public override BootState state => BootState.Check;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _updateView.HideAsync(0.0f, token).Forget();
            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            _loadingUseCase.Set(true);

            // マスタからバージョンチェック
            var isUpdate = await _appVersionUseCase.CheckUpdateAsync(token);

            _loadingUseCase.Set(false);

            if (isUpdate)
            {
                // 強制アップデート
                _updateView.SetUp(UrlConfig.APP, UiConfig.POPUP_TIME, token).Forget();
                return BootState.None;
            }

            _sceneUseCase.Load(SceneName.Main, LoadType.Direct);
            return BootState.None;
        }
    }
}