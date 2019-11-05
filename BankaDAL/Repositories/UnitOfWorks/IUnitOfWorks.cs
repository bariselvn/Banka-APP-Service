using BankaDAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaDAL.Repositories.UnitOfWorks
{
    public interface IUnitOfWorks:IDisposable
    {
        IEftHavaleRepositories EftHavaleRepository { get; }
        IHesapRepositories HesapRepository { get; }
        IHesapIslemlerRepositories HesapIslemlerRepository { get; }
        IHıslemRepositories HIslemRepository { get; }
        IMusteriRepositories MusteriRepository { get; }
        IOgsIslemRepositories OgsIslemlerRepository { get; }
        IOgsRepositories OgsRepository { get; }
        IOıslemlerRepositories OıslemlerRepository { get; }
        IFaturaIslemRepositories FaturaIslemRepository { get; }

        void Commit();
    }
}
