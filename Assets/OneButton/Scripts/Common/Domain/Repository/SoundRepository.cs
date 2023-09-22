using System;
using OneButton.Common.Data.DataStore;

namespace OneButton.Common.Domain.Repository
{
    public sealed class SoundRepository
    {
        private readonly BgmTable _bgmTable;

        public SoundRepository(BgmTable bgmTable)
        {
            _bgmTable = bgmTable;
        }

        public BgmData FindBgm(BgmType type)
        {
            var data = _bgmTable.data.Find(x => x.type == type);
            if (data == null || data.clip == null)
            {
                throw new Exception(ExceptionConfig.NOT_FOUND_BGM);
            }

            return data;
        }
    }
}