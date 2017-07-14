using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.model;
using System.Data.SQLite;

namespace test.repository
{
    public class TransaksiRepository : ITransaksiRepository
    {
        public TransaksiRepository()
        {
        }
        public bool Add(Transaksi trans)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    context.Transaksi.Add(trans);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public bool Delete(Transaksi trans)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    context.Transaksi.Remove(trans);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public long getId()
        {
            using (var context = new PsboContext()){
                long a = context.Transaksi.Count();
                return a;
            }
        }
        public List<Transaksi> Get()
        {
            using (var context_trans = new PsboContext())
            {
                var transaksi = context_trans.Transaksi.ToList();
                return transaksi;
            } 
        }

    }
}
