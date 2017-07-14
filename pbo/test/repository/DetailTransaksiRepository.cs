using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.model;
using System.Data.SQLite;

namespace test.repository
{
    public class DetailTransaksiRepository : IDetailTransaksiRepository
    {
        public DetailTransaksiRepository()
        {

        }
        public bool Add(DetailTransaksi trans)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    context.DetailTransaksi.Add(trans);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public bool Delete(DetailTransaksi trans)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    context.DetailTransaksi.Remove(trans);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public List<DetailTransaksi> Get(long id)
        {
            using (var context_trans = new PsboContext())
            {
                var transaksi = context_trans.DetailTransaksi.Where(o => o.IdTrans == id).ToList();
                return transaksi;
            }
        }
        public long total(long id)
        {
            using(var context=new PsboContext())
            {
                var lis = Get(id);
                long sum = 0;
                long kali = 1;
                for (int i = 0; i< context.DetailTransaksi.Where(o=>o.IdTrans==id).ToList().Count(); i++){
                    long j = Convert.ToInt32(lis[i].JumlahBarang);
                    long h = Convert.ToInt32(lis[i].HargaBarang);
                    kali = j * h;
                    sum += kali;
                    kali = 1;
                }
                return sum;
            } 
        }
       

    }
}
