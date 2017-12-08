using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Getting_WIFI_Networks
{
    public partial class Form1 : Form
    {
        private readonly NetworkSearcher _searcher = new NetworkSearcher();
        private List<WiFiNetwork> networks;
        private bool inProcess = false; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateNetworkList();
            ConnectionB.Enabled = false;
            PasswordF.Enabled = false;
            timer1.Enabled = true;
        }

        private void UpdateNetworkList()
        {
            networks = _searcher.GetNetworks();
            NetworkList.Items.Clear();
            foreach (WiFiNetwork network in networks)
            {
                ListViewItem item = new ListViewItem(network.Name);
                item.SubItems.Add(network.SignalStrength);
                NetworkList.Items.Add(item);
            }

        }

        private void NetworkList_MouseClick(object sender, MouseEventArgs e)
        {
            ShowInfo(networks[NetworkList.SelectedItems[0].Index]);
        }

        private void ShowInfo(WiFiNetwork network)
        {
            NetworkInformation.Text = network.Description + network.GetMAC();
            if (network.IsConnected)
            {
                ConnectionStatusL.Text = "Connected";
                PasswordF.Enabled = false;
                PasswordF.Clear();
                ConnectionB.Enabled = false;
            }
            else
            {
                ConnectionStatusL.Text = "Available";
                PasswordF.Enabled = network.IsSecured;
                ConnectionB.Enabled = true;
            }
        }

        private void ConnectionB_Click(object sender, EventArgs e)
        {
            if (PasswordF.Text.Length > 0)
            {
                if (networks[NetworkList.SelectedItems[0].Index].Connect(PasswordF.Text))
                {
                    ConnectionStatusL.Text = "Connected";
                    PasswordF.Enabled = false;
                    ConnectionB.Enabled = false;
                    NetworkList.SelectedItems[0].Selected = false;
                }
                else
                {
                    ConnectionStatusL.Text = "Error";
                }
            }
            inProcess = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!inProcess)
            {
                UpdateNetworkList();
            }
        }

        private void PasswordFieldClick(object sender, EventArgs e)
        {
            inProcess = true;
        }
    }
}
