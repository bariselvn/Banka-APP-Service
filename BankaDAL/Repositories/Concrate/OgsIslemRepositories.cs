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
    public class OgsIslemRepositories:Repository<OgsIslem,int>,IOgsIslemRepositories
    {
        private BankaDBEntities1 bk = new BankaDBEntities1();
        private OgsIslemContext _dbContext;
        public OgsIslemRepositories(OgsIslemContext context) : base(context)
        {
            _dbContext = context;
        }

    }
}
