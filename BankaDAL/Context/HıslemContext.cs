using Banka.BankaDAL.Context;
using BankaData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaDAL.Context
{
    public class HıslemContext:IContext
    {
        public DbSet <Islem> Islemler{ get; set; }
    }
}
