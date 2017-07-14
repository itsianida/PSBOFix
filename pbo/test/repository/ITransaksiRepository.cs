using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.model;

namespace test.repository
{
    public interface ITransaksiRepository
    {
        bool Add(Transaksi trans);
        bool Delete(Transaksi trans);
        List<Transaksi> Get();
        long getId();
    }
}
