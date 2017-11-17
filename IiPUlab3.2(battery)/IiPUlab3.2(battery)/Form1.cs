using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace IiPUlab3._2_battery_
{
    public partial class Battery : Form
    {
        Thread myThread;
        int defaultBlackoutTime;

        public Battery()
        {
            InitializeComponent();
            defaultBlackoutTime = GetScreenTime();
            myThread = new Thread(getBatteryStatus);
            myThread.Start();
        }

        public void getBatteryStatus()
        {
            PowerStatus pw = SystemInformation.PowerStatus;
            var prePowerLineStatus = pw.PowerLineStatus.ToString();
            while (true)
            {
                pw = SystemInformation.PowerStatus;
                PowerLineStatus.Invoke(new Action(() =>
                    {
                        PowerLineStatus.Text = pw.PowerLineStatus.ToString();
                        if ((pw.PowerLineStatus.ToString() == "Online") && (prePowerLineStatus == "Offline"))
                        {
                            prePowerLineStatus = "Online";
                            SetDisplayBlackout(defaultBlackoutTime);
                        }
                    }
                    ));
                BatteryLifePercent.Invoke(new Action(() => BatteryLifePercent.Text = (pw.BatteryLifePercent*100).ToString() + '%'));
                BatteryLifeRemaining.Invoke(new Action(() =>
                {
                    if (pw.BatteryLifeRemaining != -1) BatteryLifeRemaining.Text = (pw.BatteryLifeRemaining / 60).ToString() + " min.";
                    else BatteryLifeRemaining.Text = "∞";
                }
                ));
            }
        }

        public int GetScreenTime()
        {
            // Запуск консоли.
            var processCmd = new Process();
            processCmd.StartInfo.UseShellExecute = false;                         //Не нужно использовать оболочку системы для запуска процесса
            processCmd.StartInfo.RedirectStandardOutput = true;                   //Нужно записывать данные приложения в поток
            processCmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;         //Стиль окна
            processCmd.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);    //Русский
            processCmd.StartInfo.FileName = "powercfg";
            processCmd.StartInfo.Arguments = "/q";
            processCmd.Start();
            var powerConfig = processCmd.StandardOutput.ReadToEnd();             //Считываем все символы с текущей позиции до конца.
            var i1 = powerConfig.IndexOf("17aaa29b-8b43-4b94-aafe-35f64daaf1ee");//Находим GUID Гасить после
            var i2 = powerConfig.IndexOf("Текущий индекс настройки питания от батарей: ", i1);
            var i3 = powerConfig.IndexOf("0x", i2);
            var currentBlackoutTime = powerConfig.Substring(i3, 10);
            return Convert.ToInt32(currentBlackoutTime, 16) / 60;
        }

        public void SetDisplayBlackout(int value)
        {
            var p = new Process();
            p.StartInfo.FileName = "powercfg";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.Arguments = "/SETDCVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 17aaa29b-8b43-4b94-aafe-35f64daaf1ee " + value*60;
            p.Start();
        }

        private void BlackoutTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDisplayBlackout(Int32.Parse(BlackoutTimeComboBox.SelectedItem.ToString()));
        }

        private void Battery_FormClosing(object sender, FormClosingEventArgs e)
        {
            myThread.Abort();
            SetDisplayBlackout(defaultBlackoutTime);
        }
    }
}
