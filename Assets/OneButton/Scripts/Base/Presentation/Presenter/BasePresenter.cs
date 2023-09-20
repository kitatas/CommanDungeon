using OneButton.Base.Domain.UseCase;
using OneButton.Base.Presentation.View;
using UniRx;
using VContainer.Unity;

namespace OneButton.Base.Presentation.Presenter
{
    public abstract class BasePresenter<T> : IInitializable
    {
        private readonly BaseModelUseCase<T> _modelUseCase;
        private readonly BaseView<T> _view;

        public BasePresenter(BaseModelUseCase<T> modelUseCase, BaseView<T> view)
        {
            _modelUseCase = modelUseCase;
            _view = view;
        }

        public virtual void Initialize()
        {
            _modelUseCase.property
                .Subscribe(_view.Render)
                .AddTo(_view);
        }
    }
}