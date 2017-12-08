using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeWifi;
using SimpleWifi;

namespace Getting_WIFI_Networks
{
    class NetworkSearcher
    {
        private readonly Wifi _wifi;
        private WlanClient _wlanClient;

        public NetworkSearcher()
        {
            _wifi = new Wifi();
            _wlanClient = new WlanClient();
        }

        public List<WiFiNetwork> GetNetworks()
        {
            List<WiFiNetwork> networks = new List<WiFiNetwork>();
            List<AccessPoint> accessPoints = _wifi.GetAccessPoints();
            foreach (AccessPoint accessPoint in accessPoints)
            {
                networks.Add(new WiFiNetwork(accessPoint.Name,
                             accessPoint.SignalStrength.ToString() + "%",
                             accessPoint.ToString(),
                             GetMAC(accessPoint),
                             accessPoint.IsSecure,
                             accessPoint.IsConnected)
                             );
            }
            return networks;
        }

        private List<string> GetMAC(AccessPoint accessPoint)
        {
            var wlanInterface = _wlanClient.Interfaces.FirstOrDefault();
            return wlanInterface.GetNetworkBssList()
                .Where(x => Encoding.ASCII.GetString(x.dot11Ssid.SSID, 0, (int)x.dot11Ssid.SSIDLength).Equals(accessPoint.Name))
                .Select(y => MACToString(y)).ToList();
        }

        private string MACToString(Wlan.WlanBssEntry entry)
        {
            StringBuilder MACBuilder = new StringBuilder();
            foreach (byte mByte in entry.dot11Bssid)
            {
                MACBuilder.Append(mByte.ToString("X"));
                MACBuilder.Append("-");
            }
            MACBuilder.Remove(MACBuilder.Length - 1, 1);
            return MACBuilder.ToString();
        }
    }
}
