using System.Collections.Generic;
using OneButton.Base.Presentation.View;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.InGame.Presentation.View
{
    public sealed class HpView : BaseView<int>
    {
        [SerializeField] private List<Image> hpImages;

        public override void Render(int value)
        {
            for (int i = 0; i < hpImages.Count; i++)
            {
                // TODO: 画像の切り替え
                hpImages[i].color = i + 1 <= value
                    ? Color.white
                    : Color.gray;
            }
        }
    }
}