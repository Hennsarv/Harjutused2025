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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new northwindEntities(this.textBox1.Text);

            var prod = db.Products.ToList();
            this.dataGridView1.DataSource = prod;
        }
    }
}
