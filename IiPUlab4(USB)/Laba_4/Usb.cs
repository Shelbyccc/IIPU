using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbEject;

namespace Laba_4
{
    class Usb
    {
        public string DeviceName { get; set; }
        public string FreeSpace { get; set; }
        public string UsedSpace { get; set; }
        public string TotalSpace { get; set; }
        public bool IsMtpDevice { get; set; }
      
        public bool EjectDevice()
        {
            var tempName = this.DeviceName.Remove(2);//получаем том девавйса
            var ejectedDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == tempName);//получаем значение состояния девайса
            if (!IsMtpDevice)
            {
                ejectedDevice.Eject(false);
                ejectedDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == tempName);//повторное подключение к девайсу после поытки извлечения
            }
            else
            {
                return false;
            }
            return ejectedDevice == null;
        }
    }
}
