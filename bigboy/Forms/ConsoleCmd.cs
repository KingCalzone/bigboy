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
using IniParser;
using System.IO;
using security; 

namespace bigboy
{
    public partial class ConsoleCmd : MaterialSkin.Controls.MaterialForm
	{
        public ConsoleCmd()
        {
            InitializeComponent();

			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
		}

		public XDevkit.IXboxConsole ct2;
		public static IXboxConsole XDK;
		string connected = "";
		string disconnected = "";
		private void ConsoleCmd_Load(object sender, EventArgs e)
        {
			security.processes.pulse();
			try
			{
				ct2.Connect(out ct2);
				try
				{
					ct2.ReadString(0x01, 1);
					connected = "true";
					disconnected = "false";
					Kernal.Text = "" + ((XDevkit.IXboxConsole)ct2).GetKernalVersion();
					ConsoleIP.Text = "" + ((XDevkit.IXboxConsole)ct2).XboxIP();
					TitleID.Text = "" + ct2.XamGetCurrentTitleId();
					GameID.Text = "" + ct2.XamGetCurrentTitleId().ToString("X");
					CPU.Text = "" + ct2.GetCPUKey();
					XblStatus.Text = "" + xblcheck();
					Thread.Sleep(100);

					//Shite
					string date = DateTime.Now.ToString("g");
					timeLaunched.Text = date;
					statement.Text = "THIS IS COMPLETELY FREE. > NEVER < \n BUY THIS FROM ANYONE. EVER.";

					//Gamertag stuff
					SignedIn.Text = "Tool launched signed in as: " + Encoding.BigEndianUnicode.GetString(this.ct2.GetMemory(2175412476U, 30U)).Trim().Trim(new char[1]);
					try
					{
					}
					catch (Exception)
					{
					}
				}
				catch
				{
				}
				notifications.consolecommander();
			}
			catch (Exception)
			{
				notifications.disconnected();
			}
		}

		private string check;
		private string xblcheck()
		{
			uint num = this.ct2.Call<uint>(2171219848U, new object[]
			{
				252,
				360451U,
				0,
				0
			});
			if (num == 1380593U)
			{
				this.check = "You are not connected to Xbox Live.";
			}
			else
			{
				this.check = "Connected to Xbox Live.";
			}
			return XblStatus.Text = this.check;
		}

		private void xboxinfo()
        {
			Kernal.Text = "" + ((XDevkit.IXboxConsole)ct2).GetKernalVersion();
			ConsoleIP.Text = "" + ((XDevkit.IXboxConsole)ct2).XboxIP();
			TitleID.Text = "" + ct2.XamGetCurrentTitleId();
			GameID.Text = "" + ct2.XamGetCurrentTitleId().ToString("X");
			CPU.Text = "" + ct2.GetCPUKey();
			XblStatus.Text = "" + xblcheck();
		}

		private void xboxinfothread()
        {
			Thread update = new Thread(xboxinfothread);
			var timer = new System.Timers.Timer(5000);
			timer.Elapsed += (sender, args) => { xboxinfo(); };
			timer.Start();
		}

		private FileIniDataParser parser = new FileIniDataParser();
		private void button117_Click(object sender, EventArgs e)
        {
			try
			{
				ct2.ReceiveFile(AppDomain.CurrentDomain.BaseDirectory + @"\launch.ini", this.hddselector.Text + "launch.ini");
				this.inibox.Items.Clear();
				foreach (SectionData data in this.parser.LoadFile(AppDomain.CurrentDomain.BaseDirectory + @"\launch.ini").Sections)
				{
					this.inibox.Items.Add("[" + data.SectionName + "]");
					foreach (KeyData data2 in data.Keys)
					{
						this.inibox.Items.Add(data2.KeyName + " = " + data2.Value);
					}
				}
				if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\launch-backup.ini"))
				{
					File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\launch-backup.ini");
				}
				File.Move(AppDomain.CurrentDomain.BaseDirectory + @"\launch.ini", AppDomain.CurrentDomain.BaseDirectory + @"\launch-backup.ini");
				MessageBox.Show("Success!", "Succesfully Read the Launch ini\nFile From Console.");
			}
			catch
			{
				MessageBox.Show("ini Error", "Couldn't Grab the ini File from Console.");
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{

		}

		private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

		public uint Connection;
		public string Response;
		private void button444_Click(object sender, EventArgs e)
        {
			this.ct2.SendTextCommand(this.Connection, "dbgname name=" + this.textBox4.Text, out this.Response);
		}

        private void button12_Click(object sender, EventArgs e)
        {
			if (this.icons.SelectedItem.ToString() == "")
            {
				this.ct2.SendTextCommand(this.Connection, "setcolor name=Black", out this.Response);
			}
			if (this.icons.SelectedItem.ToString() == "")
			{
				this.ct2.SendTextCommand(this.Connection, "setcolor name=Blue", out this.Response);

			}
			if (this.icons.SelectedItem.ToString() == "")
			{
				this.ct2.SendTextCommand(this.Connection, "setcolor name=BlueGray", out this.Response);
			}
			if (this.icons.SelectedItem.ToString() == "")
			{
				this.ct2.SendTextCommand(this.Connection, "setcolor name=White", out this.Response);
			}
			if (this.icons.SelectedItem.ToString() == "")
			{
				this.ct2.SendTextCommand(this.Connection, "setcolor name=Xenon", out this.Response);
			}
			if (this.icons.SelectedItem.ToString() == "")
			{
				this.ct2.SendTextCommand(this.Connection, "setcolor name=nosidecar", out this.Response);
			}
		}

        private void button13_Click(object sender, EventArgs e)
        {
			if (this.comboBox1.SelectedItem.ToString() == "Blue")
            {
				Process.Start("https://byrom.uk/tuts/blueneighborhood/");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
			Kernal.Text = "";
			ConsoleIP.Text = "";
			TitleID.Text = "";
			GameID.Text = "";
			CPU.Text = "";
			XblStatus.Text = "";
		}

        private void button20_Click(object sender, EventArgs e)
        {
			Kernal.Text = "13370";
			ConsoleIP.Text = "192.168.1.150";
			TitleID.Text = "NO FUCKING IDEA";
			GameID.Text = "FAGGOT ASS GAME";
			CPU.Text = "NIGGERS'R'US";
			XblStatus.Text = "OWNER";
		}

        private void button21_Click(object sender, EventArgs e)
        {
			xboxinfo();
		}

		int l = 0;
		int ll = 0;
		private void button18_Click(object sender, EventArgs e)
        {
			while (l == 0)
			{
				Process.Start(Environment.CurrentDirectory + "\\LootLoader\\Module Loader.exe");
				l++;
				l++;
				if (l != 0)
				{
					if (ll == 0)
					{
						ll++;
					}
					l--;
				}
			}
		}

        

		int xb = 0;
		int wat = 0;
        private void button22_Click(object sender, EventArgs e)
        {
			while (xb == 0)
			{
				Process.Start("C:\\Program Files (x86)\\Microsoft Xbox 360 SDK\bin\\win32\\xbwatson.exe");
				xb++;
				xb++;
				if (xb != 0)
				{
					if (wat == 0)
					{
						wat++;
					}
					xb--;
				}
			}
		}
		
		private void button23_Click(object sender, EventArgs e)
        {
			
		}
    }
}