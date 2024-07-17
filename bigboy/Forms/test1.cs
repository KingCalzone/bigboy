using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace bigboy
{
    public partial class test1 : MaterialSkin.Controls.MaterialForm
    {
        public test1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Amber100, Accent.DeepPurple700, TextShade.WHITE);
        }

        private void test1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
