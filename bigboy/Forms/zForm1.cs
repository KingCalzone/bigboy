using System;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using JRPC_Client;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Threading;
using System.Windows.Forms;
using XDevkit;
using MaterialSkin;

using System.IO;
using System.Windows;
using System.Reflection;
using Tulpep.NotificationWindow;
using security;
using System.Net.Http;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment;
using System.Linq;
using System.Threading.Tasks;

namespace bigboy
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //																			      GLOBAL																								  //

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class zForm1 : MaterialSkin.Controls.MaterialForm
    {
        public zForm1()
        {
            InitializeComponent();
            security.processes.pulse();
            setuptool();
            startRPC();
        }

        public bool yes;
        public bool no;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                bool connected = Main.XDK.Connect(out Main.XDK, "default");
                if (connected)
                {
                    ConnectedSetup();
                }
                else
                {
                    DisconnectedSetup();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("WTF MANNNNNN");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //																			      FORMS																								      //

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        int tcb = 0;
        int tcb2 = 0;
        private void CalzoneBay(object sender, EventArgs e)
        {
            while (tcb == 0)
            {
                TheCalzoneBay TheCalzoneBay = new TheCalzoneBay();
                TheCalzoneBay.Show();
                TheCalzoneBay.Activate();
                tcb++;
                tcb++;
            }
            if (tcb != 0)
            {
                if (tcb2 == 0)
                {
                    notifications.tcb();
                    tcb2++;
                }
                tcb--;
            }
        }

        int ds = 0;
        int ds2 = 0;
        private void DiscordServers(object sender, EventArgs e)
        {
            while (ds == 0)
            {
                discordservers discord = new discordservers();
                discord.Show();
                discord.Activate();
                ds++;
                ds++;
            }
            if (ds != 0)
            {
                if (ds2 == 0)
                {
                    notifications.discord();
                    ds2++;
                }
                ds--;
            }
        }


        int trai = 0;
        int ners = 0;
        private void xpgamesaves(object sender, EventArgs e)
        {
            while (trai == 0)
            {
                trainers trainer = new trainers();
                trainer.Show();
                trainer.Activate();
                trai++;
                trai++;
            }
            if (trai != 0)
            {
                if (ners == 0)
                {
                    ners++;
                }
                trai--;
            }
        }

        int cc = 0;
        int cc2 = 0;
        private void ConsoleCommander(object sender, EventArgs e)
        {
            while (cc == 0)
            {
                ConsoleCmd consolecmd = new ConsoleCmd();
                consolecmd.Show();
                consolecmd.Activate();
                cc++;
                cc++;
            }
            if (cc != 0)
            {
                if (cc2 == 0)
                {
                    cc2++;
                }
                cc--;
            }
        }

        int xbl = 0;
        int xbl2 = 0;
        private void xbla(object sender, EventArgs e)
        {
            while (xbl == 0)
            {
                XBLA xbla = new XBLA();
                xbla.Show();
                xbla.Activate();
                xbl++;
                xbl++;
            }
            if (xbl != 0)
            {
                if (xbl2 == 0)
                {
                    notifications.xpg();
                    xbl2++;
                }
                xbl--;
            }
        }

        int co = 0;
        int d4 = 0;
        private void cod4(object sender, EventArgs e)
        {
            while (co == 0)
            {
                cod4 cod4 = new cod4();
                cod4.Show();
                cod4.Activate();
                co++;
                co++;
            }
            if (co != 0)
            {
                if (d4 == 0)
                {
                    d4++;
                }
                co--;
            }
        }

        int wa = 0;
        int w = 0;
        private void cod5(object sender, EventArgs e)
        {
            while (wa == 0)
            {
                cod5 cod5 = new cod5();
                cod5.Show();
                cod5.Activate();
                wa++;
                wa++;
            }
            if (wa != 0)
            {
                if (w == 0)
                {
                    w++;
                }
                wa--;
            }
        }

        int ok = 0;
        int ok2 = 0;
        private void mw2(object sender, EventArgs e)
        {
            while (ok == 0)
            {
                mw2 mw2 = new mw2();
                mw2.Show();
                mw2.Activate();
                ok++;
                ok++;
            }
            if (ok != 0)
            {
                if (ok2 == 0)
                {
                    ok2++;
                }
                ok--;
            }
        }

        int one = 0;
        int two = 0;
        private void mw3(object sender, EventArgs e)
        {
            while (one == 0)
            {
                mw3 mw3 = new mw3();
                mw3.Show();
                mw3.Activate();
                one++;
                one++;
            }
            if (one != 0)
            {
                if (two == 0)
                {
                    two++;
                }
                one--;
            }
        }

        int three = 0;
        int four = 0;
        private void bo1(object sender, EventArgs e)
        {
            while (three == 0)
            {
                bo1 bo1 = new bo1();
                bo1.Show();
                bo1.Activate();
                three++;
                three++;
            }
            if (three != 0)
            {
                if (four == 0)
                {
                    four++;
                }
                three--;
            }
        }

        int five = 0;
        int six = 0;
        private void bo2(object sender, EventArgs e)
        {
            while (five == 0)
            {
                bo2 bo2 = new bo2();
                bo2.Show();
                bo2.Activate();
                five++;
                five++;
            }
            if (five != 0)
            {
                if (six == 0)
                {
                    six++;
                }
                five--;
            }
        }

        int bl = 0;
        int o3 = 0;
        private void BO3(object sender, EventArgs e)
        {
            while (bl == 0)
            {
                bo3 bo3 = new bo3();
                bo3.Show();
                bo3.Activate();
                bl++;
                bl++;
                if (bl != 0)
                {
                    if (o3 == 0)
                    {
                        o3++;
                    }
                }
                bl--;
            }
        }

        int gh = 0;
        int os = 0;
        private void ghosts(object sender, EventArgs e)
        {
            while (gh == 0)
            {
                ghosts ghosts = new ghosts();
                ghosts.Show();
                ghosts.Activate();
                gh++;
                gh++;
                if (gh != 0)
                {
                    if (os == 0)
                    {
                        os++;
                    }
                    gh--;
                }
            }
        }

        int a = 0;
        int war = 0;
        private void AW(object sender, EventArgs e)
        {
            while (a == 0)
            {
                a++;
                a++;
                if (a != 0)
                {
                    if (war == 0)
                    {
                        war++;
                    }
                    a--;
                }
            }
        }

        int battle = 0;
        int field = 0;
        private void battlefield(object sender, EventArgs e)
        {
            while (battle == 0)
            {
                Battlefield battlefield = new Battlefield();
                battlefield.Show();
                battlefield.Activate();
                battle++;
                battle++;
            }
            if (battle != 0)
            {
                if (field == 0)
                {
                    field++;
                }
                battle--;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //																			      UTILITIES																								  //

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private string check;
        private string xblcheck()
        {
            uint num = Main.XDK.Call<uint>(2171219848U, new object[]
            {
                252,
                360451U,
                0,
                0
            });
            if (num == 1380593U)
            {
                this.check = "Offline";
            }
            else
            {
                this.check = "Connected";
            }
            return this.check;
        }

        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        public void HexToString()
        {
            byte[] data = FromHex(StringBox.Text);
            string s = Encoding.ASCII.GetString(data);
            StringBox.Text = s;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (this.themes.SelectedItem.ToString() == "Light")
            {

                if (yes == true)
                {
                    try
                    {
                        Themes.light();
                        ConnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
                if (no == true)
                {
                    try
                    {
                        Themes.light();
                        DisconnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            if (this.themes.SelectedItem.ToString() == "Dark")
            {

                if (yes == true)
                {
                    try
                    {
                        Themes.dark();
                        ConnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
                if (no == true)
                {
                    try
                    {
                        Themes.dark();
                        DisconnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            if (this.themes.SelectedItem.ToString() == "Gray")
            {
                if (yes == true)
                {
                    try
                    {
                        Themes.grey();
                        ConnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
                if (no == true)
                {
                    try
                    {
                        Themes.grey();
                        DisconnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            if (this.themes.SelectedItem.ToString() == "Blue")
            {
                if (yes == true)
                {
                    try
                    {
                        Themes.blue();
                        ConnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
                if (no == true)
                {
                    try
                    {
                        Themes.blue();
                        DisconnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            if (this.themes.SelectedItem.ToString() == "Green")
            {
                if (yes == true)
                {
                    try
                    {
                        Themes.green();
                        ConnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
                if (no == true)
                {
                    try
                    {
                        Themes.green();
                        DisconnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            if (this.themes.SelectedItem.ToString() == "Red")
            {
                if (yes == true)
                {
                    try
                    {
                        Themes.red();
                        ConnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
                if (no == true)
                {
                    try
                    {
                        Themes.red();
                        DisconnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            if (this.themes.SelectedItem.ToString() == "Yellow")
            {
                if (yes == true)
                {
                    try
                    {
                        Themes.yellow();
                        ConnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
                if (no == true)
                {
                    try
                    {
                        Themes.yellow();
                        DisconnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            if (this.themes.SelectedItem.ToString() == "Purple")
            {
                if (yes == true)
                {
                    try
                    {
                        Themes.purple();
                        ConnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
                if (no == true)
                {
                    try
                    {
                        Themes.purple();
                        DisconnectedSetup();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            if (this.themes.SelectedItem.ToString() == "Original")
            {
                if (yes == true)
                {
                    Themes.original();
                    ConnectedSetup();
                }
                else
                {
                    Themes.original();
                    DisconnectedSetup();
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //																			   TOOLSTRIP																								   //

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkXBLConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xblcheck();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Main.goldSpoof();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Main.SpoofMSP();
        }

        private void grabXUIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.cxkes.me/xbox/xuid");
        }

        private void xbWatsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\Microsoft Xbox 360 SDK\\bin\\win32\\xbwatson.exe");
        }

        private void peekPokerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\chefb\\Desktop\\Envy [unfinished and private]\\tools\\PeekPoker Revision 8\\PeekPoker Revision 8\\Data\\PeekPoker.exe");
        }

        private void tsmi_tools_screen_shot_Click(object sender, EventArgs e)
        {
            Main.screenshot();
        }

        private void searchIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://whatismyipaddress.com/ip/" + ipsearchtextbox.Text);
        }

        private void searchDNSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://mxtoolbox.com/SuperTool.aspx?action=a%3a" + DNSsearchtextbox.Text + "&run=toolpage");
        }

        private void cToPPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.godbolt.org/");
        }

        private void evilBatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\" + Environment.UserName + "\\Desktop\\projects\\LmaoCalzoneTool_171023\\LMAOSoft-master\\LMAOSoft-master\\LMAOSoft\\obj\\Release\\evil\\tool.bat");
        }

        private void spotifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.spotify.com");
        }

        private void soundcloudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.soundcloud.com/");
        }

        private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/");
        }

        private void aisearch_Click(object sender, EventArgs e)
        {
            Process.Start("https://iask.ai/?mode=question&q=" + PC.SpacePlus(AIsearchtextbox.Text));
        }

        private void tsmi_con_default_Click(object sender, EventArgs e)
        {
            bool connected = Main.XDK.Connect(out Main.XDK, "default");
            if (connected && yes == true)
            {

            }
            else
            {
                notifications.disconnected();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/KingCalzone");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Process.Start("https://cash.app/%C2%A3KingCalzone");
        }

        private void sendToConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.rebootitems.SelectedItem.ToString() == "Cold")
            {
                Main.XDK.Reboot(null, null, null, XboxRebootFlags.Cold);
            }
            if (this.rebootitems.SelectedItem.ToString() == "Title")
            {
                Main.XDK.Reboot(null, null, null, XboxRebootFlags.Title);
            }
            if (this.rebootitems.SelectedItem.ToString() == "Active Title")
            {
                Main.XDK.Reboot(null, null, null, XboxRebootFlags.Warm);
            }
            if (this.rebootitems.SelectedItem.ToString() == "Shutdown")
            {
                Main.XDK.ShutDownConsole();
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = this.SpoofTextBox.Text;
            Main.XDK.SetMemory(0x81AA2DDC, Main.spoofXUID(text));
        }

        private void freeVPNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.CurrentDirectory + "\\extras\\Windscribe_2.7.14.exe");
        }

        private void closeToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PC.killtool();
        }

        private void restartToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PC.restarttool();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            string value = hexBox.Text.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            string hexString = BitConverter.ToString(bytes).Replace("-", "");
            hexBox.Text = hexString;
        }

        private void convertToStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HexToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            //this.label16.Text = DateTime.Now.ToString("t");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            this.xblt.Text = xblcheck().ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Start();
            Gamertag.Text = "";
            Thread.Sleep(100);
            Gamertag.Text = Encoding.BigEndianUnicode.GetString(Main.XDK.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //																			      FORM SETUP																			      //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void setuptool()
        {
            // Theme
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
            // label colouring
            label1.BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label2.BackColor = Color.Black;
            label2.ForeColor = Color.White;
            label3.BackColor = Color.Black;
            label3.ForeColor = Color.White;
            label4.BackColor = Color.Black;
            label4.ForeColor = Color.DarkRed;
            label5.BackColor = Color.Black;
            label5.ForeColor = Color.DarkRed;
            label6.BackColor = Color.Black;
            label6.ForeColor = Color.White;
            label7.BackColor = Color.Black;
            label7.ForeColor = Color.White;
            label8.BackColor = Color.Black;
            label8.ForeColor = Color.White;
            label9.BackColor = Color.Black;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label10.BackColor = Color.Black;
            xblstatus.BackColor = Color.Black;
            xblstatus.ForeColor = Color.White;
            label12.ForeColor = Color.White;
            label12.BackColor = Color.Black;
            label3.BackColor = Color.Black;
            label3.ForeColor = Color.White;
            // button enabling
            button1.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
            trainers.Enabled = true;
            // button disabling
            button7.Enabled = false;
            button7.BackColor = Color.Black;
            button7.ForeColor = Color.White;
            rGHToolStripMenuItem.Enabled = false;
            quickLauncherToolStripMenuItem.Enabled = false;
            //Global Setups
            rGHToolStripMenuItem.ForeColor = Color.Red;
            tsmi_connect.ForeColor = Color.Black;
            tsmi_con_default.ForeColor = Color.Black;
            restartToolToolStripMenuItem.ForeColor = Color.Black;
            closeToolToolStripMenuItem.ForeColor = Color.Black;
            tsmi_reboot.ForeColor = Color.Black;
            rebootitems.ForeColor = Color.Black;
            rebootitems.BackColor = Color.White;
            sendToConsoleToolStripMenuItem.ForeColor = Color.Black;
            split.ForeColor = Color.Black;
            toolStripMenuItem5.ForeColor = Color.Black;
            toolStripMenuItem7.ForeColor = Color.Black;
            tsmi_tools.ForeColor = Color.Black;
            patchesToolStripMenuItem.ForeColor = Color.Black;
            quickLauncherToolStripMenuItem.ForeColor = Color.Red;
            toolsToolStripMenuItem.ForeColor = Color.Black;
            musicToolStripMenuItem.ForeColor = Color.Black;
            helpToolStripMenuItem.ForeColor = Color.Black;
            customisationToolStripMenuItem.ForeColor = Color.Black;
        }

        void DisconnectedSetup()
        {
            no = true;
            xblstatus.Visible = false;
            xblt.Visible = false;
            label15.Visible = false;
            Gamertag.Visible = false;
            SignInAs.Visible = false;
            label11.Visible = false;
            label18.Visible = false;
            ip.Visible = false;
            ipt.Visible = false;
            label20.Visible = false;
            label14.BackColor = Color.Black;
            label14.Location = new Point(665, 33);
            label14.Text = "|";
            label10.BackColor = Color.Black;
            label10.Location = new Point(602, 33);
            label10.ForeColor = Color.Red;
            label10.Text = "Offline";
            label12.BackColor = Color.Black;
            label12.ForeColor = Color.White;
            label12.Text = "Tool Status:";
            label12.Location = new Point(520, 33);
            rpcstatus.BackColor = Color.Black;
            rpcstatus.Text = "RPC Status:";
            rpcstatus.Location = new Point(690, 33);
            rpc.BackColor = Color.Black;
            rpc.Text = rpcworks();
            rpc.Location = new Point(780, 33);
            rpc.Size = new Size(93, 24);
        }

        void ConnectedSetup()
        {
            timer1.Start();
            yes = true;
            xblstatus.BackColor = Color.Black;
            xblstatus.ForeColor = Color.White;
            xblstatus.Text = "Xbox Live Status:";
            xblstatus.Location = new Point(1111, 33);
            label10.ForeColor = Color.Green;
            label10.BackColor = Color.Black;
            label10.Text = "Connected";
            label10.Location = new Point(607, 33);
            label12.ForeColor = Color.White;
            label12.BackColor = Color.Black;
            label12.Text = "Tool Status:";
            label12.Location = new Point(520, 33);
            xblt.Text = xblcheck();
            if (xblt.Text == "Offline")
            {
                xblt.Location = new Point();
                xblt.BackColor = Color.Black;
                xblt.ForeColor = Color.Red;
                xblt.Location = new Point(1231, 33);
            }
            else
            {
                xblt.BackColor = Color.Black;
                xblt.ForeColor = Color.Green;
                xblt.Location = new Point(1231, 33);
            }
            label14.Text = "  |";
            label14.BackColor = Color.Black;
            label14.ForeColor = Color.White;
            label14.Location = new Point(682, 33);
            label15.Text = "  |";
            label15.BackColor = Color.Black;
            label15.ForeColor = Color.White;
            label15.Location = new Point(1088, 33);
            Gamertag.BackColor = Color.Black;
            Gamertag.ForeColor = Color.White;
            Gamertag.Text = Encoding.BigEndianUnicode.GetString(Main.XDK.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]);
            Gamertag.Location = new Point(998, 33);
            SignInAs.BackColor = Color.Black;
            SignInAs.ForeColor = Color.White;
            SignInAs.Text = "Signed In As:";
            SignInAs.Location = new Point(909, 33);
            label11.BackColor = Color.Black;
            label11.Visible = false;
            label11.Text = "|";
            label11.Location = new Point(1495, 33);
            label18.Text = "|";
            label18.ForeColor = Color.White;
            label18.BackColor = Color.Black;
            label18.Location = new Point(1309, 33);
            rpcstatus.BackColor = Color.Black;
            rpcstatus.Text = "RPC Status:";
            rpcstatus.Location = new Point(1330, 33);
            rpc.BackColor = Color.Black;
            rpc.Location = new Point(1418, 33);
            rpc.Size = new Size(93, 24);
            label20.BackColor = Color.Black;
            label20.Text = "|";
            label20.Location = new Point(883, 33);
            ip.BackColor = Color.Black;
            ip.Text = "Console IP:";
            ip.Location = new Point(704, 33);
            ipt.BackColor = Color.Black;
            ipt.Text = Main.XDK.XboxIP();
            ipt.Location = new Point(784, 33);
            materialButton1.Location = new Point(1523, 33);
            Thread.Sleep(1000);
            Main.gamebeingplayed();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //																			      RPC																								      //

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DiscordRpcClient client;
        void updateRPC()
        {
            var timer = new System.Timers.Timer(1);
            timer.Elapsed += (sender, args) => { client.Invoke(); };
            timer.Start();
        }

        void startRPC()
        {
            try
            {
                Process[] Discord = Process.GetProcessesByName("Discord");
                if (Discord.Length == 0)
                {
                    rpc.Text = off.ToString();
                }
                else
                {
                    Initialize();
                    Thread.Sleep(1);
                    updateRPC();
                    rpc.ForeColor = Color.Green;
                    rpc.Text = on.ToString();
                    Thread.Sleep(5000);
                }
            }
            catch
            {

            }
        }

        string on = "Connected";
        string off = "Open Discord";
        string rpcworks()
        {
            try
            {
                startRPC();
                Thread.Sleep(1);
                rpc.ForeColor = Color.Green;
                return rpc.Text = on.ToString();
            }
            catch
            {
                rpc.ForeColor = Color.Red;
                return rpc.Text = off.ToString();
            }
        }

        void Deinitialize()
        {
            client.Dispose();
            updateRPC();
            rpc.Text = "Disconnected";
            rpc.ForeColor = Color.Red;
            rpc.BackColor = Color.Black;
        }

        string ss = "ss";
        void susrpc()
        {
            while (ss == "ss")
            {
                client.SetPresence(new RichPresence()
                {
                    Details = "*WHY SO CURIOUS BRO*",
                    Assets = new Assets()
                    {
                        LargeImageKey = "safe",
                    }
                });;
                Thread.Sleep(3000);
                client.SetPresence(new RichPresence()
                {
                    Details = "None of your business!",
                    Assets = new Assets()
                    {
                        LargeImageKey = "safe",
                    }
                });;
                Thread.Sleep(5000);
                Thread a = new Thread(susrpc);
            }
        }

        void advertiseaplus()
        {
            while (ss == "ss")
            {
                client.SetPresence(new RichPresence()
                {
                    Details = "All Xbox 360 Cod Unlocks",
                    Assets = new Assets()
                    {
                        LargeImageKey = "safe",
                    }
                }); ;
                Thread.Sleep(5000);
                client.SetPresence(new RichPresence()
                {
                    Details = "Xbox Services/RGH Sellers",
                    Assets = new Assets()
                    {
                        LargeImageKey = "safe",
                    }
                }); ;
                Thread.Sleep(5000);
                client.SetPresence(new RichPresence()
                {
                    Details = "Join A+ Lobbies For More ;)",
                    Assets = new Assets()
                    {
                        LargeImageKey = "safe",
                    }
                }); ;
                Thread.Sleep(5000);
                Thread a = new Thread(advertiseaplus);
            }
        }

        void Initialize()
        {

            //Create a Discord client
            client = new DiscordRpcClient("1092490270366515220");

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            //Connect to the RPC
            client.Initialize();

            Timestamps rpctime = new Timestamps()
            {
                Start = DateTime.UtcNow
            };

            //Set the rich presence
            client.SetPresence(new RichPresence()
            {
                Details = "None of your business!",
                Timestamps = new Timestamps(DateTime.Now),
                Assets = new Assets()
                {
                    LargeImageKey = "safe",
                }
            });;;;;;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //																			      IDK																								      //

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SignInAs_Click(object sender, EventArgs e)
        {

        }
        
        private void editorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void rebootitems_Click(object sender, EventArgs e)
        {

        }
        
        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void tsmi_reboot_Click(object sender, EventArgs e)
        {

        }
        
        private void LLoader(object sender, EventArgs e)
        {

        }

        private void tsmi_apps_xuid_spoofer_Click(object sender, EventArgs e)
        {

        }

        private void Gamertag_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void ms_main_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ipt_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void rpcstatus_Click(object sender, EventArgs e)
        {

        }

        private void rpc_Click(object sender, EventArgs e)
        {

        }

        private void ip_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (yes == true)
            {
                ConnectedSetup();
            }
            if (no == true)
            {
                DisconnectedSetup();
            }
            else
            {

            }
        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startRPC();
            rpc.Text = "Connected";
            rpc.ForeColor = Color.Green;
            rpc.BackColor = Color.Black;
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deinitialize();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            advertiseaplus();
        }
    }
}
