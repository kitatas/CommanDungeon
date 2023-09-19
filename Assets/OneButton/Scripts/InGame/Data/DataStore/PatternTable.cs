using OneButton.Base.Data.DataStore;
using UnityEngine;

namespace OneButton.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(PatternTable), menuName = "DataTable/" + nameof(PatternTable))]
    public sealed class PatternTable : BaseTable<PatternData>
    {
    }
}