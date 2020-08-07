#r "nuget: iTextSharp, 5.5.13.1"

using iTextSharp.text;
using iTextSharp.text.pdf;

var path = @"QR/QR.pdf";

var document = new Document(PageSize.A4);
var stream = new FileStream(path, FileMode.Create);

PdfWriter.GetInstance(document, stream);
document.Open();

var barcodeQRCode = new BarcodeQRCode("https://cesarrrguez.github.io/", 1000, 1000, null);
var codeQRImage = barcodeQRCode.GetImage();
codeQRImage.ScaleAbsolute(200, 200);
document.Add(codeQRImage);

document.Close();
stream.Close();

Console.WriteLine("QR code generated successfully");
