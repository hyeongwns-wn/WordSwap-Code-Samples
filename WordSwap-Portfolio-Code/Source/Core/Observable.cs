using System;
using System.Collections.Generic;

namespace WordSwap.Core
{
    public class Observable<T>
    {
        private T _value;
        public event Action<T> OnChanged;

        public T Value
        {
            get => _value;
            set
            {
                if (!EqualityComparer<T>.Default.Equals(_value, value))
                {
                    _value = value;
                    OnChanged?.Invoke(value);
                }
            }
        }
        // 생성자 — 초기값 설정
        public Observable(T initialValue = default)
        {
            _value = initialValue;
        }

        // 구독 해제 — OnChanged에 등록된 것 전부 제거
        public void ClearListeners()
        {
            OnChanged = null;
        }
        public void ForceNotify()
        {
            OnChanged?.Invoke(_value);
        }
    }
}
