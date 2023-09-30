using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.Common.Presentation.View
{
    public sealed class CameraView : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera = default;
        [SerializeField] private CanvasScaler canvasScaler = default;

        private void Start()
        {
            Resolution resolution = default;
            this.UpdateAsObservable()
                .Select(_ => Screen.currentResolution)
                .Where(x => x.width != resolution.width || x.height != resolution.height)
                .Subscribe(x =>
                {
                    resolution = x;
                    SetSize();
                })
                .AddTo(this);
        }

        private void SetSize()
        {
            var resolution = canvasScaler.referenceResolution;
            var r = resolution.y / resolution.x;
            var s = (float)Screen.height / (float)Screen.width;
            var d = s / r;

            if (d > 1.0f)
            {
                mainCamera.orthographicSize *= d;
            }
        }
    }
}