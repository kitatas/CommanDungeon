using PlayFab.ClientModels;

namespace OneButton.Common.Data.Entity
{
    public class RankingRecordEntity
    {
        private readonly PlayerLeaderboardEntry _entry;

        public RankingRecordEntity(PlayerLeaderboardEntry entry, string userId)
        {
            _entry = entry;
            isSelf = id.Equals(userId);
        }

        protected virtual RankingType type { get; }
        public bool isSelf { get; }

        public string id => _entry.PlayFabId;
        public int rank => _entry.Position + 1;
        public string name => _entry.DisplayName;

        public virtual float GetScore()
        {
            return _entry.Profile.Statistics?.Find(x => x.Name == type.ToKey())?.Value ?? 0;
        }
    }

    public sealed class CoinRankingRecordEntity : RankingRecordEntity
    {
        public CoinRankingRecordEntity(PlayerLeaderboardEntry entry, string userId) : base(entry, userId)
        {
        }

        protected override RankingType type => RankingType.Coin;
    }
}