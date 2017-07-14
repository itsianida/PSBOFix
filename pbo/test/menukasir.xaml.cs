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

namespace test
{
    /// <summary>
    /// Interaction logic for menukasir.xaml
    /// </summary>
    public partial class menukasir : Window
    {
        private Transaksi trans = new Transaksi();
        private ITransaksiRepository repok = new TransaksiRepository();
        private Akun kasirq = new Akun();
        private IAkunRepository repoak=new AkunRepository();
        private IDetailTransaksiRepository repodt = new DetailTransaksiRepository();
        private long id,bayar;
        private long totalharga = -1;
        public menukasir(Akun kasir)
        {
            
            id=repok.getId()+1;
            InitializeComponent();
            GridTransaksi.ItemsSource = repodt.Get(id);
            string u = kasir.Username;
            kasirq = repoak.Find(u);
            opr.Text = kasirq.NamaLengkap;
            nomOp.Text = Convert.ToString(id);

        }

        private void savetrans_Click(object sender, RoutedEventArgs e)
        {
            long t = repodt.total(id);
            trans.TotalHarga = t;
            trans.TanggalTrans = DateTime.Now.ToString();
            trans.Diskon = 0;
            bool add = repok.Add(trans);
            string ttl = Convert.ToString(t);

            total.Text = String.Format("{0:c}", ttl);
            
            totalharga = t;
        }

        private void lakun_click(object sender, RoutedEventArgs e)
        {

            lihatakun lakun = new lihatakun(kasirq);
            lakun.Show();
        }

        private void latrans_click(object sender, RoutedEventArgs e)
        {
            lihattrans latr = new lihattrans();
            latr.Show();
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();

        }

       

        private void TAM_Click(object sender, RoutedEventArgs e)
        {
            popkasir baru = new popkasir(kasirq,id);
            baru.Show();
            this.Close();
        }

        private void logoutkasir_click(object sender, RoutedEventArgs e)
        {
            login balik = new login();
            balik.Show();
            this.Close();
        }

        private void kembali_Click(object sender, RoutedEventArgs e)
        {
            bayar = Convert.ToInt32(bayar_box.Text);
            if (totalharga != -1)
            {
                if (bayar < totalharga)
                {
                    MessageBox.Show("Uang kurang, dilarang ngutang!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    long kembali = bayar - totalharga;
                    string kem= Convert.ToString(kembali);
                    kmbl.Text = String.Format("{0:c}", kem);
                }
                
            }
        }
    }

}
