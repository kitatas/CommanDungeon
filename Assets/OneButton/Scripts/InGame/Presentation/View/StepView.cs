using UniEx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class StepView : MonoBehaviour
    {
        // 同じマスだった際の位置
        // step:   x: -1.5,    y: 1.5
        // player: x: -1.5625, y: 1.75
        public bool IsGoal(Vector3 playerPosition)
        {
            var position = transform.position;
            return
                playerPosition.x.IsBetween(position.x - 0.1f, position.x + 0.0f) &&
                playerPosition.y.IsBetween(position.y - 0.0f, position.y + 0.3f);
        }
    }
}