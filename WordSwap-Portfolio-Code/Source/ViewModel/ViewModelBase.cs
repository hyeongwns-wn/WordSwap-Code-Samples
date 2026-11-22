using WordSwap.Core;
using System;
using System.Collections.Generic;

namespace WordSwap.ViewModel
{
    public abstract class ViewModelBase : IDisposable
    {
        private List<Action> _disposables = new List<Action>();
    
        protected Observable<T> CreateObservable<T>(T initialValue = default)
        {
            var observable = new Observable<T>(initialValue);
            _disposables.Add(() => observable.ClearListeners());
            return observable;
        
        }

        public virtual void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable();
            }
            _disposables.Clear();
        }
    }
}
