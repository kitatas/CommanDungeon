using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common.Data.DataStore;
using OneButton.Common.Data.Entity;
using PlayFab;
using PlayFab.ClientModels;

namespace OneButton.Common.Domain.Repository
{
    public sealed class PlayFabRepository
    {
        public PlayFabRepository()
        {
            PlayFabSettings.staticSettings.TitleId = PlayFabConfig.TITLE_ID;
        }

        public async UniTask<PlayFabResponseData.MasterData> FetchMasterDataAsync(CancellationToken token)
        {
            var response = await PlayFabHelper.CallApiAsync<GetTitleDataRequest, GetTitleDataResult>(
                PlayFabRequestData.GetTitleDataRequest(),
                PlayFabClientAPI.GetTitleData,
                _ => new RetryException(ExceptionConfig.FAILED_RESPONSE_DATA),
                new RetryException(ExceptionConfig.FAILED_RESPONSE_DATA),
                token
            );

            var data = response.Data;
            if (data == null)
            {
                throw new RebootException(ExceptionConfig.NOT_FOUND_DATA);
            }

            return new PlayFabResponseData.MasterData(data);
        }

        public async UniTask<LoginResult> LoginUserAsync(string uid, CancellationToken token)
        {
            return await PlayFabHelper.CallApiAsync<LoginWithCustomIDRequest, LoginResult>(
                PlayFabRequestData.LoginWithCustomIDRequest(uid),
                PlayFabClientAPI.LoginWithCustomID,
                _ => new RetryException(ExceptionConfig.FAILED_LOGIN),
                new RetryException(ExceptionConfig.FAILED_LOGIN),
                token
            );
        }

        public UserEntity FetchUserData(LoginResult response)
        {
            var payload = response.InfoResultPayload;
            if (payload == null)
            {
                throw new RebootException(ExceptionConfig.NOT_FOUND_DATA);
            }

            var userDataRecord = payload.UserData;
            if (userDataRecord == null)
            {
                throw new RebootException(ExceptionConfig.NOT_FOUND_DATA);
            }

            var profile = payload.PlayerProfile;
            var userId = profile == null ? "" : profile.PlayerId;
            var userName = profile == null ? "" : profile.DisplayName;
            return UserData.New(userId, userName, userDataRecord);
        }

        public async UniTask<bool> UpdateUserNameAsync(UserNameEntity nameEntity, CancellationToken token)
        {
            await PlayFabHelper.CallApiAsync<UpdateUserTitleDisplayNameRequest, UpdateUserTitleDisplayNameResult>(
                PlayFabRequestData.UpdateUserTitleDisplayNameRequest(nameEntity),
                PlayFabClientAPI.UpdateUserTitleDisplayName,
                e => GetUpdateUserNameException(e.Error),
                new RetryException(ExceptionConfig.FAILED_LOGIN),
                token
            );

            return true;
        }

        private static RetryException GetUpdateUserNameException(PlayFabErrorCode errorCode)
        {
            // 名前更新失敗の要因を2つに絞る
            // 登録済みのユーザー名 or それ以外
            var message = errorCode == PlayFabErrorCode.NameNotAvailable
                ? ExceptionConfig.UNMATCHED_USER_NAME_RULE
                : ExceptionConfig.FAILED_UPDATE_DATA;
            return new RetryException(message);
        }

        public async UniTask UpdatePlayRecordAsync(UserPlayEntity playEntity, CancellationToken token)
        {
            await PlayFabHelper.CallApiAsync<UpdateUserDataRequest, UpdateUserDataResult>(
                PlayFabRequestData.UpdateUserDataRequest(playEntity),
                PlayFabClientAPI.UpdateUserData,
                _ => new RetryException(ExceptionConfig.FAILED_UPDATE_DATA),
                new RetryException(ExceptionConfig.FAILED_UPDATE_DATA),
                token
            );
        }

        public async UniTask SendRankingAsync(RankingType type, RecordEntity recordEntity,
            CancellationToken token)
        {
            await PlayFabHelper.CallApiAsync<UpdatePlayerStatisticsRequest, UpdatePlayerStatisticsResult>(
                PlayFabRequestData.UpdatePlayerStatisticsRequest(type, recordEntity),
                PlayFabClientAPI.UpdatePlayerStatistics,
                _ => new RetryException(ExceptionConfig.FAILED_UPDATE_DATA),
                new RetryException(ExceptionConfig.FAILED_UPDATE_DATA),
                token
            );
        }

        public async UniTask<PlayFabResponseData.RankingRecordData> GetRankDataAsync(RankingType type, CancellationToken token)
        {
            var response = await PlayFabHelper.CallApiAsync<GetLeaderboardRequest, GetLeaderboardResult>(
                PlayFabRequestData.GetLeaderboardRequest(type),
                PlayFabClientAPI.GetLeaderboard,
                _ => new RetryException(ExceptionConfig.FAILED_RESPONSE_DATA),
                new RetryException(ExceptionConfig.FAILED_RESPONSE_DATA),
                token
            );

            var leaderboard = response.Leaderboard;
            if (leaderboard == null)
            {
                throw new RebootException(ExceptionConfig.NOT_FOUND_DATA);
            }

            return new PlayFabResponseData.RankingRecordData(leaderboard);
        }
    }
}