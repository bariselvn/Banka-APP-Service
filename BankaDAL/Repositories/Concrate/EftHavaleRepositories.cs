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
    public class EftHavaleRepositories : Repository<EftHavale, int>, IEftHavaleRepositories
    {
        private BankaDBEntities1 bk = new BankaDBEntities1();
        private EftHavaleContext _dbContext;
        public EftHavaleRepositories(EftHavaleContext context) : base(context)
        {
            _dbContext = context;
        }
       
    }
}
