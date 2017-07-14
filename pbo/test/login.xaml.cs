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
using System.Windows.Shapes;
using System.Data.SQLite;
using test.repository;
using test.model;
namespace test
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class login : Window
    {
        private Akun akun = new Akun();
        private IAkunRepository repo = new AkunRepository();
        public login()
        {
            InitializeComponent();
        }
     
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     
        private void login1_Click(object sender, RoutedEventArgs e)
        {
            akun.Username = username.Text;
            akun.Password = password.Password;
            try
            {
                bool status= repo.login(akun);
                if (status)
                {
                    if (akun.Username == "admin")
                    {
                        menuadmin menu = new menuadmin();
                        menu.Show();
                        this.Close();
                    }
                    else
                    {
                        menukasir menuk = new menukasir(akun);
                        menuk.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Password atau username salah");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
