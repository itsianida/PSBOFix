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
using test.model;
using test.repository;
using System.Text.RegularExpressions;

namespace test
{
    /// <summary>
    /// Interaction logic for tambahpegawai.xaml
    /// </summary>
    public partial class tambahpegawai : Window
    {
        private Akun akun = new Akun();
        private IAkunRepository repo = new AkunRepository();
        public tambahpegawai()
        {
            InitializeComponent();
            AddPegawai.DataContext = akun;

        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            akun.Username = username.Text;
            akun.Password = password.Password;
            try
            {
                bool status = repo.tambah(akun);
                if (status)
                {
                    repo.Add(akun);
                    menuadmin update = new test.menuadmin();
                    update.tabControl1.SelectedIndex = 2;
                    update.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("username sudah dipakai, coba username lain", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            menuadmin update = new test.menuadmin();
            update.tabControl1.SelectedIndex = 2;
            update.Show();
            this.Close();
        }

        private void nohp_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void nopegawai_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
