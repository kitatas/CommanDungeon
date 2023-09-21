using OneButton.Base.Data.DataStore;
using UnityEngine;

namespace OneButton.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(SlotData), menuName = "DataTable/" + nameof(SlotData))]
    public sealed class SlotData : BaseTable<PatternTable>
    {
        [SerializeField] private Difficulty difficultyType = default;

        public Difficulty difficulty => difficultyType;
    }
}