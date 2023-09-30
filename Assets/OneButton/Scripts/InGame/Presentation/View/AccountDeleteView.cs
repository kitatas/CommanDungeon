using System;
using OneButton.Common.Presentation.View;
using UniRx;
using UnityEngine;

namespace OneButton.InGame.Presentation.View
{
    public sealed class AccountDeleteView : MonoBehaviour
    {
        [SerializeField] private GameObject titleLabel = default;
        [SerializeField] private GameObject confirmButton = default;
        [SerializeField] private DecisionButtonView decision = default;

        public void Activate(bool value)
        {
            titleLabel.SetActive(value);
            confirmButton.SetActive(value);
        }

        public IObservable<Unit> Delete()
        {
            return decision.Decision();
        }
    }
}