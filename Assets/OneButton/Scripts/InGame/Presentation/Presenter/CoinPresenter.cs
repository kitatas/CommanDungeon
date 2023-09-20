using OneButton.Base.Presentation.Presenter;
using OneButton.InGame.Domain.UseCase;
using OneButton.InGame.Presentation.View;

namespace OneButton.InGame.Presentation.Presenter
{
    public sealed class CoinPresenter : BasePresenter<int>
    {
        public CoinPresenter(CoinUseCase coinUseCase, CoinView coinView) : base(coinUseCase, coinView)
        {
        }
    }
}