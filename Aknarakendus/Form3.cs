using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aknarakendus
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "ära siis virise";
            this.FormClosing -= this.kasSulgeme;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Text = "no tõstame siis";
        }

        private void ohoo(object sender, EventArgs e)
        {
            this.button2.Hide();
        }

        private void kasSulgeme(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
