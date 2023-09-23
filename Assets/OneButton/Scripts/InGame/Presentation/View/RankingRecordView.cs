using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.InGame.Presentation.View
{
    public sealed class RankingRecordView : MonoBehaviour
    {
        [SerializeField] private Image background = default;
        [SerializeField] private TextMeshProUGUI rank = default;
        [SerializeField] private TextMeshProUGUI userName = default;
        [SerializeField] private TextMeshProUGUI score = default;

        public void SetData(Common.Data.Entity.RankingRecordEntity entity)
        {
            if (entity.isSelf)
            {
                background.color = new Color(1.0f, 0.5f, 0.5f, 0.75f);
            }

            rank.text = $"{entity.rank.ToString()}";
            userName.text = $"{entity.name}";
            score.text = $"{entity.GetScore().ToString()}";
        }
    }
}