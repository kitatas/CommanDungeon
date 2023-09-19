using System.Collections;
using System.Collections.Generic;
using UniEx;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.InGame.Presentation.View
{
    public sealed class ReelView : MonoBehaviour
    {
        [SerializeField] private Image pattern = default;

        private List<Data.DataStore.PatternData> _patterns;
        private int _index;
        private bool _isRoll;

        public Data.DataStore.PatternData currentPattern { get; private set; }

        public void Init(List<Data.DataStore.PatternData> patterns)
        {
            _patterns = patterns;
            _index = 0;
            SetRoll(false);

            StartCoroutine(TickCor());
        }

        public void SetRoll(bool value)
        {
            _isRoll = value;
        }

        private IEnumerator TickCor()
        {
            var interval = new WaitForSeconds(SlotConfig.PATTERN_INTERVAL);

            while (true)
            {
                if (_isRoll)
                {
                    currentPattern = _patterns[_index];
                    pattern.sprite = currentPattern.image;
                    _index.RepeatIncrement(0, _patterns.GetLastIndex());
                    yield return interval;
                }
                else
                {
                    yield return null;
                }
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}