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
        [SerializeField] private Animator animator = default;
        private static readonly int _isMove = Animator.StringToHash("IsMove");

        public Vector3 currentPosition => transform.position;

        public async UniTask MoveAsync(Vector3 direction, CancellationToken token)
        {
            var nextPosition = currentPosition + direction;
            if (nextPosition.x.IsBetween(PlayerConfig.MIN_X, PlayerConfig.MAX_X) &&
                nextPosition.y.IsBetween(PlayerConfig.MIN_Y, PlayerConfig.MAX_Y))
            {
                FlipX(direction.x);
                animator.SetBool(_isMove, true);

                await transform
                    .DOMove(nextPosition, PlayerConfig.MOVE_SPEED)
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject)
                    .WithCancellation(token);

                animator.SetBool(_isMove, false);
            }
            else
            {
                await Vibrate()
                    .WithCancellation(token);
            }

            await UniTask.Delay(TimeSpan.FromSeconds(PlayerConfig.MOVE_INTERVAL), cancellationToken: token);
        }

        private void FlipX(float value)
        {
            spriteRenderer.flipX = value switch
            {
                > 0 => false,
                < 0 => true,
                _ => spriteRenderer.flipX
            };
        }

        private Tween Vibrate()
        {
            var currentX = currentPosition.x;
            return DOTween.Sequence()
                .Append(transform
                    .DOMoveX(currentX - 0.1f, PlayerConfig.VIBRATE_TIME))
                .Append(transform
                    .DOMoveX(currentX + 0.1f, PlayerConfig.VIBRATE_TIME))
                .Append(transform
                    .DOMoveX(currentX - 0.1f, PlayerConfig.VIBRATE_TIME))
                .Append(transform
                    .DOMoveX(currentX, PlayerConfig.VIBRATE_TIME))
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        public bool IsEqualPosition(Vector3 playerPosition)
        {
            var position = transform.position;
            return
                playerPosition.x.IsBetween(position.x - 0.05f, position.x + 0.05f) &&
                playerPosition.y.IsBetween(position.y - 0.05f, position.y + 0.05f);
        }
    }
}