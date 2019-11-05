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
    public class HıslemRepositories:Repository<Islem,int>,IHıslemRepositories
    {
        private BankaDBEntities1 bk = new BankaDBEntities1();
        private HıslemContext _dbContext;
        public HıslemRepositories(HıslemContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
