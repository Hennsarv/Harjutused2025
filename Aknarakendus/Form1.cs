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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace( this.textBox1.Text))
            {
                return;
            }
            this.label1.BackColor = Color.Red;
            this.button1.BackColor = Color.Green;
            this.label1.Text = $"Tere {this.textBox1.Text}!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var teine = new Form2();
            teine.Show();
        }
    }
}
