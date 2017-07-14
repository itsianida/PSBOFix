using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.model;

namespace test.repository
{
    public interface IBarangRepository
    {
        bool Add(Barang barang);
        bool Delete(Barang barang);
        bool Update(Barang barang);
        List<Barang> Get();
        bool tambah(Barang barang);
        Barang Find(long id);
    }
}

