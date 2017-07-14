using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.model;
using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;

namespace test.repository
{
    public class BarangRepository : IBarangRepository
    {
        public BarangRepository()
        {
        }

        public bool Add(Barang barang)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    context.Barang.Add(barang);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public bool Delete(Barang barang)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    context.Barang.Remove(barang);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public bool tambah(Barang barang)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    var bar = context.Barang.Where(o => o.NamaBarang == barang.NamaBarang).FirstOrDefault();
                    if (bar != null)
                        return false;
                    else
                        return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<Barang> Get()
        {
            using (var context = new PsboContext())
            {
                var bar = context.Barang.ToList();
                return bar;
            }

        }

        public bool Update(Barang barang)
        {
            using (var context = new PsboContext())
            {
                var bar = context.Barang.SingleOrDefault(a => a.IdBarang == barang.IdBarang);
                if (bar != null)
                {
                    try
                    {
                        if(Delete(bar) & Add(barang)){
                            context.SaveChanges();
                            return true;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return false;
            }
        }
        public Barang Find(long id)
        {
            using (var context = new PsboContext())
            {
                Barang b = context.Barang.Where(bar=>bar.IdBarang== id).FirstOrDefault();
                return b;
            }
        }
    }
}
