using System;
using System.Diagnostics;
using MaterialSkin;
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
    public partial class trainers : MaterialSkin.Controls.MaterialForm
    {
        public trainers()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
        }

        int trai = 0;
        int ners = 0;
        private void trainers_Load(object sender, EventArgs e)
        {
            security.processes.pulse();
            while (trai == 0)
            {
                trai++;
            }
            if (trai != 0)
            {
                if (ners == 0)
                {
                    notifications.trainers();
                    ners++;
                }
            }
            notifications.trainers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.xpgamesaves.com/forums/original-xbox.532/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.xpgamesaves.com/threads/teamxpg-archive-collection.113733/");
        }
    }
}
