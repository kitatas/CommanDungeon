using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniEx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = default;

        public async UniTask MoveAsync(Vector3 direction, CancellationToken token)
        {
            var nextPosition = transform.position + direction;
            if (nextPosition.x.IsBetween(StageConfig.MIN_X, StageConfig.MAX_X) &&
                nextPosition.y.IsBetween(StageConfig.MIN_Y, StageConfig.MAX_Y))
            {
                await transform
                    .DOMove(nextPosition, PlayerConfig.MOVE_SPEED)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject)
                    .WithCancellation(token);
            }
            else
            {
                // TODO: 何か演出
            }

            await UniTask.Delay(TimeSpan.FromSeconds(PlayerConfig.MOVE_INTERVAL), cancellationToken: token);
        }
    }
}