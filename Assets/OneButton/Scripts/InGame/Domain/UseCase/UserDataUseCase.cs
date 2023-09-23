using System.Threading;
using Cysharp.Threading.Tasks;
using OneButton.Common.Data.Entity;
using OneButton.Common.Domain.Repository;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class UserDataUseCase
    {
        private readonly UserEntity _userEntity;
        private readonly PlayFabRepository _playFabRepository;
        private readonly SaveRepository _saveRepository;

        public UserDataUseCase(UserEntity userEntity, PlayFabRepository playFabRepository,
            SaveRepository saveRepository)
        {
            _userEntity = userEntity;
            _playFabRepository = playFabRepository;
            _saveRepository = saveRepository;
        }

        public string GetUserName()
        {
            return _userEntity.nameEntity.name;
        }

        public int GetPlayCount()
        {
            return _userEntity.playEntity.playCount;
        }

        public async UniTask<bool> UpdateUserNameAsync(string name, CancellationToken token)
        {
            var nameEntity = new UserNameEntity(name);
            var isSuccess = await _playFabRepository.UpdateUserNameAsync(nameEntity, token);
            if (isSuccess)
            {
                _userEntity.SetName(nameEntity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete()
        {
            _saveRepository.Delete();
        }
    }
}