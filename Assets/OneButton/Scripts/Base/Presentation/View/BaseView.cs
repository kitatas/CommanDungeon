using UnityEngine;

namespace OneButton.Base.Presentation.View
{
    public abstract class BaseView<T> : MonoBehaviour
    {
        public abstract void Render(T value);
    }
}