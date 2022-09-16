#load "utils.csx"

#r "nuget: QRCoder, 1.4.3"

using QRCoder;

await App.RunAsync();

public static class App
{
    public static async Task RunAsync()
    {
        var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "QR.jpg");

        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode("https://cesarrrguez.github.io/", QRCodeGenerator.ECCLevel.Q);
        var qrCodeAsBitmap = new BitmapByteQRCode(qrCodeData);
        var bitmap = qrCodeAsBitmap.GetGraphic(20);

        await using var ms = new MemoryStream();
        await ms.WriteAsync(bitmap);

        using FileStream file = new FileStream(path, FileMode.CreateNew);
        ms.WriteTo(file);

        file.Close();
        ms.Close();
    }
}
