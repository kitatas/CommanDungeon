using Newtonsoft.Json;

namespace OneButton.Common.Data.Entity
{
    public sealed class UserPlayEntity
    {
        public int playCount;
        public RecordEntity ranking;

        public static UserPlayEntity Default()
        {
            return new UserPlayEntity
            {
                playCount = 0,
                ranking = RecordEntity.Default(),
            };
        }

        public UserPlayEntity UpdateByPlay(float score)
        {
            return new UserPlayEntity
            {
                playCount = playCount + 1,
                ranking = ranking.Update(score),
            };
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}