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

        public void SetFocus(int index)
        {
            for (int i = 0; i < reelViews.Count; i++)
            {
                GetReelView(i).SetFocus(i == index);
            }
        }

        public void Refresh()
        {
            reelViews.Each(x => x.SetRoll(true));
        }

        public void StopReel(int index)
        {
            GetReelView(index).SetRoll(false);
        }

        public Data.DataStore.PatternData GetReelPattern(int index)
        {
            return GetReelView(index).currentPattern;
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