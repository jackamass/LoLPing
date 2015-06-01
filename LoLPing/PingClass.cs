using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoLPing
{
    public class PingClass
    {
        Ping a = new Ping();
        bool On = true;

        public PingClass()
        {
            
        }

        public int Start()
        {
            try
            {
                //Thread.Sleep(1000);
                byte[] buffer = new byte[] { };
                PingOptions pO = new PingOptions();
                pO.Ttl = 34800;
                PingReply data = a.Send("nic.cl", 1000, buffer, pO);
                return Convert.ToInt32(data.RoundtripTime);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return 0;
            }
        }
    }
}
