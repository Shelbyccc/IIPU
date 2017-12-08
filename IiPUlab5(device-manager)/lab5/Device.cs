using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace lab5
{
    class Device
    {
        public string Name { get; set; }

        public string ClassGuid { get; set; }

        public string HardwareId { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public string Provider { get; set; }

        public string SysPath { get; set; }

        public string DevicePath { get; set; }

        public bool Status { get; set; }

        public void ChangeConnection(string method)
        {
            var device = new ManagementObjectSearcher("SELECT * FROM Win32_PNPEntity").Get().OfType<ManagementObject>()
                .FirstOrDefault(x => x["DeviceID"].ToString().Equals(DevicePath));
            device.InvokeMethod(method, new object[] { false });
        }
    }
}
