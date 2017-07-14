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
    /// Interaction logic for lihatakun.xaml
    /// </summary>
    public partial class lihattrans : Window
    {
        private Transaksi dtt = new Transaksi();
        private ITransaksiRepository repotrans = new TransaksiRepository();
        private List<int> selectedlist;
        public lihattrans()
        {
            InitializeComponent();
            GridLT.ItemsSource = repotrans.Get();
            selectedlist = new List<int>();
        }
    }
}
