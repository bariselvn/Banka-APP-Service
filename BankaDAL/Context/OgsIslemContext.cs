﻿using Banka.BankaDAL.Context;
using BankaData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaDAL.Context
{
    public class OgsIslemContext:IContext
    {
        public DbSet <OgsIslem>OgsIslemler { get; set; }
    }
}
