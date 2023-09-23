using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common;
using OneButton.Common.Data.Entity;
using OneButton.Common.Domain.Repository;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class RankingUseCase
    {
        private readonly UserEntity _userEntity;
        private readonly PlayFabRepository _playFabRepository;

        public RankingUseCase(UserEntity userEntity, PlayFabRepository playFabRepository)
        {
            _userEntity = userEntity;
            _playFabRepository = playFabRepository;
        }

        public async UniTask<List<RankingRecordEntity>> GetRankingAsync(CancellationToken token)
        {
            var type = RankingType.Coin;
            var recordData = await _playFabRepository.GetRankDataAsync(type, token);
            var rankingEntities = recordData.DeserializeCoinRanking(_userEntity.id);
            return rankingEntities.Select(x => x as RankingRecordEntity).ToList();
        }
    }
}