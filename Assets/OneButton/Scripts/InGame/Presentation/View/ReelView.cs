using System.Collections;
using System.Collections.Generic;
using UniEx;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton.InGame.Presentation.View
{
    public sealed class ReelView : MonoBehaviour
    {
        [SerializeField] private Image frame = default;
        [SerializeField] private Image pattern = default;

        private List<Data.DataStore.PatternData> _patterns;
        private int _index;
        private bool _isRoll;

        public Data.DataStore.PatternData currentPattern { get; private set; }
        public Vector3 localPosition => transform.localPosition;

        public void Init()
        {
            _index = 0;
            SetRoll(false);

            StartCoroutine(TickCor());
        }

        public void UpdatePatterns(List<Data.DataStore.PatternData> patterns)
        {
            _patterns = patterns;
        }

        public void SetFocus(bool value)
        {
            var a = value ? 1.0f : 0.5f;
            frame.SetColorA(a);
            pattern.SetColorA(a);

            transform.localScale = value ? Vector3.one : Vector3.one * 0.75f;
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