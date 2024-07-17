using JRPC_Client;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using XDevkit;
using MaterialSkin;
using PeekPoker.Interface;

using System.Reflection;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Text.RegularExpressions;

using System.Drawing.Imaging;
using System.IO;
using System.Deployment;
using System.Collections.Generic;
using System.ComponentModel;

namespace bigboy
{
	class Main
	{
		public static IXboxConsole XDK;

		public static void goldSpoof()
		{
			XDK.WriteInt32(0x81A3CD60, 0x38600001);
			XDK.WriteInt32(0x816DAC84, 0x38600001);
			XDK.SetMemory(0x816DD470, new byte[] { 0x39, 0x60, 0, 1 });
			XDK.SetMemory(0x816DD4E4, new byte[] { 0x39, 0x60, 0, 1 });
			XDK.SetMemory(0x816DD4DC, new byte[] { 0x39, 0x60, 0, 1 });
			XDK.SetMemory(0x816DD4D0, new byte[] { 0x39, 0x60, 0, 1 });
			updateGoldSpoof();
		}

		public static void updateGoldSpoof()
		{
			Thread update = new Thread(updateGoldSpoof);
			var timer = new System.Timers.Timer(60000);
			timer.Elapsed += (sender, args) => { goldSpoof(); };
			timer.Start();
		}

		public static int Dvar_GetInt(string dvarname)
		{
			return XDK.Call<int>(JRPC.ThreadType.Title, 0x821D1570, new object[] { dvarname });
		}

		public static void SpoofMSP()
		{
			XDK.XNotify("Tool will unfreeze once you have selected the game to purchase!");
			byte[] data = new byte[]
			{
				56,
				128,
				0,
				5,
				128,
				99,
				0,
				28,
				144,
				131,
				0,
				4,
				56,
				128,
				9,
				196,
				144,
				131,
				0,
				8,
				56,
				96,
				0,
				0,
				78,
				128,
				0,
				32
			};
			XDK.GetMemory(1610612736U, 32U);
			XDK.GetMemory(1207959752U, 32U);
			uint num;
			for (num = XDK.Call<uint>("xam.xex", 1102, new object[]
			{
				"Guide.MP.Purchase.xex"
			}); num == 0U; num = XDK.Call<uint>("xam.xex", 1102, new object[]
			{
				"Guide.MP.Purchase.xex"
			}))
			{
			}
			if (num > 0U)
			{
				XDK.SetMemory(2171119352U, data);
				XDK.WriteInt32(2173606884U, 1610612736);
				XDK.WriteInt32(2173625364U, 1207959752);
				XDK.WriteInt32(2417350752U, 1610612736);
				XDK.WriteInt32(2417350948U, 1610612736);
				XDK.XNotify("MSP Spoof Enabled!");
			}
		}

		public static void SetMemory(uint address, byte[] data)
		{
			uint garbage;
			XDK.DebugTarget.SetMemory(address, (uint)data.Length, data, out garbage);
		}

		public static string GetString(uint address)
		{
			byte[] bytes = new byte[0x800];
			int index = 0;
			while (true)
			{
				bytes[index] = GetByte(address);
				if (bytes[index].Equals((byte)0))
				{
					break;
				}
				index++;
				address++;
			}
			return Encoding.UTF8.GetString(bytes);
		}

		public static byte GetByte(uint address)
		{
			return GetMemory(address, 1)[0];
		}

		public static void SetByte(uint address, byte value)
		{
			uint garbage;
			byte[] data = new byte[] { value };
			XDK.DebugTarget.SetMemory(address, 1, data, out garbage);
		}

		public static byte[] GetMemory(uint address, int length)
		{
			uint garbage;
			byte[] data = new byte[length];
			XDK.DebugTarget.GetMemory(address, (uint)length, data, out garbage);
			XDK.DebugTarget.InvalidateMemoryCache(true, address, (uint)length);
			return data;
		}

		public static void NOP(uint address)
		{
			byte[] buffer1 = new byte[4];
			buffer1[0] = 0x60;
			byte[] data = buffer1;
			XDK.SetMemory(address, data);
		}

		public static int GetInt(uint address)
		{
			byte[] memory = GetMemory(address, 4);
			Array.Reverse(memory);
			return BitConverter.ToInt32(memory, 0);
		}

		public static byte[] WideChar(string text)
		{
			byte[] buffer = new byte[(text.Length * 2) + 2];
			int index = 1;
			buffer[0] = 0;
			foreach (char ch in text)
			{
				buffer[index] = Convert.ToByte(ch);
				index += 2;
			}
			return buffer;
		}

		public static bool IsDevkit = false;
		public static void XAMSpoofGamertag(string gamertag)
		{
			try
			{
				XDK.SetMemory(IsDevkit ? 0x81D44B74 : 0x81AA261C, WideChar(gamertag));
			}
			catch (Exception exception1)
			{
				MessageBox.Show(exception1.ToString());
			}
		}

		public static byte[] ipToBuffer(string ip)
		{
			int count = 0;
			string ip1 = "0";
			string ip2 = "0";
			string ip3 = "0";
			string ip4 = "0";
			foreach (string num in ip.Split('.').ToArray())
			{
				switch (count)
				{
					case 0: { ip1 = num; break; }
					case 1: { ip2 = num; break; }
					case 2: { ip3 = num; break; }
					case 3: { ip4 = num; break; }
				}
				count++;
			}
			return new byte[] { Convert.ToByte(ip1), Convert.ToByte(ip2), Convert.ToByte(ip3), Convert.ToByte(ip4) };
		}

		public static uint addr = 0xc24313e0;
		public static async void spoofIP(string ip)
		{
			await Task.Delay(0);
			if (XDK.Connect(out XDK))
			{
				XDK.WriteByte(addr, ipToBuffer(ip));
			}
			else
			{
				MessageBox.Show("Please confirm you are connected to your console and you have JRPC as a plugin.", "Failed to talk to console.", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public static bool isConsoleConnected()
		{
			try
			{
				XDK.ReadString(0x01, 1);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static void SetInt(uint address, int value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			Array.Reverse(bytes);
			XDK.SetMemory(address, bytes);
		}

		public static byte[] spoofXUID(string yuh)
		{
			byte[] buffer = new byte[(yuh.Length * 2) + 2];
			int index = 1;
			buffer[0] = 0;
			foreach (char ch in yuh)
			{
				buffer[index] = Convert.ToByte(ch);
				index += 2;
			}
			return buffer;
		}

		public static void screenshot()
        {
			string image = Application.StartupPath + "\\ct2Screenshot.bmp";
			if (!System.IO.Directory.Exists(Application.StartupPath + "\\Screenshots"))
			System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Screenshots");
			XDK.ScreenShot(image);
			System.Diagnostics.Process.Start(Application.StartupPath + "\\ct2screenshot.bmp");
		}

		public static string GrabXUID(string gamertag)
		{
			try
			{
				uint address = IsDevkit ? 0x81D43E40 : 0x81AA18F0;
				byte[] data = new byte[8];
				XDK.SetMemory(address, data);
				XeXUIDLookup(gamertag, address);
				Thread.Sleep(0x3e8);
				XDK.SetMemory(address, data);
				return BitConverter.ToString(GetMemory(address, 8)).Replace("-", "");
			}
			catch (Exception exception1)
			{
				MessageBox.Show(exception1.ToString());
				return string.Empty;
			}
		}

		private static int XeXUIDLookup(string gamertag, uint offset)
		{
			return XDK.Call<int>(JRPC.ThreadType.Title, IsDevkit ? 0x819CD630 : 0x81829158, new object[] { 0x9000006f93463L, 0, gamertag, 0x18, offset, 0 });
		}

		public static byte[] StringToByteArray(string HexString)
		{
			int NumberChars = HexString.Length;
			byte[] bytes = new byte[NumberChars / 2];
			for (int i = 0; i < NumberChars; i += 2)
			{
				bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
			}
			return bytes;
		}

		public static void gamebeingplayed()
		{
			if (XDK.XamGetCurrentTitleId().ToString() == "415607e6") // COD 4
			{
				int co = 0;
				int d4 = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing Cod 4, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
			if (XDK.XamGetCurrentTitleId().ToString() == "4156081c") // COD WAW
			{
				int wa = 0;
				int w = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing WAW, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
			if (XDK.XamGetCurrentTitleId().ToString() == "41560817") // COD MW2
			{
				int ok = 0;
				int ok2 = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing MW2, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
			if (XDK.XamGetCurrentTitleId().ToString() == "415608cb") // COD MW3
			{
				int one = 0;
				int two = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing MW3, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
			if (XDK.XamGetCurrentTitleId().ToString() == "41560855") // COD BO1
			{
				int three = 0;
				int four = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing BO1, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
			if (XDK.XamGetCurrentTitleId().ToString() == "415608c3") // COD BO2
			{
				int five = 0;
				int six = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing BO2, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
			if (XDK.XamGetCurrentTitleId().ToString() == "4156091d") // COD BO3
			{
				int bl = 0;
				int o3 = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing BO3, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
			if (XDK.XamGetCurrentTitleId().ToString() == "415608fc") // COD GHOSTS
			{
				int gh = 0;
				int os = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing Cod Ghosts, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
			if (XDK.XamGetCurrentTitleId().ToString() == "41560914") // COD ADVANCED WARFARE
			{
				int a = 0;
				int war = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing Cod Advanced Warfare, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
			if (XDK.XamGetCurrentTitleId().ToString() == "454109ba") // BF4
			{
				int battle = 0;
				int field = 0;
				DialogResult dialogResult = MessageBox.Show("You are playing Battlefield 4, do you want to load the mod page?", "Game detected", MessageBoxButtons.YesNo);
				bool A = dialogResult == DialogResult.Yes;
				bool B = dialogResult == DialogResult.No;
				if (A)
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
				if (B)
				{

				}
			}
		}
	}

	class PC
	{
		public static void killtool()
        {
			string get = Process.GetCurrentProcess().ProcessName.ToString();
			foreach (Process p in Process.GetProcessesByName(get))
			{
				p.CloseMainWindow();
				p.Kill();
			}
        }

		public static void restarttool()
		{
			string get = Process.GetCurrentProcess().ProcessName.ToString();
			foreach (Process p in Process.GetProcessesByName(get))
			{
				Process.Start(Environment.CurrentDirectory + "\\bigboy.exe");
				p.CloseMainWindow();
				p.Kill();
			}
		}

		public static string SpacePlus(string input)
		{
			return input.Replace(" ", "+");
		}
	}

	class notifications
    {
		public static void connected()
        {
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.Green;
			popup.TitleText = "                                 (✓) Successfully connected (✓)";
			popup.ContentColor = Color.Black;
			popup.ContentText = "                               Fuck yeeeah, lets do some shit! >:D";
			popup.Popup();// show 
		}

		public static void disconnected()
        {
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.Red;
			popup.TitleText = "                                 (X) Connection failed! (X)";
			popup.ContentColor = Color.Black;
			popup.ContentText = "Please make sure you have JRPC2.xex as a plugin and your console is set to default in Xbox 360 Neighborhood! :(";
			popup.Popup();// show 
		}

		public static void tcb()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "										Hello, welcome to TCB!";
			popup.ContentColor = Color.Black;
			popup.ContentText = "Here you can download several things\nfree of charge, you are welcome ;)";
			popup.Popup();// show 
		}

		public static void discord()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Discord Servers";
			popup.ContentColor = Color.Black;
			popup.ContentText = "Here you can find different discord servers for different means, open Discords app before joining.";
			popup.Popup();// show 
		}

		public static void xpg()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											XPGameSaves";
			popup.ContentColor = Color.Black;
			popup.ContentText = "";
			popup.Popup();// show 
		}

		public static void aw()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											XPGameSaves";
			popup.ContentColor = Color.Black;
			popup.ContentText = "";
			popup.Popup();// show 
		}

		public static void battlefield()
        {
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "									[!] Successfully connected";
			popup.ContentColor = Color.Black;
			popup.ContentText = "\nFuck yeeeah, lets mod some Battlefield! >:D\n \n THIS IS NOT TESTED BY THE WAY LMAO";
			popup.Popup();// show
		}

		public static void bo1()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Black Ops 1";
			popup.ContentColor = Color.Black;
			popup.ContentText = "\nFuck yeeeah, lets mod some Black ops! >:D";
			popup.Popup();// show 
		}

		public static void bo2()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Black Ops 2";
			popup.ContentColor = Color.Black;
			popup.ContentText = "\nFuck yeeeah, lets mod some Black ops 2! >:D";
			popup.Popup();// show 
		}

		public static void bo3()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Black Ops 3";
			popup.ContentColor = Color.Black;
			popup.ContentText = "\nFuck yeeeah, lets mod some Black ops 3! >:D";
			popup.Popup();// show 
		}

		public static void cod4()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Modern Warfare[Cod4]";
			popup.ContentColor = Color.Black;
			popup.ContentText = "\nFuck yeeeah, lets mod some Cod4! >:D";
			popup.Popup();// show 
		}

		public static void waw()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											World At War";
			popup.ContentColor = Color.Black;
			popup.ContentText = "\nFuck yeeeah, lets mod some waw! >:D";
			popup.Popup();// show 
		}

		public static void consolecommander()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Console Commander";
			popup.ContentColor = Color.Black;
			popup.ContentText = "Here is a rebuild of one of my tools with (most) of its features also being in this tool, just not here!";
			popup.Popup();// show 
		}

		public static void ghosts()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Ghosts";
			popup.ContentColor = Color.Black;
			popup.ContentText = "\nFuck yeeeah, lets mod some Ghosts! >:D\nWait - do people even play this?";
			popup.Popup();// show 
		}

		public static void mw2()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Modern Warfare 2";
			popup.ContentColor = Color.Black;
			popup.ContentText = "Fuck yeeeah, lets mod some MW2! >:D\nBest game by far, if you didn't know.";
			popup.Popup();// show 
		}

		public static void mw3()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 5000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Modern Warfare 3";
			popup.ContentColor = Color.Black;
			popup.ContentText = "Fuck yeeeah, lets mod some MW3! >:D";
			popup.Popup();// show 
		}

		public static void trainers()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 3000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Trainers";
			popup.ContentColor = Color.Black;
			popup.ContentText = "\nAs you can see, i worked very hard on this one...";
			popup.Popup();// show 
		}

		public static void xbla()
		{
			PopupNotifier popup = new PopupNotifier();
			popup.AnimationDuration = 3000;
			popup.TitleColor = Color.DarkSlateGray;
			popup.TitleText = "											Xbox Live Arcade";
			popup.ContentColor = Color.Black;
			popup.ContentText = "\nI am not entirely sure yet...";
			popup.Popup();// show 
		}
	}

	class Themes
	{
		public static void light()
		{
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Yellow500, Primary.Grey900, Primary.Yellow500, Accent.Yellow400, TextShade.BLACK);
		}

		public static void dark()
		{
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Grey900, Accent.DeepPurple700, TextShade.WHITE);
		}

		public static void grey()
		{
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey700, Primary.Grey900, Primary.Grey700, Accent.Purple700, TextShade.WHITE);
		}

		public static void blue()
		{
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Blue500, Primary.Blue500, Accent.DeepPurple700, TextShade.WHITE);
		}

		public static void green()
		{
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green500, Primary.Green500, Accent.DeepPurple700, TextShade.WHITE);
		}

		public static void red()
		{
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.Red500, Primary.Red500, Accent.DeepPurple700, TextShade.WHITE);
		}

		public static void yellow()
		{
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Yellow500, Primary.Yellow500, Primary.Yellow500, Accent.DeepPurple700, TextShade.WHITE);
		}

		public static void purple()
		{
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple500, Primary.Purple500, Primary.Purple500, Accent.DeepPurple700, TextShade.WHITE);
		}

		public static void original()
        {
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
		}
	}
}
