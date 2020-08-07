#load "utils.csx"

var text = "123456";
var hashedText = "";
Console.WriteLine($"Text: {text}");

// SHA1
hashedText = EncryptionUtil.GetSHA1(text);
Console.WriteLine($"SHA1: {hashedText}");

// SHA256
hashedText = EncryptionUtil.GetSHA256(text);
Console.WriteLine($"SHA256: {hashedText}");
