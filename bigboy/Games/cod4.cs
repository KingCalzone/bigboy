using System;
using System.Windows.Forms.Design;
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
    public partial class cod4 : MaterialSkin.Controls.MaterialForm
    {
        public cod4()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
        }

        public XDevkit.IXboxConsole ct2;
        private void cod4_Load(object sender, EventArgs e)
        {
            security.processes.pulse();
            try
            {
                bool connected = ct2.Connect(out ct2, "default");
                if (connected)
                {
                    notifications.cod4();
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

        

        private void button159_Click(object sender, EventArgs e)
        {
            if (checkBox38.Checked == false)
            {
                Main.NOP(0x822EDAA0);
                checkBox38.Checked = true;
            }
            else
            {
                ct2.SetMemory(0x822EDAA0, new byte[] { 0x48, 3, 0xdd, 0x41 });
                checkBox38.Checked = false;
            }
        }

        private void button158_Click(object sender, EventArgs e)
        {
            if (checkBox39.Checked == false)
            {
                Main.NOP(0x8233169C);
                Main.NOP(0x8233048C);
                checkBox39.Checked = true;
            }
            else
            {
                ct2.SetMemory(0x8233169C, new byte[] { 0x4b, 0xff, 0xb3, 0xdd });
                ct2.SetMemory(0x8233048C, new byte[] { 0x4b, 0xff, 0xc3, 0xb5 });
                checkBox39.Checked = false;
            }
        }

        private void button154_Click(object sender, EventArgs e)
        {
            if (checkBox40.Checked == false)
            {
                Main.NOP(0x82319514);
                checkBox40.Checked = true;
            }
            else
            {
                ct2.SetMemory(0x82319514, new byte[] { 0x48, 1, 0x2f, 0x65 });
                checkBox40.Checked = false;
            }
        }

        private void button156_Click(object sender, EventArgs e)
        {
            if (checkBox41.Checked == false)
            {
                ct2.SetMemory(0x823225C8, new byte[] { 0x3b, 0x40, 0, 1 });
                checkBox41.Checked = true;
            }
            else
            {
                ct2.SetMemory(0x823225C8, new byte[] { 0x56, 0x3a, 6, 0x3e });
                checkBox41.Checked = false;
            }
        }

        void cbufCod4(string text)
        {
            ct2.CallVoid(0x82239FD0, new object[] { 0, text });
        }

        private void button157_Click(object sender, EventArgs e)
        {
            if (checkBox42.Checked == false)
            {
                cbufCod4("set aim_lockon_debug 1;aim_lockon_region_height 1;aim_lockon_region_width 1");
                checkBox42.Checked = true;
            }
            else
            {
                cbufCod4("set aim_lockon_debug 0;aim_lockon_region_height 0;aim_lockon_region_width 0");
                checkBox42.Checked = false;
            }
        }

        private void button155_Click(object sender, EventArgs e)
        {
            if (checkBox43.Checked == false)
            {
                ct2.WriteByte(0x82303ECF, 0x12);
                checkBox43.Checked = true;
            }
            else
            {
                ct2.WriteByte(0x82303ECF, 4);
                checkBox43.Checked = false;
            }
        }

        private void button171_Click(object sender, EventArgs e)
        {
            if (checkBox49.Checked == false)
            {
                byte[] data = new byte[4];
                data[0] = 0x60;
                ct2.SetMemory(0x821A6AD0, data);
                byte[] buffer2 = new byte[4];
                buffer2[0] = 0x48;
                buffer2[3] = 0x34;
                ct2.SetMemory(0x822BD1F4, buffer2);
                checkBox49.Checked = true;
            }
            else
            {
                ct2.SetMemory(0x821A6AD0, new byte[] { 0x41, 0x99, 0, 0xa8 });
                ct2.SetMemory(0x822BD1F4, new byte[] { 0x41, 0x9a, 0, 0x34 });
                checkBox49.Checked = false;
            }
        }

        private void button172_Click(object sender, EventArgs e)
        {
            string caption = Main.GetString(0x8243D708);
            MessageBox.Show("Host: ", caption);
        }

        private void button176_Click(object sender, EventArgs e)
        {
            cbufCod4("cg_fov " + textBox22.Text);
        }

        void EditMotdCod4(string text)
        {
            cbufCod4("motd " + text + "^2 - Powered by calzones ;) ");
            cbufCod4("updategamerprofile");
        }

        private void button161_Click(object sender, EventArgs e)
        {
            EditMotdCod4(textBox18.Text);
        }

        private void button358_Click(object sender, EventArgs e)
        {
            cbufCod4("xpartygo");
        }
        
        private void button357_Click(object sender, EventArgs e)
        {
            cbufCod4("fast_restart");
        }

        private void button167_Click(object sender, EventArgs e)
        {
            int num = Main.Dvar_GetInt("sv_serverid");
            cbufCod4(string.Format("cmd mr {0} -1 endround", num));
        }

        void Teamswitch(string team)
        {
            int num = Main.Dvar_GetInt("sv_serverid");
            cbufCod4(string.Format("cmd mr {0} 4 {1}", num, team));
        }

        private void button168_Click(object sender, EventArgs e)
        {
            Teamswitch(this.comboBox1.SelectedIndex.ToString());
        }

        public static string cod4ReturnGametype(string gametype)
        {
            if (!(gametype == "Free for All"))
            {
                if (gametype == "Team Deathmatch")
                {
                    return "war";
                }
                if (gametype == "Search and Destroy")
                {
                    return "sd";
                }
                if (gametype == "Sabotage")
                {
                    return "sab";
                }
                if (gametype == "Domination")
                {
                    return "dom";
                }
                if (gametype == "Headquaters")
                {
                    return "koth";
                }
                return "dm";
            }
            return "dm";
        }

        public static string cod4ReturnMapname(string map)
        {
            switch (map)
            {
                case "Backlot": return "mp_backlot";
                case "Countdown": return "mp_countdown";
                case "Shipment": return "mp_shipment";
                case "Vacant": return "mp_vacant";
                case "District": return "mp_citystreets";
                case "Overgrown": return "mp_overgrown";
                case "Strike": return "mp_strike";
                case "Crossfire": return "mp_crossfire";
                case "Crash": return "mp_crash";
                case "Showdown": return "mp_showdown";
                case "Downpour": return "mp_farm";
                case "Pipeline": return "mp_pipeline";
                case "Bloc": return "mp_bloc";
                case "Ambush": return "mp_convoy";
                case "Wet Work": return "mp_cargoship";
                case "Bog": return "mp_bog";
            }
            return "mp_convoy";
        }

        private void button179_Click(object sender, EventArgs e)
        {
            cbufCod4("ui_mapname " + cod4ReturnMapname(this.comboBox3.Text));
        }

        private void button173_Click(object sender, EventArgs e)
        {
            cbufCod4("ui_gametype " + cod4ReturnGametype(this.comboBox2.Text));
        }

        void SpoofGamertagcod4(string name)
        {
            ct2.WriteString(0x84C24BBC, name);
        }

        bool cod4Disco = true; public static bool KeepRunning4;
        private void cod4DiscoTag_CheckedChanged(object sender)
        {
            if (this.cod4Disco)
            {
                KeepRunning4 = true;
                Task.Factory.StartNew(delegate
                {
                    while (KeepRunning4)
                    {
                        SpoofGamertagcod4("^1" + this.textBox21.Text);
                        Thread.Sleep(300);
                        Main.XAMSpoofGamertag("^2" + this.textBox21.Text);
                        Thread.Sleep(300);
                        Main.XAMSpoofGamertag("^3" + this.textBox21.Text);
                        Thread.Sleep(300);
                        Main.XAMSpoofGamertag("^4" + this.textBox21.Text);
                        Thread.Sleep(300);
                        Main.XAMSpoofGamertag("^5" + this.textBox21.Text);
                        Thread.Sleep(300);
                        Main.XAMSpoofGamertag("^6" + this.textBox21.Text);
                        Thread.Sleep(300);
                        Main.XAMSpoofGamertag("^7" + this.textBox21.Text);
                        Thread.Sleep(300);
                        Main.XAMSpoofGamertag("^8" + this.textBox21.Text);
                        Thread.Sleep(300);
                        Main.XAMSpoofGamertag(this.textBox21.Text);
                        Thread.Sleep(300);
                    }
                });
                this.cod4Disco = false;
            }
            else
            {
                KeepRunning4 = false;
                this.cod4Disco = true;
            }
        }

        private void button166_Click(object sender, EventArgs e)
        {
            cod4DiscoTag_CheckedChanged(this.textBox21.Text);
        }

        public static string GrabClientsCOD4(int index)
        {
            return Main.GetString(GetPlayerStateCOD4(index) + 0x305c);
        }
        private static uint GetPlayerStateCOD4(int clientindex)
        {
            byte[] memory = Main.GetMemory(GetEntityCOD4(clientindex) + 0x15c, 4);
            Array.Reverse(memory);
            return BitConverter.ToUInt32(memory, 0);
        }
        private static uint GetEntityCOD4(int clientindex)
        {
            return (((uint)(clientindex * 0x278)) + 0x8287CD08);
        }
        void ClientsCOD4()
        {
            listBox11.Items.Add("Client Gamertags");
            listBox11.Items.Add("-------------------------");
            listBox11.Items.Add("-1 = ALL CLIENTS!");
            listBox11.Items.Add(GrabClientsCOD4(0));
            listBox11.Items.Add(GrabClientsCOD4(1));
            listBox11.Items.Add(GrabClientsCOD4(2));
            listBox11.Items.Add(GrabClientsCOD4(3));
            listBox11.Items.Add(GrabClientsCOD4(4));
            listBox11.Items.Add(GrabClientsCOD4(5));
            listBox11.Items.Add(GrabClientsCOD4(6));
            listBox11.Items.Add(GrabClientsCOD4(7));
            listBox11.Items.Add(GrabClientsCOD4(8));
            listBox11.Items.Add(GrabClientsCOD4(9));
            listBox11.Items.Add(GrabClientsCOD4(10));
            listBox11.Items.Add(GrabClientsCOD4(11));
            listBox11.Items.Add(GrabClientsCOD4(12));
            listBox11.Items.Add(GrabClientsCOD4(13));
            listBox11.Items.Add(GrabClientsCOD4(14));
            listBox11.Items.Add(GrabClientsCOD4(15));
            listBox11.Items.Add(GrabClientsCOD4(16));
            listBox11.Items.Add(GrabClientsCOD4(17));
        }

        void ScanCOD4()
        {
            listBox11.Items.Clear();
            Thread.Sleep(1000);
            {
                ClientsCOD4();
            }
        }

        private void button153_Click(object sender, EventArgs e)
        {
            ClientsCOD4();
        }

        private void button162_Click(object sender, EventArgs e)
        {
            ScanCOD4();
        }

        private void button182_Click(object sender, EventArgs e)
        {
            this.cod4Prestige.Text = "0";
            this.cod4Rank.Text = "0";
            this.cod4RankXP.Text = "0";
            this.cod4Score.Text = "0";
            this.cod4Kills.Text = "0";
            this.cod4Deaths.Text = "0";
            this.cod4Killstreak.Text = "0";
            this.cod4Wins.Text = "0";
            this.cod4Losses.Text = "0";
            this.cod4Winstreak.Text = "0";
            this.cod4Headshots.Text = "0";
            this.cod4Hits.Text = "0";
            this.cod4Misses.Text = "0";
            this.cod4Assists.Text = "0";
        }

        public int ConvertRankToXPCOD4(int rank)
        {
            switch (rank)
            {
                case 1:
                    return 0;
                case 2: return 30;
                case 3: return 120;
                case 4: return 270;
                case 5: return 480;
                case 6: return 750;
                case 7: return 0x438;
                case 8: return 0x5be;
                case 9: return 0x780;
                case 10: return 0x97e;
                case 11: return 0xbb8;
                case 12: return 0xe42;
                case 13: return 0x111c;
                case 14: return 0x1446;
                case 15: return 0x17c0;
                case 0x10: return 0x1b8a;
                case 0x11: return 0x1fa4;
                case 0x12: return 0x240e;
                case 0x13: return 0x28c8;
                case 20: return 0x2dd2;
                case 0x15: return 0x332c;
                case 0x16: return 0x38d6;
                case 0x17: return 0x3ed0;
                case 0x18: return 0x451a;
                case 0x19: return 0x4bb4;
                case 0x1a: return 0x529e;
                case 0x1b: return 0x59d8;
                case 0x1c: return 0x6162;
                case 0x1d: return 0x693c;
                case 30: return 0x7166;
                case 0x1f: return 0x7a08;
                case 0x20: return 0x8322;
                case 0x21: return 0x8cb4;
                case 0x22: return 0x96be;
                case 0x23: return 0xa140;
                case 0x24: return 0xac3a;
                case 0x25: return 0xb7ac;
                case 0x26: return 0xc396;
                case 0x27: return 0xcff8;
                case 40: return 0xdcd2;
                case 0x29: return 0xea24;
                case 0x2a: return 0xf7ee;
                case 0x2b: return 0x10630;
                case 0x2c: return 0x114ea;
                case 0x2d: return 0x1241c;
                case 0x2e: return 0x133c6;
                case 0x2f: return 0x143e8;
                case 0x30: return 0x15482;
                case 0x31: return 0x16594;
                case 50: return 0x1771e;
                case 0x33: return 0x18920;
                case 0x34: return 0x19b9a;
                case 0x35: return 0x1ae8c;
                case 0x36: return 0x1c1f6;
                case 0x37: return 0x1e898;
            }
            return 0;
        }

        void Cod4SV_SetClientStat(int clientindex, int statindex, int value)
        {
            object[] objArray1 = new object[] { clientindex, statindex, value };
            ct2.Call<uint>(0x82205C38, objArray1);
        }

        bool allclient;
        int clientindex;
        int time, xp, winstreak, wins, score, rank, prestige, misses, losses, killstreak, kills, hits, headshots, deaths, assists;

        private void button174_Click(object sender, EventArgs e)
        {
            Cod4SetClantag(textBox19.Text);
        }

        void Cod4SetClantag(string clantag)
        {
            cbufCod4("clanName " + clantag);
            cbufCod4("updategamerprofile");
        }

        private void button183_Click(object sender, EventArgs e)
        {
            uint address = 0x84C5F1E0;
            for (int i = 0; i <= 0x44f; i++)
            {
                Main.SetInt(address, -1);
                address += 4;
            }
        }

        private void button181_Click(object sender, EventArgs e)
        {
            cbufCod4("developer 1;developer_script 1");
            Thread.Sleep(100);
            cbufCod4("set scr_game_suicidepointloss 1;set scr_dm_score_suicide 4000");
            cbufCod4("onlinegame 1;xblive_privatematch 0;scr_dm_timelimit 0.1");
            cbufCod4("set activeaction\"scr_dm_timelimit 0;scr_dm_scorelimit 0\"");
        }

        void SpoofXUIDCod4(string gamertag)
        {
            byte[] data = Main.StringToByteArray(Main.GrabXUID(gamertag));
            ct2.WriteString(0x84C24BBC, gamertag);
            ct2.SetMemory(0x82439AF8, data);
            ct2.SetMemory(0x84C24BE0, data);
            ct2.SetMemory(0x84C495A8, data);
            ct2.SetMemory(0x84C49728, data);
        }

        private void button192_Click(object sender, EventArgs e)
        {

        }

        private void button191_Click(object sender, EventArgs e)
        {
            SpoofGamertagCod4(this.textBox23.Text);
        }

        void SpoofGamertagCod4(string name)
        {
            ct2.WriteString(0x84C24BBC, name);
        }

        void OffNameCod4(string gamertag)
        {
            cbufCod4(string.Format(@"userinfo \name\{0}", gamertag));
        }

        private void button189_Click(object sender, EventArgs e)
        {
            OffNameCod4(this.textBox23.Text);
        }

        private void button187_Click(object sender, EventArgs e)
        {
            this.cod4Prestige.Text = "-2,147,483,647";
            this.cod4Rank.Text = "-2,147,483,647";
            this.cod4RankXP.Text = "-2,147,483,647";
            this.cod4Score.Text = "-2,147,483,647";
            this.cod4Kills.Text = "-2,147,483,647";
            this.cod4Deaths.Text = "-2,147,483,647";
            this.cod4Killstreak.Text = "-2,147,483,647";
            this.cod4Wins.Text = "-2,147,483,647";
            this.cod4Losses.Text = "-2,147,483,647";
            this.cod4Winstreak.Text = "-2,147,483,647";
            this.cod4Headshots.Text = "-2,147,483,647";
            this.cod4Hits.Text = "-2,147,483,647";
            this.cod4Misses.Text = "-2,147,483,647";
            this.cod4Assists.Text = "-2,147,483,647";
        }

        private void button186_Click(object sender, EventArgs e)
        {
            this.cod4Prestige.Text = "10";
            this.cod4Rank.Text = "55";
            this.cod4RankXP.Text = "125490";
            this.cod4Score.Text = "7231542";
            this.cod4Kills.Text = "65214";
            this.cod4Deaths.Text = "43521";
            this.cod4Killstreak.Text = "43";
            this.cod4Wins.Text = "2142";
            this.cod4Losses.Text = "17985";
            this.cod4Winstreak.Text = "35";
            this.cod4Headshots.Text = "6543";
            this.cod4Hits.Text = "654237852";
            this.cod4Misses.Text = "1365742654";
            this.cod4Assists.Text = "7621";
        }

        private void button184_Click(object sender, EventArgs e)
        {
            try
            {
                if (!allclient)
                {
                    xp = ConvertRankToXPCOD4(int.Parse(cod4Prestige.Text));
                    ct2.WriteInt32(0x84C5EEC0, xp);
                    assists = int.Parse(cod4Assists.Text);
                    kills = int.Parse(cod4Kills.Text);
                    wins = int.Parse(cod4Wins.Text);
                    killstreak = int.Parse(cod4Killstreak.Text);
                    score = int.Parse(cod4Score.Text);
                    winstreak = int.Parse(cod4Winstreak.Text);
                    hits = int.Parse(cod4Hits.Text);
                    misses = int.Parse(cod4Misses.Text);
                    losses = int.Parse(cod4Losses.Text);
                    headshots = int.Parse(cod4Headshots.Text);
                    deaths = int.Parse(cod4Deaths.Text);
                    prestige = int.Parse(cod4Prestige.Text);
                    ct2.WriteInt32(0x84C5EEFC, wins);
                    ct2.WriteInt32(0x84C5EECC, killstreak);
                    ct2.WriteInt32(0x84C5EEC4, score);
                    ct2.WriteInt32(0x84C5EF08, winstreak);
                    ct2.WriteInt32(0x84C5EF14, hits);
                    ct2.WriteInt32(0x84C5EF18, misses);
                    ct2.WriteInt32(0x84C5EF00, losses);
                    ct2.WriteInt32(0x84C5EEDC, headshots);
                    ct2.WriteInt32(0x84C5EED0, deaths);
                    ct2.WriteInt32(0x84C5EED0, assists);
                    ct2.WriteInt32(0x84C5EEF4, time);
                    ct2.WriteInt32(0x84C5EF24, prestige);
                }
                else
                {
                    xp = ConvertRankToXPCOD4(int.Parse(cod4Prestige.Text));
                    assists = int.Parse(cod4Assists.Text);
                    kills = int.Parse(cod4Kills.Text);
                    wins = int.Parse(cod4Wins.Text);
                    killstreak = int.Parse(cod4Killstreak.Text);
                    score = int.Parse(cod4Score.Text);
                    winstreak = int.Parse(cod4Winstreak.Text);
                    hits = int.Parse(cod4Hits.Text);
                    misses = int.Parse(cod4Misses.Text);
                    losses = int.Parse(cod4Losses.Text);
                    headshots = int.Parse(cod4Headshots.Text);
                    deaths = int.Parse(cod4Deaths.Text);
                    prestige = int.Parse(cod4Prestige.Text);
                    Cod4SV_SetClientStat(clientindex, 0x8fd, xp);
                    Cod4SV_SetClientStat(clientindex, 0x901, rank);
                    Cod4SV_SetClientStat(clientindex, 0x903, assists);
                    Cod4SV_SetClientStat(clientindex, 0x8ff, kills);
                    Cod4SV_SetClientStat(clientindex, 0x90c, wins);
                    Cod4SV_SetClientStat(clientindex, 0x900, killstreak);
                    Cod4SV_SetClientStat(clientindex, 0x8fe, score);
                    Cod4SV_SetClientStat(clientindex, 0x910, winstreak);
                    Cod4SV_SetClientStat(clientindex, 0x912, hits);
                    Cod4SV_SetClientStat(clientindex, 0x913, misses);
                    Cod4SV_SetClientStat(clientindex, 0x90d, losses);
                    Cod4SV_SetClientStat(clientindex, 0x904, headshots);
                    Cod4SV_SetClientStat(clientindex, 0x901, deaths);
                    Cod4SV_SetClientStat(clientindex, 0x916, prestige);
                    Cod4SV_SetClientStat(clientindex, 0x90a, time);
                }
            }
            catch
            {
                MessageBox.Show("ERROR", "Can Only Set Numbers for Stats!");
            }

        }

        public void ChangeTheme(SystemColors scheme, Control.ControlCollection container)
        {
            
            
        }
    }
}
