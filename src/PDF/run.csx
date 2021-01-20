#load "utils.csx"

#r "nuget: itext7, 7.1.13"

using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "document.pdf");

var reader = new PdfReader(path);
var document = new PdfDocument(reader);

for (var i = 1; i <= document.GetNumberOfPages(); i++)
{
    var page = document.GetPage(i);
    var text = PdfTextExtractor.GetTextFromPage(page);
    WriteLine(text);
    WriteLine();
}

document.Close();
reader.Close();
