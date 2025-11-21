using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ProovinPilti
{
    internal class Program
    {
        [STAThread] // see rida oleks kasulik lisada, muidu võib akendega jama tulla - Winform projekt paneb selle ise
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            string pildifail = "C:\\Users\\sarvi\\OneDrive\\Pictures\\Salvestatud pildid\\henn.jpg";

            var form = new Form
            {
                Width= 500,
                Height= 500,
                Text = "Pilt"
            };

            Button btn = new Button
            {
                Left= 0,
                Top= 0,
                Text = "olen nupp"
            };


            var menu = new MenuStrip();
            var file = new ToolStripMenuItem("File");
            file.DropDownItems.Add("Exit", null, (s, e) => form.Close());
            menu.Items.Add(file);

            //MessageBox.Show("Tere", "Tere");

            var pic = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile(pildifail),
                
            };
            form.Controls.Add(menu);
            form.Controls.Add(pic);
            //form.Controls.Add(btn);
            menu.BringToFront();
            btn.BringToFront();
            Application.Run(form);
            //form.ShowDialog();


        }
    }
}
