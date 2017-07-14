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
using test.model;
using test.repository;
using System.Text.RegularExpressions;

namespace test
{
    /// <summary>
    /// Interaction logic for tambahproduk.xaml
    /// </summary>
    public partial class tambahproduk : Window
    {
        private Barang barang = new Barang();
        private IBarangRepository repobar = new BarangRepository();
      

        public tambahproduk()
        {
            InitializeComponent();
            AddProduk.DataContext = barang;
        }

        private void savebar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool status = repobar.tambah(barang);
                if (status)
                {
                    repobar.Add(barang);
                    menuadmin update = new test.menuadmin();
                    update.tabControl1.SelectedIndex = 3;
                    update.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("barang sudah ada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cancelbar_Click(object sender, RoutedEventArgs e)
        {
            menuadmin update = new test.menuadmin();
            update.tabControl1.SelectedIndex = 3;
            update.Show();
            this.Close();
        }

        private void jum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void harga_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
