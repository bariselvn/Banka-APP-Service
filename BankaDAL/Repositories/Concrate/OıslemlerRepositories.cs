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
   public class OıslemlerRepositories:Repository<Islemler,int>,IOıslemlerRepositories
    {
        private BankaDBEntities1 bk = new BankaDBEntities1();
        private OıslemContext _dbContext;
        public OıslemlerRepositories(OıslemContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
