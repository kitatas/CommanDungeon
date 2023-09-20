using OneButton.Base.Presentation.Presenter;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;

namespace OneButton.InGame.Presentation.Presenter
{
    public sealed class HpPresenter : BasePresenter<int>
    {
        public HpPresenter(HpUseCase hpUseCase, HpView hpView) : base(hpUseCase, hpView)
        {
        }
    }
}