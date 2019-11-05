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
   public  class OgsRepositories :Repository<Ogs , int >,IOgsRepositories
    {
        private BankaDBEntities1 bk = new BankaDBEntities1();
        private OgsContext _dbContext;
        public OgsRepositories(OgsContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
