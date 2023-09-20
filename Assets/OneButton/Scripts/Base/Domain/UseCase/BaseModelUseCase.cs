using UniRx;

namespace OneButton.Base.Domain.UseCase
{
    public abstract class BaseModelUseCase<T>
    {
        private readonly ReactiveProperty<T> _property;

        public BaseModelUseCase()
        {
            _property = new ReactiveProperty<T>();
        }

        public IReadOnlyReactiveProperty<T> property => _property;

        public virtual void Set(T value)
        {
            _property.Value = value;
        }

        public T currentValue => _property.Value;
    }
}