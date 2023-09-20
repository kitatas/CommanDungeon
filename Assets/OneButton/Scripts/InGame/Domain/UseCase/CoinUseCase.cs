using OneButton.Base.Domain.UseCase;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class CoinUseCase : BaseModelUseCase<int>
    {
        public void Increase(int value)
        {
            Set(property.Value + value);
        }
    }
}