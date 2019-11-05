﻿using BankaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaDAL.Repositories.Abstract
{
    public interface IHesapRepositories:IRepositories<Hesap, int>
    {
       IEnumerable<Hesap> hesapGetir(int MusteriID);
        int hesapDondur(int MusteriID, int ekNO);



    }
}
