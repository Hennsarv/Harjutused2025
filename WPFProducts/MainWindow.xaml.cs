using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WPFProducts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pwd = boxike.Text.Trim();
            var db = new NorthwindEntities(pwd);
            var tooted = db.Products.ToList();
            this.griidike.ItemsSource = tooted; // db.Products.ToList();
        }
    }

    public partial class NorthwindEntities
    {
        public NorthwindEntities(string pwd) : base("name=NorthwindEntities")
        {
            SqlConnection conn = (SqlConnection)this.Database.Connection;
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(conn.ConnectionString);
            csb.Password= pwd;
            conn.ConnectionString = csb.ToString();
        }
    }
}
