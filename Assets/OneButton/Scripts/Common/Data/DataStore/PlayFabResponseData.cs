using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OneButton.Common.Data.Entity;
using PlayFab.ClientModels;

namespace OneButton.Common.Data.DataStore
{
    public sealed class PlayFabResponseData
    {
        public sealed class MasterData
        {
            private readonly Dictionary<string, string> _resultData;

            public MasterData(Dictionary<string, string> resultData)
            {
                _resultData = resultData;
            }

            public T DeserializeMaster<T>(string key)
            {
                return _resultData.TryGetValue(key, out var json)
                    ? JsonConvert.DeserializeObject<T>(json)
                    : throw new CrashException(ExceptionConfig.FAILED_DESERIALIZE_MASTER);
            }
        }

        public sealed class RankingRecordData
        {
            private readonly List<PlayerLeaderboardEntry> _leaderboard;

            public RankingRecordData(List<PlayerLeaderboardEntry> leaderboard)
            {
                _leaderboard = leaderboard;
            }

            public List<T> DeserializeMaster<T>(string uid) where T : RankingRecordEntity
            {
                return _leaderboard
                    .Select(x => new RankingRecordEntity(x, uid) as T)
                    .ToList();
            }

            public List<CoinRankingRecordEntity> DeserializeCoinRanking(string uid)
            {
                return _leaderboard
                    .Select(x => new CoinRankingRecordEntity(x, uid))
                    .ToList();
            }
        }
    }
}