namespace OneButton.Common.Data.Entity
{
    public sealed class UserEntity
    {
        public string id;
        public UserNameEntity nameEntity;
        public UserPlayEntity playEntity;

        public void Set(UserEntity entity)
        {
            id = entity.id;
            nameEntity = entity.nameEntity;
            playEntity = entity.playEntity;
        }

        public void SetName(UserNameEntity name)
        {
            nameEntity = name;
        }

        public void SetPlay(UserPlayEntity play)
        {
            playEntity = play;
        }

        public bool IsEmptyUserName()
        {
            return nameEntity == null || string.IsNullOrEmpty(nameEntity.name);
        }
    }
}