using OneButton.Base.Presentation.View;
using TMPro;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class StepCountView : BaseView<int>
    {
        [SerializeField] private TextMeshProUGUI step = default;

        public override void Render(int value)
        {
            step.text = $"B{value}F";
        }
    }
}