using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;
using OneButton.Common.Domain.UseCase;
using OneButton.Common.Presentation.Controller;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;
using UniRx;
using VContainer.Unity;

namespace OneButton.InGame.Presentation.Presenter
{
    public sealed class UserDataPresenter : IInitializable, IDisposable
    {
        private readonly LoadingUseCase _loadingUseCase;
        private readonly SceneUseCase _sceneUseCase;
        private readonly UserDataUseCase _userDataUseCase;
        private readonly ExceptionController _exceptionController;
        private readonly AccountDeleteView _accountDeleteView;
        private readonly UserNameView _userNameView;
        private readonly CancellationTokenSource _tokenSource;

        public UserDataPresenter(LoadingUseCase loadingUseCase, SceneUseCase sceneUseCase,
            UserDataUseCase userDataUseCase, ExceptionController exceptionController,
            AccountDeleteView accountDeleteView, UserNameView userNameView)
        {
            _loadingUseCase = loadingUseCase;
            _userDataUseCase = userDataUseCase;
            _sceneUseCase = sceneUseCase;
            _exceptionController = exceptionController;
            _accountDeleteView = accountDeleteView;
            _userNameView = userNameView;
            _tokenSource = new CancellationTokenSource();
        }

        public void Initialize()
        {
#if UNITY_WEBGL
            _accountDeleteView.Activate(false);
#else
            _accountDeleteView.Delete()
                .Subscribe(_ =>
                {
                    _userDataUseCase.Delete();
                    _sceneUseCase.Load(SceneName.Boot, LoadType.Fade);
                })
                .AddTo(_tokenSource.Token);
#endif

            _userNameView.Init(_userDataUseCase.GetUserName());
            _userNameView.UpdateName()
                .Subscribe(x => UpdateAsync(x, _tokenSource.Token).Forget())
                .AddTo(_tokenSource.Token);
        }

        private async UniTaskVoid UpdateAsync(string name, CancellationToken token)
        {
            try
            {
                _loadingUseCase.Set(true);

                await _userDataUseCase.UpdateUserNameAsync(name, token);

                _loadingUseCase.Set(false);
            }
            catch (Exception e)
            {
                // 更新失敗だけなのでリトライは考慮しない
                await _exceptionController.ShowExceptionAsync(e, _tokenSource.Token);

                // 変更前の名前に戻す 
                _userNameView.Init(_userDataUseCase.GetUserName());
                throw;
            }
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }
    }
}