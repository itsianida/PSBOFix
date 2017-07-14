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
    /// Interaction logic for editpegawai.xaml
    /// </summary>
    public partial class editpegawai : Window
    {
        private Akun akun = new Akun();
        private IAkunRepository repo = new AkunRepository();

        public editpegawai(Akun ed)
        {
            InitializeComponent();
            password.Password = ed.Password;
            EditPegawai.DataContext = ed;
            akun = ed;
        }


        private void save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    bool status = repo.Update(akun);
                    if (status)
                    {
                        MessageBox.Show("Akun telah berhasil diedit", "Edit Akun", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (akun.Username == "admin")
                        {
                            menuadmin update = new test.menuadmin();
                            update.tabControl1.SelectedIndex = 2;
                            update.Show();
                            this.Close();
                        }
                        else
                        {
                            lihatakun update = new test.lihatakun(akun);
                            update.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gagal mengupdate akun, silahkan coba lagi", "Edit Akun", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            if (akun.Username == "admin")
            {
                menuadmin update = new test.menuadmin();
                update.tabControl1.SelectedIndex = 2;
                update.Show();
                this.Close();
            }
            else
            {
                lihatakun update = new test.lihatakun(akun);
                update.Show();
                this.Close();
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
