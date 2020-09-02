// Calculator web service
// --------------------------------------------------------
// Service: http://www.dneonline.com/calculator.asmx
// WSDL:    http://www.dneonline.com/calculator.asmx?WSDL
// Action:  http://www.dneonline.com/calculator.asmx?op=Add
// --------------------------------------------------------

#load "utils.csx"

var value1 = 32;
var value2 = 47;

var separator = new string(Enumerable.Repeat('-', 67).ToArray());

var response = SoapClient.CallWebService(value1, value2);

// Print SOAP envelope
var soapEnvelope = response.Item1;
Console.WriteLine("SOAP envelope:");
Console.WriteLine(separator);
soapEnvelope.Save(Console.Out);

// Print XML response
var xmlResponse = response.Item2;
Console.WriteLine("\n\nXML response:");
Console.WriteLine(separator);
xmlResponse.Save(Console.Out);

// Print result
var result = xmlResponse.GetElementsByTagName("AddResult")?[0]?.InnerText;
Console.WriteLine($"\n\nResult: {result}");
