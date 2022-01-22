#r "nuget: Ardalis.SmartEnum, 2.0.1"

#load "enums.csx"

var free = Subscriptions.Free;
var freeToo = Subscriptions.Free;

var freeFromName = Subscriptions.FromName("Free");
var freeFromValue = Subscriptions.FromValue(1);

WriteLine(free == freeToo);
WriteLine(freeToo == freeFromName);
WriteLine(freeFromName == freeFromValue);

WriteLine($"Discount was {free.Discount}");
