using System.Management;

public class Usb
{
    public List<UsbInfo> GetUsbDevices()
    {
        var result = new List<UsbInfo>();

        using var searcher = new ManagementObjectSearcher("select * from Win32_USBHub");
        using var collection = searcher.Get();

        foreach (var device in collection)
        {
            result.Add(new UsbInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")));
        }

        return result;
    }
}

public class UsbInfo
{
    public string DeviceId { get; set; }
    public string PnPDeviceId { get; set; }
    public string Description { get; set; }

    public UsbInfo(string deviceId, string pnPDeviceId, string description)
    {
        DeviceId = deviceId ?? throw new ArgumentNullException(nameof(deviceId));
        PnPDeviceId = pnPDeviceId ?? throw new ArgumentNullException(nameof(pnPDeviceId));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public override string ToString()
    {
        return $"UsbInfo. DeviceId: {DeviceId}, PnPDeviceId: {PnPDeviceId}, Description: {Description}\n";
    }
}
