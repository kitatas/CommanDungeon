using OneButton.Base.Data.DataStore;
using UnityEngine;

namespace OneButton.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(SlotTable), menuName = "DataTable/" + nameof(SlotTable))]
    public sealed class SlotTable : BaseTable<SlotData>
    {
    }
}