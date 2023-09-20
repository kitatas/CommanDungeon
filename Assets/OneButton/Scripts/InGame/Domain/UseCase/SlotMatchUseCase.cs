using OneButton.Base.Domain.UseCase;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class SlotMatchUseCase : BaseModelUseCase<int>
    {
        public void Increment()
        {
            Set(currentValue + 1);
        }
    }
}