#load "../../../packages.csx"

using MethodTimer;

DoSomething();

[Time]
public async void DoSomething() => await Task.Delay(Random.Shared.Next(5, 30));
