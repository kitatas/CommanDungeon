using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniEx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class StepView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = default;

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

        public async UniTask HideAsync(float duration, CancellationToken token)
        {
            await (
                transform
                    .DOMoveY(transform.position.y + StageConfig.HIDE_STEP_HEIGHT, duration)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject)
                    .WithCancellation(token),
                spriteRenderer
                    .DOFade(0.0f, duration)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject)
                    .WithCancellation(token)
            );
        }
    }
}