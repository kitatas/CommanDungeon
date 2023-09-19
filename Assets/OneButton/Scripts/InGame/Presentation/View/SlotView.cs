using System;
using System.Collections.Generic;
using OneButton.Common.Application;
using UniEx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class SlotView : MonoBehaviour
    {
        [SerializeField] private List<ReelView> reelViews = default;

        public void Init(int index, List<Data.DataStore.PatternData> patterns)
        {
            GetReelView(index).Init(patterns);
        }

        public void Refresh()
        {
            reelViews.Each(x => x.SetRoll(true));
        }

        public void StopReel(int index)
        {
            GetReelView(index).SetRoll(false);
        }

        private ReelView GetReelView(int index)
        {
            if (reelViews.TryGetValue(index, out var reelView))
            {
                return reelView;
            }
            else
            {
                throw new Exception(ExceptionConfig.NOT_FOUND_REEL);
            }
        }
    }
}