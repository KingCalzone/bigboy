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
    public partial class Battlefield : MaterialSkin.Controls.MaterialForm
	{
        public Battlefield()
        {
            InitializeComponent();

			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
		}

		public XDevkit.IXboxConsole ct2;
		public static IXboxConsole XDK;
		private void Battlefield_Load(object sender, EventArgs e)
        {
			security.processes.pulse();
			try
			{
				bool connected = ct2.Connect(out ct2, "default");
				if (connected)
				{
					notifications.battlefield();
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

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		private void AAWalls(object sender, EventArgs e)
        {
			if (checkBox105.Checked == false)
			{
				this.ct2.SetMemory(0x836D7C34, new byte[]
				{
					237,
					64,
					0,
					50
				});
				this.ct2.SetMemory(0x836D7C38, new byte[]
				{
					237,
					32,
					0,
					50
				});
				checkBox105.Checked = true;
			}
			else
			{
				this.ct2.SetMemory(0x836D7C60, new byte[]
				{
					64,
					152,
					0,
					12
				});
				this.ct2.SetMemory(0x836D7C34, new byte[]
				{
					237,
					64,
					2,
					50
				});
				this.ct2.SetMemory(0x836D7C38, new byte[]
				{
					237,
					44,
					2,
					50
				});
				checkBox105.Checked = false;
			}
		}

        private void spreadrecoil(object sender, EventArgs e)
        {
			if (checkBox106.Checked == false)
			{
				uint address = 0x836FDAC8;
				byte[] array = new byte[4];
				array[0] = 96;
				ct2.SetMemory(address, array);
				checkBox106.Checked = true;
			}
			else
			{
				ct2.SetMemory(0x836FDAC8, new byte[]
				{
					78,
					128,
					4,
					33
				});
				checkBox106.Checked = false;
			}
		}

        private void nosway(object sender, EventArgs e)
        {
			if (checkBox108.Checked == false)
			{
				uint address = 0x832291E0;
				byte[] array = new byte[4];
				array[0] = 96;
				ct2.SetMemory(address, array);
				checkBox108.Checked = true;
			}
			else
			{
				ct2.SetMemory(0x832291E0, new byte[]
				{
					65,
					154,
					0,
					40
				});
				checkBox108.Checked = false;
			}
		}

        private void wallhack(object sender, EventArgs e)
        {
			if (checkBox109.Checked == false)
			{
				uint address = 0x831F7430;
				byte[] array = new byte[4];
				array[0] = 96;
				ct2.SetMemory(address, array);
				checkBox109.Checked = true;
			}
			else
			{
				ct2.SetMemory(0x831F7430, new byte[]
				{
					72,
					11,
					156,
					129
				});
				checkBox109.Checked = false;
			}
		}

        private void tags(object sender, EventArgs e)
        {
			if (checkBox107.Checked == false)
			{
				uint address = 0x83505268;
				byte[] array = new byte[4];
				array[0] = 96;
				ct2.SetMemory(address, array);

				uint address2 = 0x833E02A8;
				array = new byte[4];
				array[0] = 57;
				array[1] = 96;
				ct2.SetMemory(address2, array);

				uint address3 = 0x835054C0;
				array = new byte[4];
				array[0] = 96;
				ct2.SetMemory(address3, array);
				this.ct2.SetMemory(0x835054FC, new byte[]
				{
					72,
					0,
					0,
					60
				});
				checkBox107.Checked = true;
			}
			else
			{
				this.ct2.SetMemory(0x83505268, new byte[]
				{
					64,
					154,
					13,
					164
				});
				this.ct2.SetMemory(0x833E02A8, new byte[]
				{
					57,
					96,
					0,
					1
				});
				this.ct2.SetMemory(0x835054C0, new byte[]
				{
					65,
					154,
					11,
					56
				});
				this.ct2.SetMemory(0x835054FC, new byte[]
				{
					65,
					154,
					0,
					60
				});
				checkBox107.Checked = false;
			}
		}

        private void esp(object sender, EventArgs e)
        {
			if (checkBox110.Checked == false)
			{
				uint address = 0x83505268;
				byte[] array = new byte[4];
				array[0] = 96;
				ct2.SetMemory(address, array);
				uint address2 = 0x835054C0;
				array = new byte[4];
				array[0] = 96;
				ct2.SetMemory(address2, array);
				this.ct2.SetMemory(0x835054FC, new byte[]
				{
					72,
					0,
					0,
					60
				});
				this.ct2.SetMemory(0x835056B0, new byte[]
				{
					75,
					209,
					254,
					89
				});
				this.ct2.SetMemory(0x83225508, new byte[]
				{
					125,
					136,
					2,
					166
				});
				this.ct2.SetMemory(0x8322550C, new byte[]
				{
					47,
					28,
					0,
					2
				});
				this.ct2.SetMemory(0x83225510, new byte[]
				{
					65,
					152,
					0,
					16
				});
				this.ct2.SetMemory(0x83225514, new byte[]
				{
					59,
					224,
					0,
					95
				});
				this.ct2.SetMemory(0x83225518, new byte[]
				{
					125,
					136,
					3,
					166
				});
				this.ct2.SetMemory(0x8322551C, new byte[]
				{
					78,
					128,
					0,
					32
				});
				this.ct2.SetMemory(0x83225520, new byte[]
				{
					59,
					224,
					0,
					18
				});
				this.ct2.SetMemory(0x83225524, new byte[]
				{
					125,
					136,
					3,
					166
				});
				this.ct2.SetMemory(0x83225528, new byte[]
				{
					78,
					128,
					0,
					32
				});
				this.ct2.SetMemory(0x83504BB4, new byte[]
				{
					65,
					154,
					0,
					16
				});
				checkBox110.Checked = true;
			}
			else
			{
				this.ct2.SetMemory(0x83504BB4, new byte[]
				{
					65,
					154,
					0,
					40
				});
				this.ct2.SetMemory(0x835056B0, new byte[]
				{
					59,
					224,
					0,
					151
				});
				checkBox110.Checked = false;
			}
		}

        private void maxdamage(object sender, EventArgs e)
        {
			if (checkBox111.Checked == false)
			{
				uint address = 0x836D7C60;
				byte[] array = new byte[4];
				array[0] = 96;
				ct2.SetMemory(address, array);
				checkBox111.Checked = true;
			}
			else
			{
				this.ct2.SetMemory(0x836D7C60, new byte[]
				{
					64,
					152,
					0,
					12
				});
				checkBox111.Checked = false;
			}
		}

        private void enablemap(object sender, EventArgs e)
        {
			if (checkBox112.Checked == false)
			{
				this.ct2.SetMemory(0x834FB424, new byte[]
				{
					57,
					96,
					0,
					1
				});
				this.ct2.SetMemory(0x834FB3D0, new byte[]
				{
					57,
					96,
					0,
					1
				});
				checkBox112.Checked = true;
			}
			else
			{
				uint address = 0x834FB424;
				byte[] array = new byte[4];
				array[0] = 57;
				array[1] = 96;
				ct2.SetMemory(address, array);
				uint address2 = 0x834FB3D0;
				array = new byte[4];
				array[0] = 56;
				array[1] = 96;
				ct2.SetMemory(address2, array);
				checkBox112.Checked = false;
			}
		}

        private void sg(object sender, EventArgs e)
        {
			if (checkBox113.Checked == false)
			{
				this.ct2.SetMemory(0x83225534, new byte[]
				{
					125,
					136,
					2,
					166
				});
				this.ct2.SetMemory(0x83225538, new byte[]
				{
					43,
					10,
					0,
					128
				});
				this.ct2.SetMemory(0x8322553C, new byte[]
				{
					65,
					154,
					0,
					16
				});
				this.ct2.SetMemory(0x83225540, new byte[]
				{
					137,
					118,
					1,
					28
				});
				this.ct2.SetMemory(0x83225544, new byte[]
				{
					125,
					136,
					3,
					166
				});
				this.ct2.SetMemory(0x83225548, new byte[]
				{
					78,
					128,
					0,
					32
				});
				this.ct2.SetMemory(0x8322554C, new byte[]
				{
					192,
					9,
					0,
					24
				});
				this.ct2.SetMemory(0x83225550, new byte[]
				{
					192,
					41,
					0,
					24
				});
				this.ct2.SetMemory(0x83225554, new byte[]
				{
					236,
					33,
					0,
					50
				});
				this.ct2.SetMemory(0x83225558, new byte[]
				{
					236,
					33,
					0,
					50
				});
				this.ct2.SetMemory(0x8322555C, new byte[]
				{
					236,
					33,
					0,
					50
				});
				this.ct2.SetMemory(0x83225560, new byte[]
				{
					236,
					33,
					0,
					50
				});
				this.ct2.SetMemory(0x83225564, new byte[]
				{
					208,
					41,
					0,
					136
				});
				this.ct2.SetMemory(0x83225568, new byte[]
				{
					16,
					0,
					25,
					195
				});
				this.ct2.SetMemory(0x83225570, new byte[]
				{
					16,
					0,
					25,
					195
				});
				this.ct2.SetMemory(0x83225574, new byte[]
				{
					137,
					118,
					1,
					28
				});
				this.ct2.SetMemory(0x83225578, new byte[]
				{
					125,
					136,
					3,
					166
				});
				this.ct2.SetMemory(0x8322557C, new byte[]
				{
					78,
					128,
					0,
					32
				});
				this.ct2.SetMemory(0x832241B0, new byte[]
				{
					252,
					0,
					120,
					144
				});
				this.ct2.SetMemory(0x8328B1E8, new byte[]
				{
					75,
					249,
					163,
					77
				});
				checkBox113.Checked = true;
			}
			else
			{
				this.ct2.SetMemory(0x8328B1E8, new byte[]
				{
					137,
					118,
					1,
					28
				});
				this.ct2.SetMemory(0x832241B0, new byte[]
				{
					192,
					27,
					0,
					204
				});
				checkBox113.Checked = false;
			}
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		private void button375_Click(object sender, EventArgs e)
        {

        }
    }
}
