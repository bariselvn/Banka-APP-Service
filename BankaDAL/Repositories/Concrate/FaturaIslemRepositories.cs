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
    public class FaturaIslemRepositories : Repository<FaturaIslem, int>, IFaturaIslemRepositories
    {
        private BankaDBEntities1 bk = new BankaDBEntities1();
        private FaturaIslemContext _dbContext;
        public FaturaIslemRepositories(FaturaIslemContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
