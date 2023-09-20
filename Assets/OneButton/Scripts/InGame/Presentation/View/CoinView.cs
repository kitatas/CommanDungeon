using OneButton.Base.Presentation.View;
using TMPro;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class CoinView : BaseView<int>
    {
        [SerializeField] private TextMeshProUGUI coinCount = default;

        public override void Render(int value)
        {
            coinCount.text = $"{value}";
        }
    }
}