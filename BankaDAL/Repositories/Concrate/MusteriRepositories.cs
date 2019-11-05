using BankaDAL.Context;
using BankaDAL.Repositories.Abstract;
using BankaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaDAL.Repositories.Concrate
{
    public class MusteriRepositories : Repository<Musteri, int>, IMusteriRepositories
    {
        private BankaDBEntities1 bk = new BankaDBEntities1();//Singelton Kullan
        private MusteriContext _dbContext;
        public MusteriRepositories(MusteriContext context) : base(context)
        {
            _dbContext = context;
        }


        public int login(string Tckn, string sifre  )
        {
            var user = _dbContext.Musteriler.FirstOrDefault(x => x.Tckn == Tckn);
            if (user != null)
            {
                if (user.sifre == sifre)
                {
                    return user.MusteriID;
                }
                else
                {

                    return 0;

                }
            }
            else
            {
                return 0;
            }
        }
    }
}
