#load "../../packages.csx"

#load "entities.csx"

using System.Management;

var usb = new Usb();
var usbDevices = usb.GetUsbDevices();

foreach (var usbInfo in usbDevices)
{
    WriteLine(usbInfo);
}
