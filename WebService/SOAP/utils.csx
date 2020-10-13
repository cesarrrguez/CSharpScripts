using System.Xml;
using System.Net;
using System.IO;

public static class SoapClient
{
    private const string _url = "http://www.dneonline.com/calculator.asmx";
    private const string _action = "http://tempuri.org/Add";

    public static Tuple<XmlDocument, XmlDocument> CallWebService(int value1, int value2)
    {
        var soapEnvelopeXml = CreateSoapEnvelope(value1, value2);
        var webRequest = CreateWebRequest(_url, _action);
        InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

        // Begin async call to web request
        var asyncResult = webRequest.BeginGetResponse(null, null);

        // Suspend this thread until call is complete
        // You might want to do something usefull here like update your UI
        asyncResult.AsyncWaitHandle.WaitOne();

        // Get the response from the completed web request
        var xmlResponse = new XmlDocument();

        using var webResponse = webRequest.EndGetResponse(asyncResult);
        using var stream = new StreamReader(webResponse.GetResponseStream());
        xmlResponse.Load(stream);

        return new Tuple<XmlDocument, XmlDocument>(soapEnvelopeXml, xmlResponse);
    }

    private static HttpWebRequest CreateWebRequest(string url, string action)
    {
        var webRequest = (HttpWebRequest)WebRequest.Create(url);

        webRequest.Headers.Add("SOAPAction", action);
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";

        return webRequest;
    }

    private static XmlDocument CreateSoapEnvelope(int value1, int value2)
    {
        var soapEnvelopeDocument = new XmlDocument();

        soapEnvelopeDocument.LoadXml(
        $@"<soap:Envelope 
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
    xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
    xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <Add xmlns=""http://tempuri.org/"">
      <intA>{value1}</intA>
      <intB>{value2}</intB>
    </Add>
  </soap:Body>
</soap:Envelope>"
        );

        return soapEnvelopeDocument;
    }

    private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
    {
        using var stream = webRequest.GetRequestStream();
        soapEnvelopeXml.Save(stream);
    }
}
