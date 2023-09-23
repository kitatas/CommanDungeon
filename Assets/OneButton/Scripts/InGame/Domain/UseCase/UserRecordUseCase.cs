using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;
using OneButton.Common.Data.Entity;
using OneButton.Common.Domain.Repository;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class UserRecordUseCase
    {
        private readonly UserEntity _userEntity;
        private readonly PlayFabRepository _playFabRepository;

        public UserRecordUseCase(UserEntity userEntity, PlayFabRepository playFabRepository)
        {
            _userEntity = userEntity;
            _playFabRepository = playFabRepository;
        }

        public async UniTask SendScoreAsync(float score, CancellationToken token)
        {
            var playEntity = _userEntity.playEntity.UpdateByPlay(score);
            await UniTask.WhenAll(
                _playFabRepository.UpdatePlayRecordAsync(playEntity, token),
                _playFabRepository.SendRankingAsync(RankingType.Coin, playEntity.ranking, token)
            );

            _userEntity.SetPlay(playEntity);
        }

        public RecordEntity GetUserScore()
        {
            return _userEntity.playEntity.ranking;
        }
    }
}