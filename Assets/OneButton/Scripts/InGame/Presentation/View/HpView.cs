using System.Collections.Generic;
using OneButton.Base.Presentation.View;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.InGame.Presentation.View
{
    public sealed class HpView : BaseView<int>
    {
        [SerializeField] private List<Image> hpImages = default;
        [SerializeField] private Sprite full = default;
        [SerializeField] private Sprite empty = default;

        public override void Render(int value)
        {
            for (int i = 0; i < hpImages.Count; i++)
            {
                hpImages[i].sprite = i + 1 <= value
                    ? full
                    : empty;
            }
        }
    }
}