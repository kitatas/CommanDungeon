using OneButton.Base.Data.Entity;

namespace OneButton.InGame.Data.Entity
{
    public sealed class StepCountEntity : BaseEntity<int>
    {
        public Difficulty GetDifficulty()
        {
            if (value == SlotConfig.THRESHOLD_TITLE) return Difficulty.Title;
            if (value <= SlotConfig.THRESHOLD_EASY) return Difficulty.Easy;
            if (value <= SlotConfig.THRESHOLD_NORMAL) return Difficulty.Normal;
            return Difficulty.Hard;
        }
    }
}