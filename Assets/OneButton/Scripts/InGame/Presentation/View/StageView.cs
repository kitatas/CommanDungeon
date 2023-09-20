using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniEx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class StageView : MonoBehaviour
    {
        [SerializeField] private List<FloorView> floorViews = default;

        private int _currentIndex = 0;

        public async UniTask SwitchAsync(float duration, CancellationToken token)
        {
            await (
                floorViews[_currentIndex].HideAsync(duration, token),
                floorViews[floorViews.GetLastIndex() - _currentIndex].ShowAsync(duration, token)
            );

            _currentIndex.RepeatDecrement(0, floorViews.GetLastIndex());
        }
    }
}