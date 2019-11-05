using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankaDAL.Context;
using BankaDAL.Repositories.Abstract;
using BankaDAL.Repositories.Concrate;

namespace BankaDAL.Repositories.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWorks
    {

        private readonly EftHavaleContext _EftHavaleContext;
        private readonly HesapContext _HesapContext;
        private readonly HesapIslemlerContext _HesapIslemlerContext;
        private readonly HıslemContext _HıslemContext;
        private readonly MusteriContext _MusteriContext;
        private readonly OgsContext _OgsContext;
        private readonly OgsIslemContext _OgsIslemContext;
        private readonly OıslemContext _OıslemContext;
        private readonly FaturaIslemContext _FaturaIslemContext;

        public IEftHavaleRepositories EftHavaleRepository { get; private set; }
        public IFaturaIslemRepositories FaturaIslemRepository { get; private set; }
        public IHesapRepositories HesapRepository { get; private set; }
        public IHesapIslemlerRepositories HesapIslemlerRepository { get; private set; }
        public IHıslemRepositories HIslemRepository { get; private set; }
        public IMusteriRepositories MusteriRepository { get; private set; }
        public IOgsRepositories OgsRepository { get; private set; }
        public IOgsIslemRepositories OgsIslemlerRepository { get; private set; }
       public IOıslemlerRepositories OıslemlerRepository { get; private set; }

 

        public UnitOfWorks( EftHavaleContext context)
        {
            _EftHavaleContext = context;
            EftHavaleRepository = new BankaDAL.Repositories.Concrate.EftHavaleRepositories(_EftHavaleContext);
        }
        public UnitOfWorks(FaturaIslemContext context)
        {
            _FaturaIslemContext = context;
            FaturaIslemRepository = new BankaDAL.Repositories.Concrate.FaturaIslemRepositories(_FaturaIslemContext);
        }

        public UnitOfWorks(HesapContext context)
        {
            _HesapContext = context;
            HesapRepository= new BankaDAL.Repositories.Concrate.HesapRepositories(_HesapContext);
        }
        public UnitOfWorks(HesapIslemlerContext context)
        {
            _HesapIslemlerContext = context;
            HesapIslemlerRepository = new BankaDAL.Repositories.Concrate.HesapIslemlerRepositories(_HesapIslemlerContext);
        }
        public UnitOfWorks(HıslemContext context)
        {
            _HıslemContext = context;
            HIslemRepository = new BankaDAL.Repositories.Concrate.HıslemRepositories(_HıslemContext);
        }
        public UnitOfWorks(MusteriContext context)
        {
            _MusteriContext = context;
            MusteriRepository = new BankaDAL.Repositories.Concrate.MusteriRepositories(_MusteriContext);
        }
        public UnitOfWorks(OgsContext context)
        {
            _OgsContext = context;
            OgsRepository = new BankaDAL.Repositories.Concrate.OgsRepositories(_OgsContext);
        }
        public UnitOfWorks(OgsIslemContext context)
        {
            _OgsIslemContext = context;
            OgsIslemlerRepository = new BankaDAL.Repositories.Concrate.OgsIslemRepositories(_OgsIslemContext);
        }
        public UnitOfWorks(OıslemContext context)
        {
            _OıslemContext = context;
            OıslemlerRepository = new BankaDAL.Repositories.Concrate.OıslemlerRepositories(_OıslemContext);
        }

        public void Commit()
        {
            if(_EftHavaleContext != null)
            {
                _EftHavaleContext.SaveChanges();
            }
            if (_FaturaIslemContext != null)
            {
                _FaturaIslemContext.SaveChanges();
            }
            if (_HesapContext != null)
            {
                _HesapContext.SaveChanges();
            }
            if (_HesapIslemlerContext != null)
            {
                _HesapIslemlerContext.SaveChanges();
            }
            if (_HıslemContext != null)
            {
                _HıslemContext.SaveChanges();
            }
            if (_MusteriContext != null)
            {
                _MusteriContext.SaveChanges();
            }
            if (_OgsContext != null)
            {
                _OgsContext.SaveChanges();
            }
            if (_OgsIslemContext != null)
            {
               _OgsIslemContext.SaveChanges();
            }
            if (_OıslemContext != null)
            {
             _OıslemContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
