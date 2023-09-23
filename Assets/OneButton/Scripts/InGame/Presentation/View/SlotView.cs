using System;
using System.Collections.Generic;
using System.Linq;
using OneButton.Common;
using UniEx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class SlotView : MonoBehaviour
    {
        [SerializeField] private List<ReelView> reelViews = default;

        public void Init()
        {
            reelViews.Each(x => x.Init());
        }

        public void SetUp(List<Data.DataStore.PatternTable> patterns)
        {
            for (int i = 0; i < reelViews.Count; i++)
            {
                GetReelView(i).UpdatePatterns(patterns[i].data);
            }
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

        public bool IsMatchAll()
        {
            var movePatternCount = reelViews
                .Select(reelView => reelView.currentPattern.move)
                .ToList()
                .Distinct()
                .Count();

            return movePatternCount == 1;
        }
    }
}