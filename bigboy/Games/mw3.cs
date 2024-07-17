using System;
using System.Diagnostics;
using System.Drawing;
using JRPC_Client;
using MaterialSkin;
using System.Reflection;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using XDevkit;
using security;

namespace bigboy
{
    public partial class mw3 : MaterialSkin.Controls.MaterialForm
	{
        public mw3()
        {
            InitializeComponent();

			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
			security.processes.pulse();
		}

        public XDevkit.IXboxConsole ct2;
        public static IXboxConsole XDK;
        private void mw3_Load(object sender, EventArgs e)
        {
			try
            {
				bool connected = ct2.Connect(out ct2, "default");
				if (connected)
				{
					//notifications.mw3();
					label11.ForeColor = Color.White;
					label11.Text = "Status:";
					label10.ForeColor = Color.Green;
					label10.Text = "Connected";
				}
				else
				{
					//notifications.disconnected();
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

		void CbufMW3(string command)
		{
			ct2.CallVoid(0x82287EE0, new object[] { 0, command });
		}

		uint GetEntity(int clientindex)
		{
			return (((uint)(clientindex * 640)) + 0x82DCCC80);
		}

		uint GetPlayerStateMW3(int clientindex)
		{
			byte[] memory = Main.GetMemory(GetEntity(clientindex) + 0x158, 4);
			Array.Reverse(memory);
			return BitConverter.ToUInt32(memory, 0);
		}

		string GrabClientsMW3(int clientindex)
		{
			return Main.GetString(GetPlayerStateMW3(clientindex) + 0x3414);
		}

		void ClientsMW3()
		{
			listBox2.Items.Add("Client Gamertags");
			listBox2.Items.Add("-------------------------");
			listBox2.Items.Add("-1 = ALL CLIENTS!");
			listBox2.Items.Add(GrabClientsMW3(0));
			listBox2.Items.Add(GrabClientsMW3(1));
			listBox2.Items.Add(GrabClientsMW3(2));
			listBox2.Items.Add(GrabClientsMW3(3));
			listBox2.Items.Add(GrabClientsMW3(4));
			listBox2.Items.Add(GrabClientsMW3(5));
			listBox2.Items.Add(GrabClientsMW3(6));
			listBox2.Items.Add(GrabClientsMW3(7));
			listBox2.Items.Add(GrabClientsMW3(8));
			listBox2.Items.Add(GrabClientsMW3(9));
			listBox2.Items.Add(GrabClientsMW3(10));
			listBox2.Items.Add(GrabClientsMW3(11));
			listBox2.Items.Add(GrabClientsMW3(12));
			listBox2.Items.Add(GrabClientsMW3(13));
			listBox2.Items.Add(GrabClientsMW3(14));
			listBox2.Items.Add(GrabClientsMW3(15));
			listBox2.Items.Add(GrabClientsMW3(16));
			listBox2.Items.Add(GrabClientsMW3(17));
		}

		void scanMW3()
		{
			listBox2.Items.Clear();
			Thread.Sleep(1000);
			{
				listBox2.Items.Add("Client Gamertags");
				listBox2.Items.Add("-------------------------");
				listBox2.Items.Add("-1 = ALL CLIENTS!");
				listBox2.Items.Add(GrabClientsMW3(0));
				listBox2.Items.Add(GrabClientsMW3(1));
				listBox2.Items.Add(GrabClientsMW3(2));
				listBox2.Items.Add(GrabClientsMW3(3));
				listBox2.Items.Add(GrabClientsMW3(4));
				listBox2.Items.Add(GrabClientsMW3(5));
				listBox2.Items.Add(GrabClientsMW3(6));
				listBox2.Items.Add(GrabClientsMW3(7));
				listBox2.Items.Add(GrabClientsMW3(8));
				listBox2.Items.Add(GrabClientsMW3(9));
				listBox2.Items.Add(GrabClientsMW3(10));
				listBox2.Items.Add(GrabClientsMW3(11));
				listBox2.Items.Add(GrabClientsMW3(12));
				listBox2.Items.Add(GrabClientsMW3(13));
				listBox2.Items.Add(GrabClientsMW3(14));
				listBox2.Items.Add(GrabClientsMW3(15));
				listBox2.Items.Add(GrabClientsMW3(16));
				listBox2.Items.Add(GrabClientsMW3(17));
			}
		}

		void SetInt(uint address, int value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			Array.Reverse(bytes);
			Main.SetMemory(address, bytes);
		}

		void SendStats()
		{
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(this.mw3Prestige.Text));
			ct2.SetMemory(0x830A6D6C, bytes);
			byte[] data = BitConverter.GetBytes(Convert.ToInt32(this.mw3Tokens.Text));
			ct2.SetMemory(0x830A8BCB, data);
			SetInt(0x830a6b5c, 0x1aa518);
			byte[] buffer3 = BitConverter.GetBytes(Convert.ToInt32(this.mw3Wins.Text));
			ct2.SetMemory(0x830A6DD0, buffer3);
			byte[] buffer4 = BitConverter.GetBytes(Convert.ToInt32(this.mw3Losses.Text));
			ct2.SetMemory(0x830A6DD4, buffer4);
			byte[] buffer5 = BitConverter.GetBytes(Convert.ToInt32(this.mw3Kills.Text));
			ct2.SetMemory(0x830A6DD8, buffer5);
			byte[] buffer7 = BitConverter.GetBytes(Convert.ToInt32(this.mw3Score.Text));
			ct2.SetMemory(0x830A6D74, buffer7);
			byte[] buffer8 = BitConverter.GetBytes(Convert.ToInt32(this.mw3Kills.Text));
			ct2.SetMemory(0x830A6DD8, buffer8);
			byte[] buffer9 = BitConverter.GetBytes(Convert.ToInt32(this.mw3Deaths.Text));
			ct2.SetMemory(0x830A6DA4, buffer9);
			byte[] buffer10 = BitConverter.GetBytes(Convert.ToInt32(this.mw3Assists.Text));
			ct2.SetMemory(0x830A6DAC, buffer10);
			byte[] buffer11 = BitConverter.GetBytes(Convert.ToInt32(this.mw3Headshots.Text));
			ct2.SetMemory(0x830A6DB0, buffer11);
			byte[] buffer12 = BitConverter.GetBytes(Convert.ToInt32(this.mw3Killstreak.Text));
			ct2.SetMemory(0x830A6DA0, buffer12);
		}

		void ClearBoxes()
		{
			mw3Prestige.Text = "";
			mw3Tokens.Text = "";
			mw3Wins.Text = "";
			mw3Losses.Text = "";
			mw3Kills.Text = "";
			mw3Score.Text = "";
			mw3Deaths.Text = "";
			mw3Assists.Text = "";
			mw3Headshots.Text = "";
			mw3Killstreak.Text = "";
		}
		void ZeroStats()
		{
			mw3Prestige.Text = "0";
			mw3Tokens.Text = "0";
			mw3Wins.Text = "0";
			mw3Losses.Text = "0";
			mw3Kills.Text = "0";
			mw3Score.Text = "0";
			mw3Deaths.Text = "0";
			mw3Assists.Text = "0";
			mw3Headshots.Text = "0";
			mw3Killstreak.Text = "0";
		}

		public void _3DName(String str1, String str2)
		{
			Byte[] threedee = Encoding.ASCII.GetBytes(str1 + " " + str2 + "\0");
			threedee[str1.Length] = 0xD;
			ct2.SetMemory(0x839691AC, threedee);
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		private void button102_Click(object sender, EventArgs e)
        {
            if (checkBox14.Checked == false)
            {
                ct2.SetMemory(0x821614D4, new byte[] { 0x60, 00, 00, 00 });
                checkBox14.Checked = true;
            }
            else
            {
                ct2.SetMemory(0x821614D4, new byte[] { 75, 250, 3, 149 });
                checkBox14.Checked = false;
            }
        }

        private void button103_Click(object sender, EventArgs e)
        {
            if (checkBox30.Checked == false)
            {
                byte[] buffer = new byte[4];
                buffer[0] = 0x60;
                ct2.SetMemory(0x821154a4, buffer);
                checkBox30.Checked = true;
            }
            else
            {
                ct2.SetMemory(0x821154a4, new byte[] { 0x41, 0x9a, 0, 12 });
                checkBox30.Checked = false;
            }
        }

        private void button106_Click(object sender, EventArgs e)
        {
            if (checkBox33.Checked == false)
            {
                ct2.WriteByte(0x82135107, new byte[] { 15 });
                checkBox33.Checked = true;
            }
            else
            {
                ct2.WriteByte(0x82135107, new byte[] { 4 });
                checkBox33.Checked = false;
            }
        }

        private void button104_Click(object sender, EventArgs e)
        {
            if (checkBox31.Checked == false)
            {
                ct2.SetMemory(0x8210E58C, new byte[] { 0x3b, 0x80, 0, 1 });
                checkBox31.Checked = true;
            }
            else
            {
                ct2.SetMemory(0x8210E58C, new byte[] { 0x55, 0x7c, 0x87, 0xfe });
                checkBox31.Checked = false;
            }
        }

        private void button110_Click(object sender, EventArgs e)
        {
            if (checkBox34.Checked == false)
            {
                byte[] data = new byte[4];
                data[0] = 0x80;
                data[1] = 0x70;
                ct2.SetMemory(0x82000B68, data);
                checkBox34.Checked = true;
            }
            else
            {
                byte[] data = new byte[4];
                data[0] = 0x43;
                data[1] = 0x70;
                ct2.SetMemory(0x82000B68, data);
                checkBox34.Checked = false;
            }
        }

        private void button205_Click(object sender, EventArgs e)
        {
            if (checkBox55.Checked == false)
            {
                byte[] data = new byte[4];
                data[0] = 0x48;
                data[3] = 0xc0;
                ct2.SetMemory(0x823BC98C, data);
                byte[] buffer2 = new byte[4];
                buffer2[0] = 0x48;
                buffer2[3] = 0x68;
                ct2.SetMemory(0x8219A500, buffer2);
                checkBox55.Checked = true;
                ct2.XNotify("Cannot untoggle...");
            }
            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CbufMW3("xpartygo");
        }

        private void button363_Click(object sender, EventArgs e)
        {
            CbufMW3("fast_restart");
        }

        private void button364_Click(object sender, EventArgs e)
        {

        }

		private void button163_Click(object sender, EventArgs e)
        {
			SendStats();
        }

        private void button164_Click(object sender, EventArgs e)
        {
			ClearBoxes();
        }

		private void button175_Click(object sender, EventArgs e)
        {
            unlocks.UnlockAllMW3();
        }

		private void button165_Click(object sender, EventArgs e)
        {
			ZeroStats();
			Thread.Sleep(1000);
			{
				SendStats();
			}
		}

        private void button169_Click(object sender, EventArgs e)
        {
			this.mw3Prestige.Text = "20";
			this.mw3Tokens.Text = "69";
			this.mw3Score.Text = "6542131";
			this.mw3Wins.Text = "2341";
			this.mw3Losses.Text = "1337";
			this.mw3Headshots.Text = "7521";
			this.mw3Kills.Text = "153176";
			this.mw3Deaths.Text = "92415";
			this.mw3Killstreak.Text = "51";
			this.mw3Assists.Text = "12526";
			SendStats();
		}

        private void button170_Click(object sender, EventArgs e)
        {
			this.mw3Prestige.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			
			//this.mw3Prestige.Text = Math.Pow(69, 201).ToString();
			
			this.mw3Tokens.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			this.mw3Score.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			this.mw3Wins.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			this.mw3Losses.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			this.mw3Headshots.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			this.mw3Kills.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			this.mw3Deaths.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			this.mw3Killstreak.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			this.mw3Assists.Text = ((((("" + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue + byte.MaxValue * byte.MaxValue) + byte.MaxValue.ToString()));
			SendStats();
		}

        private void button190_Click(object sender, EventArgs e)
        {
			byte[] data = new byte[] { 10 };
			ct2.SetMemory(0x830A8BD3, data);
		}

        private void button193_Click(object sender, EventArgs e)
        {
			byte[] data = new byte[] { 0xff };
			ct2.SetMemory(0x830A8BDC, data);
		}

		private void button194_Click(object sender, EventArgs e)
        {
			threedeeone.Text = "94, 1, 61, 61, 63, 61, 72, 64, 69, 63, 6f, 6e, 5f, 77, 65, 65, 64,";
			threedeetwo.Text = "5E, 32, 94, 1, 61, 61, 63, 61, 72, 64, 69, 63, 6f, 6e, 5f, 77, 65, 65, 64,";
			_3DName(threedeeone.Text, threedeetwo.Text);
		}

        private void button107_Click(object sender, EventArgs e)
        {
			ct2.SetMemory(0x830A70F3, new byte[] { 1, 90, 0, 0x11, 0, 0, 0, 5 });
		}

        private void button108_Click(object sender, EventArgs e)
        {
			ct2.SetMemory(0x830a70d0, new byte[]
			{   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0x01, 0x28, 0, 0x09, 0, 0, 0, 0, 0, 0x23, 0, 0, 0,
				0x0e, 0, 0x11, 0, 0x09, 0, 0x0d, 0, 0x39, 0, 0, 0, 0x65, 0, 0x0f, 0,
				0x11, 0, 0x08, 0, 0, 0, 0x61, 0, 0x4c, 0, 0, 0, 0x54, 0x77, 0x69, 0x6e,
				0x6b, 0x79, 0x20, 0x5e, 0x32, 0x47, 0x6f, 0x64, 0x6d, 0x6f, 0x64, 0x65, 0, 0, 0, 0, 0, 0x76, 0, 0x20, 0, 0x20, 0, 0x20, 0, 0x13, 0, 0x14, 0, 0x19, 0, 0x2d,
				0, 0x26, 0, 0x27, 0, 0x02, 0, 0, 0, 0x04, 0, 0, 0, 0x06, 0, 0x6b,
				0, 0, 0, 0, 0, 0x01, 0x28, 0, 0x09, 0, 0, 0, 0, 0, 0x23, 0,
				0, 0, 0x0a, 0, 0x11, 0, 0x09, 0, 0x0d, 0, 0x39, 0, 0, 0, 0x6a, 0,
				0x0f, 0, 0x11, 0, 0x08, 0, 0, 0, 0x61, 0, 0x4c, 0, 0, 0, 0x4d, 0x72,
				0x4d, 0x6f, 0x64, 0x56, 0x20, 0x5e, 0x32, 0x47, 0x6f, 0x64, 0x6d, 0x6f, 0x64, 0x65, 0, 0,0, 0, 0, 0x76, 0, 0x20, 0, 0x20, 0, 0x20, 0, 0x13, 0, 0x14, 0, 0x19,
				0, 0x2d, 0, 0x26, 0, 0x27, 0, 0x02, 0, 0, 0, 0x04, 0, 0, 0, 0x06,
				0, 0x6b, 0, 0, 0, 0, 0, 0x01, 0x28, 0, 0x09, 0, 0, 0, 0, 0,
				0x23, 0, 0, 0, 0x07, 0, 0x09, 0, 0x11, 0, 0x0a, 0, 0x39, 0, 0, 0,
				0x6c, 0, 0x0f, 0, 0x11, 0, 0x08, 0, 0, 0, 0x61, 0, 0x4c, 0, 0, 0,
				0x54, 0x77, 0x69, 0x6e, 0x6b, 0x79, 0x20, 0x5e, 0x32, 0x47, 0x6f, 0x64, 0x6d, 0x6f, 0x64, 0x65
			});
		}

        private void button109_Click(object sender, EventArgs e)
        {
			ct2.WriteString(0x830A711C, "^1Custom Class 1");
			ct2.WriteString(0x830A717E, "^1Custom Class 2");
			ct2.WriteString(0x830A71E0, "^1Custom Class 3");
			ct2.WriteString(0x830A7242, "^1Custom Class 4");
			ct2.WriteString(0x830A72A4, "^1Custom Class 5");
			ct2.WriteString(0x830A7306, "^1Custom Class 6");
			ct2.WriteString(0x830A7368, "^1Custom Class 7");
			ct2.WriteString(0x830A73CA, "^1Custom Class 8");
			ct2.WriteString(0x830A742C, "^1Custom Class 9");
			ct2.WriteString(0x830A748E, "^1Custom Class 10");
		}

        private void button365_Click(object sender, EventArgs e)
        {
			ct2.WriteByte(0x82718A37, 1);
		}

        private void button366_Click(object sender, EventArgs e)
        {
			ct2.WriteByte(0x82718a38, 0x01);
		}

        private void button367_Click(object sender, EventArgs e)
        {
			ct2.WriteByte(0x82718a38, 0xFF);
		}

        private void button111_Click(object sender, EventArgs e)
        {
			ClientsMW3();
		}

		private void button150_Click(object sender, EventArgs e)
        {
			scanMW3();
        }
	}
}
