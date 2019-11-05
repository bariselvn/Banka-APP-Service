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
    public class HesapRepositories : Repository<Hesap, int>, IHesapRepositories
    {
        private BankaDBEntities1 bk = new BankaDBEntities1();
        private HesapContext _dbContext;
        public HesapRepositories(HesapContext context) : base(context)
        {
            _dbContext = context;
        }
        public IEnumerable<Hesap> hesapGetir(int MusteriID)
        {
            var hesaplar = _dbContext.Hesaplar.Where(x => x.MusteriID == MusteriID).ToList();
            return hesaplar;
        }
        public int hesapDondur(int MusteriID, int  ekNO)
        {
            var user = _dbContext.Hesaplar.FirstOrDefault(x => x.MusteriID == MusteriID);
            if (user != null)
            {
                if (user.ekNO == ekNO)
                {
                    return user.hesapID;
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
