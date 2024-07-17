using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using MaterialSkin;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;


namespace bigboy
{
    public partial class TheCalzoneBay : MaterialSkin.Controls.MaterialForm
	{
        public TheCalzoneBay()
        {
            InitializeComponent();

			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.DeepPurple600, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
		}

		int tcb = 0;
		int tcb2 = 0;
		private void TheCalzoneBay_Load(object sender, EventArgs e)
		{
			security.processes.pulse();
			while (tcb == 0)
			{
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

		public string SpaceDash(string input)
        {
            return input.Replace(" ", "-");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://dlxbgame.com/" + SpaceDash(textBox1.Text) + "-jtag-rgh/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://dlxbgame.com/" + SpaceDash(textBox2.Text) + "-arcade-xbla/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://dlxbgame.com/" + SpaceDash(textBox3.Text) + "-xbox-classic/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://dlxbgame.com/" + SpaceDash(textBox4.Text) + "-indie-jtag-rgh/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://1fichier.com/dir/QbkZNgPa");
        }

        private void XEXLoader_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string yeet;
        string path = Environment.CurrentDirectory + "\\xexs\\";
        private void DLXEXButton(object sender, EventArgs e)
        {
			if (this.XEXLoader.SelectedItem.ToString() == "ADVANCED WARFARE ->")
			{
				WebClient aw = new WebClient();
				aw.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1014123938432958545/AW.xex", Environment.CurrentDirectory + "\\xexs\\Ninja V2\\AW.xex");
			}
			if (this.XEXLoader.SelectedItem.ToString() == "BO1 ->")
			{
				WebClient bo1 = new WebClient();
				bo1.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1014123938734932088/BO1.xex", Environment.CurrentDirectory + "\\xexs\\Ninja V2\\BO1.xex");
			}
			if (this.XEXLoader.SelectedItem.ToString() == "BO2 ->")
			{
				WebClient bo2 = new WebClient();
				bo2.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1014123939087274004/BO2.xex", Environment.CurrentDirectory + "\\xexs\\Ninja V2\\BO2.xex");
			}
			if (this.XEXLoader.SelectedItem.ToString() == "BO3 ->")
			{
				WebClient bo3 = new WebClient();
				bo3.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1014123936319021096/BO3.xex", Environment.CurrentDirectory + "\\xexs\\Ninja V2\\BO3.xex");
			}
			if (this.XEXLoader.SelectedItem.ToString() == "GHOSTS ->")
			{
				WebClient ghosts = new WebClient();
				ghosts.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1014123936704888872/GHO.xex", Environment.CurrentDirectory + "\\xexs\\Ninja V2\\GHOSTS.xex");
			}
			if (this.XEXLoader.SelectedItem.ToString() == "COD4 ->")
			{
				WebClient cod4 = new WebClient();
				cod4.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1014123937032065076/MW1.xex", Environment.CurrentDirectory + "\\xexs\\Ninja V2\\COD4.xex");
			}
			if (this.XEXLoader.SelectedItem.ToString() == "MW2 ->")
			{
				WebClient mw2 = new WebClient();
				mw2.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1014123937422118962/MW2.xex", Environment.CurrentDirectory + "\\xexs\\Ninja V2\\MW2.xex");
			}
			if (this.XEXLoader.SelectedItem.ToString() == "MW3 ->")
			{
				WebClient mw3 = new WebClient();
				mw3.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1014123937816379442/MW3.xex", Environment.CurrentDirectory + "\\xexs\\Ninja V2\\MW3.xex");
			}
			if (this.XEXLoader.SelectedItem.ToString() == "WAW ->")
			{
				WebClient waw = new WebClient();
				waw.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1014123938130960394/WAW.xex", Environment.CurrentDirectory + "\\xexs\\Ninja V2\\WAW.xex");
			}
			//////////////////////////////////////////////////////////								MULTI XEX'S								//////////////////////////////////////////////////////////

			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			if (XEXLoader.SelectedItem.ToString() == "Matrix ->")
			{
				WebClient matrix = new WebClient();
				matrix.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/1070036877261946980/MatrixMods.xex", Environment.CurrentDirectory + "\\xexs\\multi xexs\\MartrixMods.xex");

			}
			if (XEXLoader.SelectedItem.ToString() == "Myten V1.2 ->")
			{
				WebClient myten = new WebClient();
				myten.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/992516490911821864/Myten_V1.2.xex", Environment.CurrentDirectory + "\\xexs\\multi xexs\\Myten_V1.2.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "Velonia ->")
			{
				WebClient Velonia = new WebClient();
				Velonia.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1102598368267603999/Velonia.xex", Environment.CurrentDirectory + "\\xexs\\multi xexs\\Velonia.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "Appendum ->")
			{
				WebClient appendum = new WebClient();
				appendum.DownloadFile("https://cdn.discordapp.com/attachments/927961141664178270/992515274408468491/Appendum.xex", Environment.CurrentDirectory + "\\xexs\\multi xexs\\Appendum.xex");
			}
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			//////////////////////////////////////////////////////////								OFFHOST XEX'S								/////////////////////////////////////////////////////
			if (XEXLoader.SelectedItem.ToString() == "Aspire ->")
			{
				WebClient aspire = new WebClient();
				aspire.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1102598369026773012/Aspire.xex", Environment.CurrentDirectory + "\\xexs\\Offhosts\\Aspire.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "xNet ->")
			{
				WebClient xNet = new WebClient();
				xNet.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1102598368687042711/xNET_Engine.xex", Environment.CurrentDirectory + "\\xexs\\Offhosts\\xNET_Engine.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "BO1 Shit Menu ->")
			{
				WebClient shitmenu = new WebClient();
				shitmenu.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1152351293554311219/cod_bo1_-_Shit_Menu.xex", Environment.CurrentDirectory + "\\xexs\\Offhosts\\BO1ShitMenu.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "BO2 DankCE ->")
			{
				WebClient DankCE = new WebClient();
				DankCE.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1152351293852090448/cod_bo2_-_Dank.xex", Environment.CurrentDirectory + "\\xexs\\Offhosts\\BO2DankCE.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "BO2 EnviousCE ->")
			{
				WebClient EnviousCE = new WebClient();
				EnviousCE.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1152351292946120755/cod_bo2_-_EnviousCE.xex", Environment.CurrentDirectory + "\\xexs\\Offhosts\\BO2EnviousCE.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "BO2 VenomCE ->")
			{
				WebClient VenomCE = new WebClient();
				VenomCE.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1152351293256507462/cod_bo2_-_Venom_CE.xex", Environment.CurrentDirectory + "\\xexs\\Offhosts\\BO2VenomCE.xex");
			}
			//////////////////////////////////////////////////////////								HOST XEX'S								/////////////////////////////////////////////////////
			if (XEXLoader.SelectedItem.ToString() == "GTAV Enforcer Menu ->")
			{
				WebClient Enforcer = new WebClient();
				Enforcer.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1152356987447808081/gtav_-_Enforcer_v2.9.4.xex", Environment.CurrentDirectory + "\\xexs\\Host Menus\\GTAV Enforcer.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "GTAV Frostbite Menu ->")
			{
				WebClient Frostbite = new WebClient();
				Frostbite.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1152356987854671992/gtav_-_Frostbite.xex", Environment.CurrentDirectory + "\\xexs\\Host Menus\\GTAV Frostbite.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "GTAV Legacy Menu ->")
			{
				WebClient Legacy = new WebClient();
				Legacy.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1152356988316029099/gtav_-_LegacyV1.xex", Environment.CurrentDirectory + "\\xexs\\Host Menus\\GTAV Legacy.xex");
			}
			if (XEXLoader.SelectedItem.ToString() == "Cod Ghosts ImGay Menu ->")
			{
				WebClient ImGay = new WebClient();
				ImGay.DownloadFile("https://cdn.discordapp.com/attachments/951248942413250653/1152356988756443196/cod_ghosts_-_ImGay.xex", Environment.CurrentDirectory + "\\xexs\\Host Menus\\GHOSTS ImGay.xex");
			}
		}

        private void button6_Click(object sender, EventArgs e)
        {
			Process.Start("https://xboxdb.altervista.org/browse/");
        }

		private string extras;
		string path2 = Environment.CurrentDirectory + "\\extras\\";
		private void button7_Click(object sender, EventArgs e)
        {
			if (this.XEXLoader.SelectedItem.ToString() == "Avatar Items")
			{
				Process.Start("https://1fichier.com/?0co2avpps9w3sxghny5u");
			}
			if (this.XEXLoader.SelectedItem.ToString() == "Colored Xnotifs")
			{
				WebClient aw = new WebClient();
				aw.DownloadFile("https://cdn.discordapp.com/attachments/1161808048910774392/1166138320661790800/Colored_XNotifys.zip?ex=654965f1&is=6536f0f1&hm=99e91d053ded0838069791a2d0b96ed264563f9505c07d272a5fb854a92aed66&", Environment.CurrentDirectory + "\\extras\\Xnotifs.xex");
			}
		}

        private void DLTOOL_Click(object sender, EventArgs e)
        {

        }
    }
}
