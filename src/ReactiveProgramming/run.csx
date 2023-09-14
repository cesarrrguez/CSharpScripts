#load "../../packages.csx"

using System.Reactive.Linq;

public static event EventHandler<int> MyEvent;

var observable = Observable.FromEventPattern<int>(
    e => MyEvent += e,
    e => MyEvent -= e
);

var observer1 = observable.Subscribe(some => WriteLine($"The event send me a {some.EventArgs}!"));
var observer2 = observable.Subscribe(some => WriteLine($"I can see a {some.EventArgs}!"));

MyEvent(null, 9);
MyEvent(null, 12);
