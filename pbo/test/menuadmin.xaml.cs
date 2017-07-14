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
using System.Data;
using test.repository;
using test.model;
using static System.Object;
using static System.Windows.Forms.TabControl;
using System.ComponentModel;

namespace test
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
    public partial class menuadmin : Window
    {
        private Akun akun = new Akun();
        private IAkunRepository repo = new AkunRepository();
        private Barang barang = new Barang();
        private IBarangRepository repobar = new BarangRepository();
        private List<int> listselected;
        public menuadmin()
        {
            InitializeComponent();
            dataGrid.ItemsSource = repo.Get();
            dgbarang.ItemsSource = repobar.Get();
            listselected = new List<int>();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            login tampil = new login();
            tampil.Show();
            this.Close();
        }

        private void dg_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            FrameworkElement element = dataGrid.Columns[0].GetCellContent(e.Row);
            if (element.GetType() == typeof(CheckBox))
            {
                if (((CheckBox)element).IsChecked == true)
                {
                    FrameworkElement cellEmpNo = dataGrid.Columns[1].GetCellContent(e.Row);
                    int nomor = Convert.ToInt32(((TextBlock)cellEmpNo).Text);
                    listselected.Add(nomor);
                }
            }
        }

        private void tampeg_Click(object sender, RoutedEventArgs e)
        {
            tambahpegawai tampil = new tambahpegawai();
            tampil.Show();
            this.Close();
        }

        private void hapeg_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (listselected.Count() > 0)
                {
                    int count = 0;
                    foreach (int eno in listselected)
                    {
                        Akun emp = (from ep in repo.Get() where ep.IdPegawai == eno select ep).First();
                        repo.Delete(emp);
                        count++;
                    }
                    MessageBox.Show(count + " Row's Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            menuadmin aha = new menuadmin();
            this.Close();
            aha.tabControl1.SelectedIndex = 2;
            aha.Show();
        }


        private void lihat_Click(object sender, RoutedEventArgs e)
        {

            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        void editpegawai_Click(object sender, RoutedEventArgs e)
        {
            Akun epeg = (Akun)dataGrid.SelectedItems[0];
            editpegawai ep = new editpegawai(epeg);
            ep.Show();
            this.Close();
        }

        private void tambahbarang_Click(object sender, RoutedEventArgs e)
        {
            tambahproduk tampil = new tambahproduk();
            tampil.Show();
        }

        private void datag_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            FrameworkElement element = dgbarang.Columns[0].GetCellContent(e.Row);
            if (element.GetType() == typeof(CheckBox))
            {
                if (((CheckBox)element).IsChecked == true)
                {
                    FrameworkElement cellEmpNo = dgbarang.Columns[1].GetCellContent(e.Row);
                    int nomor = Convert.ToInt32(((TextBlock)cellEmpNo).Text);
                    listselected.Add(nomor);
                }
            }
        }

        private void hapusbarang_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (listselected.Count() > 0)
                {
                    int count = 0;
                    foreach (int eno in listselected)
                    {
                        Barang bar = (from hl in repobar.Get() where hl.IdBarang == eno select hl).First();
                        repobar.Delete(bar);
                        count++;
                    }
                    MessageBox.Show(count + " Row's Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            menuadmin muncul = new menuadmin();
            this.Close();
            muncul.tabControl1.SelectedIndex = 3;
            muncul.Show();

        }

        private void dgbarang_SelectionnChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void editbarang_Click(object sender, RoutedEventArgs e)
        {
            Barang edit = (Barang)dgbarang.SelectedItems[0];
            editproduk eb = new editproduk(edit);
            eb.ShowDialog();
        }

        private void barang_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgbarang.ItemsSource = (from cari in repobar.Get() where cari.NamaBarang.Contains(caribar.Text) select cari);
        }


    }
}
