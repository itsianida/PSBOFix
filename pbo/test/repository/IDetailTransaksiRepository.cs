using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.model;

namespace test.repository
{
    public interface IDetailTransaksiRepository
    {
        bool Add(DetailTransaksi trans);
        bool Delete(DetailTransaksi trans);
        List<DetailTransaksi> Get(long id);
        long total(long id);
    }
}
