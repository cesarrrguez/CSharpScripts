using System.Xml;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Xml.Linq;

public class CalculatorService
{
    public async Task<int> Add(int value1, int value2)
    {
        const string url = "http://www.dneonline.com/calculator.asmx";
        const string action = "http://tempuri.org/Add";

        var soapEnvelope = CreateSoapEnvelope(value1, value2);
        var content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("SOAPAction", action);

        using var response = await client.PostAsync(url, content);

        var soapResponse = await response.Content.ReadAsStringAsync();
        return ParseSoapResponse(soapResponse);
    }

    private string CreateSoapEnvelope(int value1, int value2)
    {
        return $@"<?xml version=""1.0"" encoding=""utf-8""?>
        <soap:Envelope
            xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
            xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
            xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
        <soap:Body>
            <Add xmlns=""http://tempuri.org/"">
                <intA>{value1}</intA>
                <intB>{value2}</intB>
            </Add>
        </soap:Body>
        </soap:Envelope>";
    }

    private int ParseSoapResponse(string response)
    {
        XDocument soap = XDocument.Parse(response);
        XNamespace ns = "http://tempuri.org/";

        var result = soap.Descendants(ns + "AddResponse").First().Element(ns + "AddResult").Value;
        return int.Parse(result);
    }
}
