#load "utils.csx"

var text = "123456";
var hashedText = "";
WriteLine($"Text: {text}");

// SHA1
hashedText = EncryptionUtil.GetSHA1(text);
WriteLine($"SHA1: {hashedText}");

// SHA256
hashedText = EncryptionUtil.GetSHA256(text);
WriteLine($"SHA256: {hashedText}");
