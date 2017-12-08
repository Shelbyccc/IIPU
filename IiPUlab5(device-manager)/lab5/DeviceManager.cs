using System.Collections.Generic;
using System.Linq;
using System.Management;


namespace lab5
{
    class DeviceManager
    {
        public static ManagementObjectSearcher Searcher = new ManagementObjectSearcher(new ManagementScope("\\\\.\\root\\cimv2"),
            new SelectQuery("SELECT * FROM Win32_PnPEntity"));

        public static List<Device> GetDevices()
        {
            return (from ManagementBaseObject o in Searcher.Get()
                select o as ManagementObject
                into device
                let driverInfo = GetDriverInfo(device)
                where device != null
                select new Device
                {
                    Name = (device["Name"]!=null) ? device["Name"].ToString() : "",
                    ClassGuid = (device["ClassGuid"]!=null) ? device["ClassGuid"].ToString() : "",
                    HardwareId = (device["HardwareID"] == null) ? "" : string.Join("\n", (string[])device["HardwareID"]),
                    Manufacturer = (device["Manufacturer"] != null) ? device["Manufacturer"].ToString() : "",
                    Description = driverInfo[0],
                    Provider = (device["Caption"] != null) ? device["Caption"].ToString() : "",
                    SysPath = driverInfo[1],
                    DevicePath = (device["DeviceID"] != null) ? device["DeviceID"].ToString() : "",
                    Status = (device["Status"].ToString().Equals("OK")) ? true : false
                }).ToList();
        }

        private static string[] GetDriverInfo(ManagementObject device)
        {
            var driverInfo = new string[2];
            foreach (var driverParameter in device.GetRelated("Win32_SystemDriver"))
            {
                driverInfo[0] += driverParameter["Description"] == null ? "" : driverParameter["Description"] + "\n";
                driverInfo[1] += driverParameter["PathName"] == null ? "" : driverParameter["PathName"] + "\n";
            }
            return driverInfo;
        }

    }
}
