using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banka.BankaDAL.Context
{
    public abstract class IContext:DbContext
    {

        public IContext() : base("BankaDBEntities1")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        
    }
}
