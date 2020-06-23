#load "utils.csx"

var randomNumber = RandomUtil.GetRandomNumber(5, 100);
Console.WriteLine($"Random number between 5 and 100 is { randomNumber }");

var randomString = RandomUtil.GetRandomString(10, false);
Console.WriteLine($"Random string of 10 chars is { randomString }");

var randomPassword = RandomUtil.GetRandomPassword();
Console.WriteLine($"Random password is { randomPassword }");
