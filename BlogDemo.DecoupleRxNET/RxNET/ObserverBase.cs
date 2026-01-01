using System.Reactive.Subjects;

namespace BlogDemo.DecoupleRxNET.RxNET
{
    public class ObserverBase<T> : IObserver<T>
    {
        private IObserver<T> _observerSubject;

        protected IObservable<T> ObservableSubject { get; }

        protected ObserverBase()
        {
            var subject = new Subject<T>();
            ObservableSubject = subject;
            _observerSubject = subject;
        }

        public void OnCompleted() => _observerSubject.OnCompleted();

        public void OnError(Exception error) => _observerSubject.OnError(error);

        public void OnNext(T value) => _observerSubject.OnNext(value);
    }
}
