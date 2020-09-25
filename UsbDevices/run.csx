#load "entities.csx"

#r "nuget: System.Management, 4.7.0"

using System.Management;

var usb = new Usb();
var usbDevices = usb.GetUsbDevices();

foreach (var usbInfo in usbDevices)
{
    WriteLine(usbInfo);
}
