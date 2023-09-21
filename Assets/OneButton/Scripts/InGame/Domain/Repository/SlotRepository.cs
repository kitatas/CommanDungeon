using System;
using OneButton.Common;
using OneButton.InGame.Data.DataStore;

namespace OneButton.InGame.Domain.Repository
{
    public sealed class SlotRepository
    {
        private readonly SlotTable _slotTable;

        public SlotRepository(SlotTable slotTable)
        {
            _slotTable = slotTable;
        }

        public SlotData FindByDifficulty(Difficulty difficulty)
        {
            var data = _slotTable.data.Find(x => x.difficulty == difficulty);
            if (data == null || data.data.Count != SlotConfig.REEL_COUNT)
            {
                throw new Exception(ExceptionConfig.NOT_FOUND_REEL_DATA);
            }

            return data;
        }
    }
}