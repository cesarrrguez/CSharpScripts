#load "utils.csx"

var randomNumber = RandomUtil.GetRandomNumber(5, 100);
WriteLine($"Random number between 5 and 100 is { randomNumber }");

var randomString = RandomUtil.GetRandomString(10, false);
WriteLine($"Random string of 10 chars is { randomString }");

var randomPassword = RandomUtil.GetRandomPassword();
WriteLine($"Random password is { randomPassword }");
