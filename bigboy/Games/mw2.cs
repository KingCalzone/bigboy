using System;
using System.Diagnostics;
using System.Drawing;
using JRPC_Client;
using System.Reflection;
using System.Threading;
using MaterialSkin;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using XDevkit;
using security;

namespace bigboy
{
    public partial class mw2 : MaterialSkin.Controls.MaterialForm
    {
        public mw2()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);

            //button34.BackColor = Color.Black;
            //button34.ForeColor = Color.White;
            button88.BackColor = Color.Black;
            button88.ForeColor = Color.White;
            button90.BackColor = Color.Black;
            button90.ForeColor = Color.White;
            button91.BackColor = Color.Black;
            button91.ForeColor = Color.White;
            button92.BackColor = Color.Black;
            button92.ForeColor = Color.White;

            checkBox13.BackColor = Color.Black;
            checkBox15.BackColor = Color.Black;
            checkBox16.BackColor = Color.Black;
            checkBox22.BackColor = Color.Black;
            checkBox23.BackColor = Color.Black;
            checkBox24.BackColor = Color.Black;
            checkBox25.BackColor = Color.Black;
            checkBox26.BackColor = Color.Black;
            checkBox27.BackColor = Color.Black;
            checkBox28.BackColor = Color.Black;
            checkBox29.BackColor = Color.Black;
            checkBox35.BackColor = Color.Black;
            checkBox36.BackColor = Color.Black;
            checkBox37.BackColor = Color.Black;
            checkBox74.BackColor = Color.Black;
            checkBox75.BackColor = Color.Black;
            checkBox76.BackColor = Color.Black;

            button88.Hide();
            button90.Hide();
            button91.Hide();
            button92.Hide();
        }

        public XDevkit.IXboxConsole ct2;
        public static IXboxConsole XDK;
        private void mw2_Load(object sender, EventArgs e)
        {
            security.processes.pulse();
            try
            {
                bool connected = ct2.Connect(out ct2, "default");
                if (connected)
                {
                    //notifications.mw2();
                    label11.ForeColor = Color.White;
                    label11.Text = "Status:";
                    label10.ForeColor = Color.Green;
                    label10.Text = "Connected";
                }
                else
                {
                    notifications.disconnected();
                    label11.ForeColor = Color.White;
                    label11.Text = "Status:";
                    label10.ForeColor = Color.Red;
                    label10.Text = "Disonnected";
                }
            }
            catch (Exception)
            {
                Console.WriteLine("WTF MANNNNNN");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void cbufmw2(string text)
        {
            ct2.CallVoid(0x82224990, new object[] { 0, text });
        }

        private void ClientsMW2()
        {
            mw2mpclientlist.Items.Add("Client Gamertags");
            mw2mpclientlist.Items.Add("-------------------------");
            mw2mpclientlist.Items.Add("-1 = ALL CLIENTS!");
            mw2mpclientlist.Items.Add(GrabClientsMW2(0));
            mw2mpclientlist.Items.Add(GrabClientsMW2(1));
            mw2mpclientlist.Items.Add(GrabClientsMW2(2));
            mw2mpclientlist.Items.Add(GrabClientsMW2(3));
            mw2mpclientlist.Items.Add(GrabClientsMW2(4));
            mw2mpclientlist.Items.Add(GrabClientsMW2(5));
            mw2mpclientlist.Items.Add(GrabClientsMW2(6));
            mw2mpclientlist.Items.Add(GrabClientsMW2(7));
            mw2mpclientlist.Items.Add(GrabClientsMW2(8));
            mw2mpclientlist.Items.Add(GrabClientsMW2(9));
            mw2mpclientlist.Items.Add(GrabClientsMW2(10));
            mw2mpclientlist.Items.Add(GrabClientsMW2(11));
            mw2mpclientlist.Items.Add(GrabClientsMW2(12));
            mw2mpclientlist.Items.Add(GrabClientsMW2(13));
            mw2mpclientlist.Items.Add(GrabClientsMW2(14));
            mw2mpclientlist.Items.Add(GrabClientsMW2(15));
            mw2mpclientlist.Items.Add(GrabClientsMW2(16));
            mw2mpclientlist.Items.Add(GrabClientsMW2(17));
        }

        private static uint GetPlayerStateMW2(int clientindex)
        {
            byte[] memory = Main.GetMemory(GetEntityMW2(clientindex) + 0x158, 4);
            Array.Reverse(memory);
            return BitConverter.ToUInt32(memory, 0);
        }
        private static uint GetEntityMW2(int clientindex)
        {
            return (((uint)(clientindex * 640)) + 0x82F03600);
        }

        public static string GrabClientsMW2(int clientindex)
        {
            return Main.GetString(GetPlayerStateMW2(clientindex) + 0x3290);
        }

        void ScanMW2()
        {
            mw2mpclientlist.Items.Clear();
            Thread.Sleep(1000);
            {
                ClientsMW2();
            }
        }

        private string MW2ReturnMapname(string map)
        {
            switch (map)
            {
                case "Favela": return "mp_favela";
                case "Highrise": return "mp_highrise";
                case "Scrapyard": return "mp_boneyard";
                case "Karachi": return "mp_checkpoint";
                case "Underpass": return "mp_underpass";
                case "Invasion": return "mp_invasion";
                case "Wasteland": return "mp_brecourt";
                case "Terminal": return "mp_terminal";
                case "Quarry": return "mp_quarry";
                case "Estate": return "mp_estate";
                case "Rust": return "mp_rust";
                case "Sub Base": return "mp_subbase";
                case "Derail": return "mp_derail";
                case "Skidrow": return "mp_nightshift";
                case "Afghan": return "mp_afghan";
                case "Rundown": return "mp_rundown";
            }
            return "mp_afghan";
        }

        private string MW2ReturnGametype(string gametype)
        {
            switch (gametype)
            {
                case "Capture The Flag": return "ctf";
                case "Search and Destroy": return "sd";
                case "Domination": return "dom";
                case "Free for All": return "dm";
                case "GTW": return "gtnw";
                case "Headquaters": return "koth";
                case "Sabotage": return "sab";
                case "Demolition": return "dd";
                case "Team Deathmatch": return "war";
            }
            return "dm";
        }

        public static void DisableGame()
        {
            byte[] data = new byte[4];
            data[0] = 0x48;
            data[3] = 12;
            Main.SetMemory(0x822CC830, data);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button34_Click(object sender, EventArgs e)
        {
            if (checkBox13.Checked == false)
            {
                ct2.SetMemory(2182306787U, new byte[1]);
                checkBox13.Checked = true;
            }
            else
            {
                ct2.SetMemory(2182306787U, new byte[]
                {
                    7
                });
                checkBox13.Checked = false;
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (checkBox74.Checked == false)
            {
                ct2.WriteUInt32(0x820E5B38, 0x60000000);
                ct2.WriteUInt32(0x820E657C, 0x60000000);
                checkBox74.Checked = true;
            }
            else
            {
                ct2.WriteUInt32(0x820E5B38, 0x4BFFEAA9);
                ct2.WriteUInt32(0x820E657C, 0x4BFFFBC5);
                checkBox74.Checked = false;
            }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            if (checkBox23.Checked == false)
            {
                ct2.WriteUInt32(0x820E6570, 0x60000000);
                ct2.WriteUInt32(0x82128AA8, 0x60000000);
                checkBox23.Checked = true;
            }
            else
            {
                ct2.WriteUInt32(0x820E6570, 0x4BFFF989);
                ct2.WriteUInt32(0x82128AA8, 0x4BFFA970);
            }
        }

        private void button78_Click(object sender, EventArgs e)
        {
            if (checkBox26.Checked == false)
            {
                //Stun
                ct2.WriteUInt32(0x825556F4, 0x00000000); //blurBlendFadeTime
                ct2.WriteUInt32(0x825556F4 + 0x4, 0x00000000); //blurBlendTime
                ct2.WriteUInt32(0x825556F4 + 0x8, 0x00000000); //whiteFadeTime
                ct2.WriteUInt32(0x825556F4 + 0xC, 0x00000000); //shotFadeTime
                ct2.WriteUInt32(0x825556F4 + 0x10, 0x00000000); //screenType
                ct2.WriteUInt32(0x825556F4 + 0x14, 0x00000000); //screenType2
                ct2.WriteUInt32(0x825556F4 + 0x18, 0x00000000); //viewKickPeriod
                ct2.WriteUInt32(0x825556F4 + 0x1C, 0x00000000); //viewKickRadius
                ct2.WriteUInt32(0x825556F4 + 0x23, 0x00); //shockSound
                ct2.WriteUInt32(0x825556F4 + 0x254, 0x00000000); //lookControl
                ct2.WriteUInt32(0x825556F4 + 0x258, 0x00000000); //lookControlFadeTime
                ct2.WriteUInt32(0x825556F4 + 0x25C, 0x00000000); //lcMouseSensitivityScale
                ct2.WriteUInt32(0x825556F4 + 0x260, 0x00000000); //lcMaxPitchSpeed
                ct2.WriteUInt32(0x825556F4 + 0x264, 0x00000000); //lcMaxYawSpeed
                ct2.WriteUInt32(0x825556F4 + 0x128, 0x00000000); //soundFadeInTime
                ct2.WriteUInt32(0x825556F4 + 0x12C, 0x00000000); //soundFadeOutTime

                //Flashbang
                ct2.WriteUInt32(0x8255595C, 0x00000000); //blurBlendFadeTime
                ct2.WriteUInt32(0x8255595C + 0x4, 0x00000000); //blurBlendTime
                ct2.WriteUInt32(0x8255595C + 0x8, 0x00000000); //whiteFadeTime
                ct2.WriteUInt32(0x8255595C + 0xC, 0x00000000); //shotFadeTime
                ct2.WriteUInt32(0x8255595C + 0x10, 0x00000000); //screenType
                ct2.WriteUInt32(0x8255595C + 0x14, 0x00000000); //screenType2
                ct2.WriteUInt32(0x8255595C + 0x18, 0x00000000); //viewKickPeriod
                ct2.WriteUInt32(0x8255595C + 0x1C, 0x00000000); //viewKickRadius
                ct2.WriteUInt32(0x8255595C + 0x23, 0x00); //shockSound
                ct2.WriteUInt32(0x8255595C + 0x254, 0x00000000); //lookControl
                ct2.WriteUInt32(0x8255595C + 0x258, 0x00000000); //lookControlFadeTime
                ct2.WriteUInt32(0x8255595C + 0x25C, 0x00000000); //lcMouseSensitivityScale
                ct2.WriteUInt32(0x8255595C + 0x260, 0x00000000); //lcMaxPitchSpeed
                ct2.WriteUInt32(0x8255595C + 0x264, 0x00000000); //lcMaxYawSpeed
                ct2.WriteUInt32(0x8255595C + 0x128, 0x00000000); //soundFadeInTime
                ct2.WriteUInt32(0x8255595C + 0x12C, 0x00000000); //soundFadeOutTime
                checkBox26.Checked = true;
            }
            else
            {
                //Stun
                ct2.WriteUInt32(0x825556F4, 0x00000000); //blurBlendFadeTime
                ct2.WriteUInt32(0x825556F4 + 0x4, 0x000003E8); //blurBlendTime
                ct2.WriteUInt32(0x825556F4 + 0x8, 0x00000190); //whiteFadeTime
                ct2.WriteUInt32(0x825556F4 + 0xC, 0x000DAC00); //shotFadeTime
                ct2.WriteUInt32(0x825556F4 + 0x10, 0x0000000); //screenType
                ct2.WriteUInt32(0x825556F4 + 0x14, 0x00000000); //screenType2
                ct2.WriteUInt32(0x825556F4 + 0x18, 0x00000BB8); //viewKickPeriod
                ct2.WriteUInt32(0x825556F4 + 0x1C, 0x3AAEC33F); //viewKickRadius
                ct2.WriteUInt32(0x825556F4 + 0x23, 0x01); //shockSound
                ct2.WriteUInt32(0x825556F4 + 0x254, 0x01000000); //lookControl
                ct2.WriteUInt32(0x825556F4 + 0x258, 0x000007D0); //lookControlFadeTime
                ct2.WriteUInt32(0x825556F4 + 0x25C, 0x3F000000); //lcMouseSensitivityScale 
                ct2.WriteUInt32(0x825556F4 + 0x260, 0x42340000); //lcMaxPitchSpeed
                ct2.WriteUInt32(0x825556F4 + 0x264, 0x42340000); //lcMaxYawSpeed
                ct2.WriteUInt32(0x825556F4 + 0x128, 0x000000FA); //soundFadeInTime
                ct2.WriteUInt32(0x825556F4 + 0x12C, 0x000009C4); //soundFadeOutTime

                //Flashbang
                ct2.WriteUInt32(0x8255595C, 0x00000000); //blurBlendFadeTime
                ct2.WriteUInt32(0x8255595C + 0x4, 0x0003E800); //blurBlendTime
                ct2.WriteUInt32(0x8255595C + 0x8, 0x00019000); //whiteFadeTime
                ct2.WriteUInt32(0x8255595C + 0xC, 0x000DAC00); //shotFadeTime
                ct2.WriteUInt32(0x8255595C + 0x10, 0x0003E800); //screenType
                ct2.WriteUInt32(0x8255595C + 0x14, 0x00000100); //screenType2
                ct2.WriteUInt32(0x8255595C + 0x18, 0x000BB83A); //viewKickPeriod
                ct2.WriteUInt32(0x8255595C + 0x1C, 0xAEC33F3D); //viewKickRadius
                ct2.WriteUInt32(0x8255595C + 0x23, 0x01); //shockSound
                ct2.WriteUInt32(0x8255595C + 0x254, 0x01000000); //lookControl
                ct2.WriteUInt32(0x8255595C + 0x258, 0x000007D0); //lookControlFadeTime
                ct2.WriteUInt32(0x8255595C + 0x25C, 0x3F000000); //lcMouseSensitivityScale
                ct2.WriteUInt32(0x8255595C + 0x260, 0x42B40000); //lcMaxPitchSpeed
                ct2.WriteUInt32(0x8255595C + 0x264, 0x42B40000); //lcMaxYawSpeed
                ct2.WriteUInt32(0x8255595C + 0x128, 0x000000FA); //soundFadeInTime
                ct2.WriteUInt32(0x8255595C + 0x12C, 0x000007D0); //soundFadeOutTime
                checkBox26.Checked = false;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (checkBox16.Checked == false)
            {
                cbufmw2("g_compassShowEnemies 1");
                checkBox16.Checked = true;
            }
            else
            {
                cbufmw2("g_compassShowEnemies 0");
                checkBox16.Checked = false;
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (checkBox15.Checked == false)
            {
                ct2.SetMemory(2182038067U, new byte[]
                {
                    1
                });
                checkBox15.Checked = true;
            }
            else
            {
                ct2.SetMemory(2182038067U, new byte[1]);
                checkBox15.Checked = false;
            }
        }

        private void button76_Click(object sender, EventArgs e)
        {
            if (checkBox24.Checked == false)
            {
                cbufmw2("cg_thirdperson 1");
                checkBox24.Checked = true;
            }
            else
            {
                cbufmw2("cg_thirdperson 0");
                checkBox24.Checked = false;
            }
        }

        private void button73_Click(object sender, EventArgs e)
        {
            if (checkBox22.Checked == false)
            {
                ct2.SetMemory(0x821123A7, new byte[] { 15 });
                checkBox22.Checked = true;
            }
            else
            {
                ct2.SetMemory(0x821123A7, new byte[] { 4 });
                checkBox22.Checked = false;
            }
        }

        private void button82_Click(object sender, EventArgs e)
        {
            if (checkBox27.Checked == false)
            {
                ct2.SetMemory(2182249727U, new byte[1]);
                checkBox27.Checked = true;
            }
            else
            {
                ct2.SetMemory(2182249727U, new byte[]
                {
                    1
                });
                checkBox27.Checked = false;
            }
        }

        private void button77_Click(object sender, EventArgs e)
        {
            if (checkBox25.Checked == false)
            {
                cbufmw2("r_fullbright 1");
                checkBox25.Checked = true;
            }
            else
            {
                cbufmw2("r_fullbright 0");
                checkBox25.Checked = false;
            }
        }

        private void button96_Click(object sender, EventArgs e)
        {
            if (checkBox28.Checked == false)
            {
                cbufmw2("party_connectToOthers 1; partyMigrate_disabled 1; sv_endGameIfISuck 0; badhost_endgameifisuck 0​; party_maxTeamDiff 8; set party_minplayers 18; set party_connectTimeout 1; party_hostmigration 0");
                checkBox28.Checked = true;
            }
            else
            {
                cbufmw2("set party_minplayers 6; set party_gamestarttimelength 10; set party_pregamestarttimerlength 10; set party_timer 10; set party_connectTimeout 2500");
                checkBox28.Checked = false;
            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            cbufmw2("set xblive_privatematch 1;wait 200;xpartygo;wait 200;set xblive_privatematch 0");
        }

        private void button94_Click(object sender, EventArgs e)
        {
            ct2.CallVoid(2183285136U, new object[]
            {
                0,
                "cmd mr " + ct2.ReadInt32(2187474912U) + " -1 endround"
            });
        }

        private void button93_Click(object sender, EventArgs e)
        {
            DisableGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbufmw2("ui_gametype " + this.MW2ReturnGametype(this.comboBox15.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbufmw2("ui_mapname " + this.MW2ReturnMapname(this.comboBox15.Text));
        }

        private void button215_Click(object sender, EventArgs e)
        {
            ct2.SetMemory(2206967844U, new byte[32]);
            ct2.SetMemory(2206967844U, Encoding.UTF8.GetBytes("Barnacle Boy"));
        }

        private void button115_Click(object sender, EventArgs e)
        {
            ct2.SetMemory(2206967844U, new byte[32]);
            ct2.SetMemory(2206967844U, Encoding.UTF8.GetBytes("Top Suspect"));
        }

        private void button119_Click(object sender, EventArgs e)
        {
            ct2.SetMemory(2206967844U, new byte[32]);
            ct2.SetMemory(2206967844U, Encoding.UTF8.GetBytes("^9%i%i\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009\u0010\n\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001a\u001b\n\u001b\u001a\u0019\u0018\u0017\u0016\u0015\u0014\u0013\u0012\u0011\u0010\u0009\u0008\u0007\u0006\u0005\u0004\u0003\u0002\u0001\n\\\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009\u0010\n\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001a\u001b\n\\n\u001b\u001a\u0019\u0018\u0017\u0016\u0015\u0014\u0013\u0012\u0011\u0010\u0009\u0008\u0007\u0006\u0005\u0004\u0003\u0002\u0001\\\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009\u0010\n\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001a\u001b\n\\^9xD\0"));
        }

        private void button118_Click(object sender, EventArgs e)
        {
            byte[] brr = ct2.GetMemory(0x831A13A4, 19);
            ct2.SetMemory(0x838BA824, brr);
        }

        private void button99_Click(object sender, EventArgs e)
        {
            this.ClientsMW2();
        }

        private void button100_Click(object sender, EventArgs e)
        {
            ScanMW2();
        }

        private void button98_Click(object sender, EventArgs e)
        {
            //ct2.CallVoid(0x82254940, new object[] { -1, 1, "s loc_warnings \"0\"" });
            //ct2.CallVoid(0x82254940, new object[] { -1, 1, "s loc_warningsUI \"0\"" });
            // ct2.CallVoid(0x82254940, new object[] { -1, 1, "f \"^1Red Boxes: ^7ON\"" });
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            int index = this.mw2mpclientlist.SelectedIndex = -1;
            if (index == -1)
            {
                for (int i = 0; i < 0x12; i++)
                {
                    Redboxes(i, false);
                }
            }
            else
            {
                Redboxes(index, false);
            }
        }

        public static void Redboxes(int clientindex, bool enable)
        {
            byte num = enable ? ((byte)0x10) : ((byte)0);
            Main.SetByte(GetPlayerStateMW2(clientindex) + 0x13, num);
        }

        private void button149_Click(object sender, EventArgs e)
        {
            if (checkBox36.Checked == false)
            {
                ct2.CallVoid(0x82254940, new object[] { -1, 1, "s g_speed 400" });
                ct2.CallVoid(0x82254940, new object[] { -1, 1, "f \"^1Super Speed: ^7ON\"" });
                checkBox36.Checked = true;
            }
            else
            {
                ct2.CallVoid(0x82254940, new object[] { -1, 1, "s g_speed 175" });
                ct2.CallVoid(0x82254940, new object[] { -1, 1, "f \"^1Super Speed: ^7OFF\"" });
                checkBox36.Checked = false;
            }
        }

        private void button97_Click(object sender, EventArgs e)
        {
            if (checkBox29.Checked == false)
            {
                ct2.WriteByte(0x820E01AF, 1);
                checkBox29.Checked = true;
            }
            else
            {
                ct2.WriteByte(0x820E01AF, 0);
                checkBox29.Checked = false;
            }
        }

        private void button92_Click(object sender, EventArgs e)
        {

        }

        private void button266_Click(object sender, EventArgs e)
        {
            unlocks.unlockAllMW2();
        }

        int time, xp, winstreak, wins, score, rank, prestige, misses, losses, killstreak, kills, hits, headshots, deaths, assists;

        private void button151_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ct2.SetMemory(2206967844U, new byte[32]);
            ct2.SetMemory(2206967844U, Encoding.UTF8.GetBytes(this.names(this.comboBox1.Text)));
            string yes = BitConverter.GetBytes(ct2.ReadUInt32(2206967844U)).ToString();
            text.Text = yes.ToString();
        }

        void lol12()
        {
            ct2.SetMemory(2206967844U, Encoding.UTF8.GetBytes(this.names(this.comboBox1.Text)));
        } 

        private string names(string names)
        {
            switch (names)
            {
                case "@XBOXLIVE_PARTYENDED": return "@XBOXLIVE_PARTYENDED";
                case "@EXE_TRANSMITERROR": return "@EXE_TRANSMITERROR";
                case "@PLATFORM_KICKEDFROMPARTY": return "@PLATFORM_KICKEDFROMPARTY";
                case "@MP_ENDED_GAME_MIGRATION_FAILED": return "@MP_ENDED_GAME_MIGRATION_FAILED";
                case "@MP_NOGOODHOST": return "@MP_NOGOODHOST";
                case "@EXE_SERVERISFULL": return "@EXE_SERVERISFULL";
                case "@MENU_BIND_KEY_PENDING": return "@MENU_BIND_KEY_PENDING";
                case "@XBOXLIVE_MPNOTALLOWED": return "@XBOXLIVE_MPNOTALLOWED";
                case "@MP_BETACLOSED": return "@MP_BETACLOSED";
                case "@MP_BUILDEXPIRED": return "@MP_BUILDEXPIRED";
                case "@MP_BANNED": return "@MP_BANNED";
                case "@XBOXLIVE_SIGNEDOUTOFLIVE": return "@XBOXLIVE_SIGNEDOUTOFLIVE";
                case "@XBOXLIVE_NOGUESTACCOUNTS": return "@XBOXLIVE_NOGUESTACCOUNTS";
                case "@XBOXLIVE_MUSTLOGIN": return "@XBOXLIVE_MUSTLOGIN";
                case "@XBOXLIVE_NOTREGISTEREDWITHARBITRATION": return "@XBOXLIVE_NOTREGISTEREDWITHARBITRATION";
            }
            return "AutoCalzone";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ct2.SetMemory(2206967844U, new byte[32]);
            ct2.SetMemory(2206967844U, Encoding.UTF8.GetBytes("@MP_BUILDEXPIRED"));
            //ct2.SetMemory(2206967844U, Encoding.UTF8.GetBytes("@mp_banned \n@mp_banned \n@mp_banned \n@mp_banned \n@mp_banned \n@mp_banned \n@mp_banned \n@mp_banned \n@mp_banned \n@mp_banned"));
        }

        void READGT()
        {
            string val = ct2.ReadUInt32(2206967844U).ToString();
        }

        private void mw2mpclientlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button267_Click(object sender, EventArgs e)
        {
            uint offset = 0x831A0DCC; //This was defined but used once? Why? 
            this.xp = unlocks.ConvertRankToXPMW2(int.Parse(this.textBox32.Text));
            unlocks.WriteStatMW2(offset, this.xp);
            ct2.WriteByte(0x831A0DCC + 0x8, Convert.ToByte(this.textBox33.Text));
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(this.textBox34.Text));
            ct2.SetMemory(0x831A0DCC + 0x10, bytes);
        }

        private void button90_Click(object sender, EventArgs e)
        {

        }

        private void button91_Click(object sender, EventArgs e)
        {

        }
    }
}
