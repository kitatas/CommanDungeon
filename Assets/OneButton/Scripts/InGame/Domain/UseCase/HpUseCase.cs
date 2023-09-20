using OneButton.Base.Domain.UseCase;
using UniEx;
using UnityEngine;

namespace OneButton.InGame.Domain.UseCase
{
    public sealed class HpUseCase : BaseModelUseCase<int>
    {
        public void Increase(int value)
        {
            Set(Clamp(value));
        }

        public void Decrease(int value)
        {
            Set(Clamp(-value));
        }

        private int Clamp(int addValue)
        {
            return Mathf.Clamp(property.Value + addValue, PlayerConfig.MIN_HP, PlayerConfig.MAX_HP);
        }

        public bool IsDead()
        {
            return property.Value.IsZero();
        }
    }
}