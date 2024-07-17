using System;
using System.Diagnostics;
using System.Drawing;
using JRPC_Client;
using System.Reflection;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using XDevkit;
using security;

namespace bigboy
{
    public partial class Halo_Reach : Form
    {
        public Halo_Reach()
        {
            InitializeComponent();
        }

        public XDevkit.IXboxConsole ct2;
        public static IXboxConsole XDK;
        private void Halo_Reach_Load(object sender, EventArgs e)
        {
            security.processes.pulse();
            try
            {
                bool connected = ct2.Connect(out ct2, "default");
                if (connected)
                {
                    
                }
                else
                {
                    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("WTF MANNNNNN");
            }
        }
    }
}
