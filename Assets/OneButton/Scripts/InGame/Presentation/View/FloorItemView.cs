using System.Collections.Generic;
using UniEx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OneButton.InGame.Presentation.View
{
    public sealed class FloorItemView : MonoBehaviour
    {
        [SerializeField] private ItemCoinView itemCoinView = default;
        [SerializeField] private ItemHeartView itemHeartView = default;

        private List<ItemView> _itemViews;
        private List<ItemView> _currentItemViews;

        public void Init()
        {
            _itemViews = new List<ItemView>
            {
                itemCoinView,
                itemHeartView,
            };

            _currentItemViews = new List<ItemView>();
        }

        public void LotItems(PlayerView player, StepView step)
        {
            _currentItemViews.Clear();

            for (int i = 0; i < StageConfig.HEIGHT; i++)
            {
                for (int j = 0; j < StageConfig.WIDTH; j++)
                {
                    var x = ItemConfig.INIT_POSITION_X + j;
                    var y = ItemConfig.INIT_POSITION_Y + i;
                    var position = new Vector3(x, y, 0.0f);

                    // プレイヤー / 階段の位置と重なっていた場合
                    if (player.IsEqualPosition(position) || step.IsEqualPosition(position)) continue;

                    // 出現確率
                    var probability = Random.Range(0, 100) + 1;
                    if (probability > ItemConfig.PROBABILITY) continue;

                    var item = _itemViews.GetRandom();
                    var itemView = Instantiate(item, position, Quaternion.identity);
                    itemView.Hide(0.0f);
                    _currentItemViews.Add(itemView);
                }
            }
        }

        public void ShowAll(float duration)
        {
            _currentItemViews.Each(x =>
            {
                if (x != null)
                {
                    x.Show(duration);
                }
            });
        }
    }
}