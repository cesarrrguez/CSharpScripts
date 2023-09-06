#r "nuget: MethodTimer.Fody, 3.2.2"

using MethodTimer;

DoSomething();

[Time]
public async void DoSomething() => await Task.Delay(Random.Shared.Next(5, 30));
