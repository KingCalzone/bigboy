using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MaterialSkin;


namespace bigboy
{
    public partial class discordservers : MaterialSkin.Controls.MaterialForm
    {
        public discordservers()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
        }

        private string GS;
        private void SGS_Click(object sender, EventArgs e)
        {
            string text = this.GamingServers.SelectedItem.ToString();
            this.GS = text;
            if (this.GamingServers.SelectedItem.ToString() == "Cod4 Official Discord")
            {
                Process.Start("https://discord.gg/AGqawzXWJG");
            }
            if (this.GamingServers.SelectedItem.ToString() == "Cod: Black Ops Official Server")
            {
                Process.Start("https://discord.gg/MpJ3ru4wWH");
            }
            if (this.GamingServers.SelectedItem.ToString() == "Cod: WaW (Official Server)")
            {
                Process.Start("https://discord.gg/cod5");
            }
            if (this.GamingServers.SelectedItem.ToString() == "MW Community")
            {
                Process.Start("https://discord.gg/JNnJExjSJg ");
            }
            if (this.GamingServers.SelectedItem.ToString() == "Populate MW3 (#1 MW3 Discord Server)")
            {
                Process.Start("https://discord.gg/ghSX9NMgbm");
            }
            if (this.GamingServers.SelectedItem.ToString() == "rMW2 Discord")
            {
                Process.Start("https://discord.gg/rmw2");
            }
            if (this.GamingServers.SelectedItem.ToString() == ">>>> THE ACTIVITY IN SERVERS VARIES <<<<")
            {
                MessageBox.Show("Bro...", "Are you damn retarded?");
            }
            if (this.GamingServers.SelectedItem.ToString() == ">>>> CHEATING IN ANY ABOVE IS A BAN <<<<")
            {
                MessageBox.Show("Bro...", "Are you damn retarded?");
            }
        }

        private string MS;
        private void SMS_Click(object sender, EventArgs e)
        {
            if (this.ModdingServers.SelectedItem.ToString() == "")
            {
                Process.Start("");
            }
        }

        private string SS;
        private void SSS_Click(object sender, EventArgs e)
        {
            if (this.StealthServers.SelectedItem.ToString() == "")
            {
                Process.Start("");
            }
        }

        private string CS;
        private void SCS_Click(object sender, EventArgs e)
        {
            if (this.ChillServers.SelectedItem.ToString() == "")
            {
                Process.Start("");
            }
        }

        private void discordservers_Load(object sender, EventArgs e)
        {
            security.processes.pulse();
            notifications.discord();
        }
    }
}
