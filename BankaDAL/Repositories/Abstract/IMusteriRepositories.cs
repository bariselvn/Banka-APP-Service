using BankaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaDAL.Repositories.Abstract
{
    public interface IMusteriRepositories:IRepositories<Musteri, int>
    {
       
        int login(string Tckn, string sifre);

    }
}
