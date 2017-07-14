using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.model;

namespace test.repository
{
    public interface IAkunRepository
    {
        bool Add(Akun akun);
        bool Delete(Akun akun);
        bool Update(Akun akun);
        List<Akun> Get();
        
        bool login(Akun akun);
        bool tambah(Akun akun);
        Akun Find(string u);
    }
}
