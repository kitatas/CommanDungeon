using OneButton.Base.Data.DataStore;
using UnityEngine;

namespace OneButton.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(SeTable), menuName = "DataTable/" + nameof(SeTable))]
    public sealed class SeTable : BaseTable<SeData>
    {
    }
}