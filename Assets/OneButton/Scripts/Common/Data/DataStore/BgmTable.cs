using OneButton.Base.Data.DataStore;
using UnityEngine;

namespace OneButton.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(BgmTable), menuName = "DataTable/" + nameof(BgmTable))]
    public sealed class BgmTable : BaseTable<BgmData>
    {
    }
}