using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.model;
using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;

namespace test.repository
{
    public class AkunRepository : IAkunRepository
    {
       

        public AkunRepository()
        {           
        }
        public bool Add(Akun akun)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    context.Akun.Add(akun);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public bool login(Akun akun)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    var user = context.Akun.Where(o => o.Username == akun.Username && o.Password == akun.Password).FirstOrDefault();
                    if (user != null)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool Delete(Akun akun)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    context.Akun.Remove(akun);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

      
        public bool tambah(Akun akun)
        {
            using (var context = new PsboContext())
            {
                try
                {
                    var user = context.Akun.Where(o => o.Username == akun.Username).FirstOrDefault();
                    if (user != null)
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
        public List<Akun> Get() {
            using (var context = new PsboContext())
            {
                var users = context.Akun.ToList();
                return users;
            }

        }
        
        public bool Update(Akun akun)
        {
            using (var context = new PsboContext())
            {
                var user = context.Akun.Find(akun.IdPegawai);
                if (user != null) {
                    try {
                        bool del=Delete(user);
                        if (del)
                        {
                            bool upd = Add(akun);
                            if (upd)
                            {
                                return true;
                            }
                        }
                       
                        context.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        throw;
                    }
                }
                return false;
            }
        }
        public Akun Find(string u)
        {
            using(var context=new PsboContext())
            {
                Akun ak = context.Akun.Where(o => o.Username == u).FirstOrDefault();
                return ak;
            }
        }
    }
}
