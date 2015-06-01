using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace LoLPing
{
    public partial class Form1 : Form
    {
        private PingClass pc = new PingClass();
        private delegate void CargarPingDelegado(string text);
        System.Timers.Timer myTimer = new System.Timers.Timer();    

        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false; 
            myTimer.Elapsed += myTimer_Elapsed;
            myTimer.Interval = 1000;
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {     
            myTimer.Enabled = true;
        }

        private void myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CargarPingDelegado CPD = new CargarPingDelegado(myTimer_Elapsed1);
            CPD.Invoke("");
        }


        private void myTimer_Elapsed1(string text)
        {
            if (this.lblPing.InvokeRequired)
            {
                CargarPingDelegado d = new CargarPingDelegado(myTimer_Elapsed1);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                int a = pc.Start();
                
                if(a >= 120)
                {
                    lblPing.ForeColor = System.Drawing.Color.Red;
                    lblEstado.Text = "No jugable";
                }
                else if(a < 120 && a > 70)
                {
                    lblPing.ForeColor = System.Drawing.Color.Yellow;
                    lblEstado.Text = "No Jugable";
                }
                else
                {
                    lblPing.ForeColor = System.Drawing.Color.Green;
                    lblEstado.Text = "Excelente";
                }

                lblPing.Text = a.ToString();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.BalloonTipTitle = "LoLPing";
                notifyIcon1.BalloonTipText = "La aplicacion se encuentra minimizada";
                notifyIcon1.ShowBalloonTip(500);

                this.Hide();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnAbout_Click(object sender, EventArgs e)
        {
            
        }

        private void mnRestaurar_Click(object sender, EventArgs e)
        {
            notifyIcon1_DoubleClick(null, null);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            myTimer.Enabled = false;
        }


        //private void CargarPing()
        //{
        //    //// Create a timer
        //    //System.Timers.Timer myTimer = new System.Timers.Timer();
        //    //// Tell the timer what top do when it elapses
        //    //myTimer.Elapsed += new ElapsedEventHandler(CargarPing);
        //    //// Set it to go off every five seconds
        //    //myTimer.Interval = 1000;
        //    //// And start it        
        //    //myTimer.Enabled = true;
        //}
    }
}
