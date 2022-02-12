// Calculator web service
// --------------------------------------------------------
// Service: http://www.dneonline.com/calculator.asmx
// WSDL:    http://www.dneonline.com/calculator.asmx?WSDL
// Action:  http://www.dneonline.com/calculator.asmx?op=Add
// --------------------------------------------------------

#load "services.csx"

var value1 = 32;
var value2 = 47;

var calculatorService = new CalculatorService();

var result = calculatorService.Add(value1, value2);
WriteLine($"{value1} + {value2} = {result.Result}");
