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
    /// Interaction logic for popkasir.xaml
    /// </summary>
    public partial class popkasir : Window
    {
        private DetailTransaksi detp = new DetailTransaksi();
        private IDetailTransaksiRepository repop = new DetailTransaksiRepository();
        private Barang b= new Barang();
        private Akun a = new Akun();
        private IBarangRepository repob = new BarangRepository();
        private long idtr;
        public popkasir(Akun akn, long i)
        {
            InitializeComponent();
            tamtr.DataContext = detp;
            a = akn;
            idtrans.Text = Convert.ToString(i);
            idtr = i;
            detp.IdTrans = i;
        }

        private void closep_Click(object sender, RoutedEventArgs e)
        {
            menukasir update = new menukasir(a);
            update.Show();
            this.Close();
        }

        private void okep_Click(object sender, RoutedEventArgs e)
        {
            b = repob.Find(detp.IdBarang);
            detp.HargaBarang = b.HargaBarang;
            detp.NamaBarang = b.NamaBarang;
            bool stat = repop.Add(detp);
            if (stat)
            {
                menukasir update = new menukasir(a);
                update.Show();
                this.Close();
            }
           
        }
    }
}
