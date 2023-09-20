using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace OneButton.InGame.Presentation.View
{
    public sealed class FloorView : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap = default;

        public async UniTask ShowAsync(float duration, CancellationToken token)
        {
            await (
                DOTween
                    .To(
                        () => tilemap.tileAnchor.y,
                        y => tilemap.tileAnchor = new Vector3(0.5f, y, 0.0f),
                        StageConfig.SHOW_HEIGHT,
                        duration
                    )
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject)
                    .WithCancellation(token),
                DOTween
                    .ToAlpha(
                        () => tilemap.color,
                        x => tilemap.color = x,
                        1.0f,
                        duration
                    )
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject)
                    .WithCancellation(token)
            );
        }

        public async UniTask HideAsync(float duration, CancellationToken token)
        {
            await (
                DOTween
                    .To(
                        () => tilemap.tileAnchor.y,
                        y => tilemap.tileAnchor = new Vector3(0.5f, y, 0.0f),
                        StageConfig.HIDE_HEIGHT_MAX,
                        duration
                    )
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject)
                    .WithCancellation(token),
                DOTween
                    .ToAlpha(
                        () => tilemap.color,
                        x => tilemap.color = x,
                        0.0f,
                        duration
                    )
                    .SetEase(Ease.Linear)
                    .SetLink(gameObject)
                    .WithCancellation(token)
            );

            tilemap.tileAnchor = new Vector3(0.5f, StageConfig.HIDE_HEIGHT_MIN, 0.0f);
            tilemap.color = Color.white;
        }
    }
}