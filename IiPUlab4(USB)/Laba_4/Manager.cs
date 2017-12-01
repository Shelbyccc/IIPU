using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MediaDevices;

namespace Laba_4
{
    class Manager
    {
        public List<Usb> DeviseListCreate()
        {
            List<Usb> usbDevices = new List<Usb>();//список , который будет выводиться
            List<DriveInfo> diskDrives = DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveType == DriveType.Removable).ToList();//из драйверинфо получаем устройства, которые подключены и являются внешними
            List<MediaDevice> mtpDrives = MediaDevice.GetDevices().ToList();//телефоны и тд
            foreach (var device in mtpDrives)//медиа девайсы
            {
                device.Connect();
                if (device.Protocol.Contains("MTP"))//поиск mtp девайсов
                {
                    usbDevices.Add(new Usb()
                    {
                        DeviceName = device.FriendlyName,
                        FreeSpace = null,
                        UsedSpace = null,
                        TotalSpace = null,
                        IsMtpDevice = true
                    });
                }
            }
            foreach (DriveInfo drive in diskDrives)//для флешек
            {
                usbDevices.Add(new Usb()
                {
                    DeviceName = drive.Name,
                    FreeSpace = Convert(drive.TotalFreeSpace),
                    UsedSpace = Convert(drive.TotalSize - drive.TotalFreeSpace),
                    TotalSpace = Convert(drive.TotalSize),
                    IsMtpDevice = false
                });
            }
            return usbDevices;
        }

        private string Convert(long value)
        {
            double megaBytes = (value / 1024) / 1024;//перевод из байтов в в мегабайты
            return megaBytes.ToString() + " mb";
        }
    }
}
