using UnityEngine;

namespace OneButton.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(PatternData), menuName = "DataTable/" + nameof(PatternData))]
    public sealed class PatternData : ScriptableObject
    {
        [SerializeField] private PatternType patternType = default;
        [SerializeField] private MoveType moveType = default;
        [SerializeField] private Sprite spriteImage = default;

        public PatternType pattern => patternType;
        public MoveType move => moveType;
        public Sprite image => spriteImage;
    }
}