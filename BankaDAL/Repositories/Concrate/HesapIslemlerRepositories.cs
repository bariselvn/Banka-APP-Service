﻿using BankaDAL.Context;
using BankaDAL.Repositories.Abstract;
using BankaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaDAL.Repositories.Concrate
{
    public class HesapIslemlerRepositories : Repository<HesapIslem, int>, IHesapIslemlerRepositories
    {
        private BankaDBEntities1 bk = new BankaDBEntities1();
        private HesapIslemlerContext _dbContext;
        public HesapIslemlerRepositories(HesapIslemlerContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
