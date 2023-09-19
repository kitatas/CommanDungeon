using System.Collections.Generic;
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

        public List<PatternTable> GetPatternTable()
        {
            return _slotTable.data;
        }
    }
}