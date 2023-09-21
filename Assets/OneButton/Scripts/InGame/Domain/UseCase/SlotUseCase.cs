using OneButton.InGame.Data.Entity;
using OneButton.InGame.Domain.Repository;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class SlotUseCase
    {
        private readonly StepCountEntity _stepCountEntity;
        private readonly SlotRepository _slotRepository;

        public SlotUseCase(StepCountEntity stepCountEntity, SlotRepository slotRepository)
        {
            _stepCountEntity = stepCountEntity;
            _slotRepository = slotRepository;
        }

        public Data.DataStore.PatternTable GetPatternData(int index)
        {
            var difficulty = _stepCountEntity.GetDifficulty();
            var data = _slotRepository.FindByDifficulty(difficulty);
            return data.data[index];
        }
    }
}