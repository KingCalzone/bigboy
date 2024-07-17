using System;
using System.Diagnostics;
using System.Drawing;
using JRPC_Client;
using MaterialSkin;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using XDevkit;
using security;

namespace bigboy
{
    public partial class bo3 : MaterialSkin.Controls.MaterialForm
    {
        public bo3()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
        }

        public XDevkit.IXboxConsole ct2;
        private void bo3_Load(object sender, EventArgs e)
        {
            security.processes.pulse();
            try
            {
                bool connected = ct2.Connect(out ct2, "default");
                if (connected)
                {
                    notifications.bo3();
                }
                else
                {
                    notifications.disconnected();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("WTF MANNNNNN");
            }
        }
    }
}
