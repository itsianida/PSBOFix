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
    /// Interaction logic for editproduk.xaml
    /// </summary>
    public partial class editproduk : Window
    {
        private Barang barang = new Barang();
        private IBarangRepository repobar = new BarangRepository();
        public editproduk(Barang b)
        {
            InitializeComponent();
            EditProduk.DataContext = b;
            barang = b;
        }



        private void cancelbaredit_Click(object sender, RoutedEventArgs e)
        {
            menuadmin update = new test.menuadmin();
            update.tabControl1.SelectedIndex = 3;
            update.Show();
            this.Close();
        }

        private void SaveEditProd_Click(object sender, RoutedEventArgs e)
        {
            bool status = repobar.Update(barang);
            if (status)
            {
                MessageBox.Show("Simpan berhasil!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                menuadmin updated = new menuadmin();
                updated.tabControl1.SelectedIndex = 3;
                updated.Show();
                this.Close();
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
