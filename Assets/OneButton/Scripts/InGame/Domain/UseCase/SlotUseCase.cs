using OneButton.InGame.Domain.Repository;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class SlotUseCase
    {
        private readonly SlotRepository _slotRepository;

        public SlotUseCase(SlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }

        public Data.DataStore.PatternTable GetPatternData(int index)
        {
            return _slotRepository.GetPatternTable()[index];
        }
    }
}