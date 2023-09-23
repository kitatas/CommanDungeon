using System;
using OneButton.Common.Presentation.View;
using TMPro;
using UniRx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class UserNameView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField = default;
        [SerializeField] private DecisionButtonView decision = default;

        public void Init(string userName)
        {
            inputField.text = $"{userName}";
        }

        private string inputName => inputField.text;

        public IObservable<string> UpdateName()
        {
            return decision.Decision().Select(_ => inputName);
        }
    }
}