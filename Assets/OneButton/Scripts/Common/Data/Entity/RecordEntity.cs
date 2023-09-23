namespace OneButton.Common.Data.Entity
{
    public class RecordEntity
    {
        public float current;
        public float high;

        public static RecordEntity Default()
        {
            return new RecordEntity
            {
                current = 0.0f,
                high = 0.0f,
            };
        }

        public RecordEntity Update(float score)
        {
            return new RecordEntity
            {
                current = score,
                high = score > high ? score : high,
            };
        }

        public int GetCurrentForRanking()
        {
            return (int)(current * PlayFabConfig.SCORE_RATE);
        }
    }
}