using System.Collections.Generic;
using OneButton.Common.Data.Entity;
using PlayFab.ClientModels;

namespace OneButton.Common.Data.DataStore
{
    public sealed class PlayFabRequestData
    {
        public static GetTitleDataRequest GetTitleDataRequest()
        {
            return new GetTitleDataRequest();
        }

        public static LoginWithCustomIDRequest LoginWithCustomIDRequest(string uid)
        {
            return new LoginWithCustomIDRequest
            {
                CustomId = uid,
                CreateAccount = true,
                InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
                {
                    GetUserData = true,
                    GetPlayerProfile = true,
                },
            };
        }

        public static UpdateUserTitleDisplayNameRequest UpdateUserTitleDisplayNameRequest(UserNameEntity nameEntity)
        {
            return new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = nameEntity.name,
            };
        }

        public static UpdateUserDataRequest UpdateUserDataRequest(UserPlayEntity playEntity)
        {
            return new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                    { PlayFabConfig.USER_PLAY_RECORD_KEY, playEntity.ToJson() },
                },
            };
        }

        public static UpdatePlayerStatisticsRequest UpdatePlayerStatisticsRequest(RankingType type,
            RecordEntity recordEntity)
        {
            return new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate
                    {
                        StatisticName = type.ToKey(),
                        Value = recordEntity.GetCurrentForRanking(),
                    },
                },
            };
        }

        public static GetLeaderboardRequest GetLeaderboardRequest(RankingType type)
        {
            return new GetLeaderboardRequest
            {
                StatisticName = type.ToKey(),
                ProfileConstraints = new PlayerProfileViewConstraints
                {
                    ShowDisplayName = true,
                    ShowStatistics = true,
                },
                MaxResultsCount = PlayFabConfig.SHOW_MAX_RANKING,
            };
        }
    }
}