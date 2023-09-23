using System.Collections.Generic;
using Newtonsoft.Json;
using OneButton.Common.Data.Entity;
using PlayFab.ClientModels;

namespace OneButton.Common.Data.DataStore
{
    public sealed class UserData
    {
        public static UserEntity New(string uid, string name, Dictionary<string, UserDataRecord> records)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new UserEntity
                {
                    id = uid,
                    // UserNameEntity の初期化は行わない 
                    playEntity = GetUserPlay(records),
                };
            }
            else
            {
                return new UserEntity
                {
                    id = uid,
                    nameEntity = new UserNameEntity(name),
                    playEntity = GetUserPlay(records),
                };
            }
        }

        private static UserPlayEntity GetUserPlay(Dictionary<string, UserDataRecord> records)
        {
            return records.TryGetValue(PlayFabConfig.USER_PLAY_RECORD_KEY, out var record)
                ? JsonConvert.DeserializeObject<UserPlayEntity>(record.Value)
                : UserPlayEntity.Default();
        }
    }
}