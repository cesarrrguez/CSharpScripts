var number = 0d;

var optionA = number == 0;
var optionB = number.Equals(0);
var optionC = Math.Abs(number) < double.Epsilon;

WriteLine(optionA);
WriteLine(optionB);
WriteLine(optionC);
