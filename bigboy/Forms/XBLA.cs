using System;
using System.Diagnostics;
using System.Drawing;
using JRPC_Client;
using System.Reflection;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using MaterialSkin;
using XDevkit;
using security;

namespace bigboy
{
    public partial class XBLA : MaterialSkin.Controls.MaterialForm
    {
        public XBLA()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
        }

        private void XBLA_Load(object sender, EventArgs e)
        {
            security.processes.pulse();
            //notifications.xbla();
        }
    }
}
