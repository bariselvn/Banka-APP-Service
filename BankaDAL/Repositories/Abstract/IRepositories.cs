using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaDAL.Repositories.Abstract
{
    public interface IRepositories<TEntity, in TKey> where TEntity:class
    {
      TEntity  GetById(TKey id);
       IEnumerable<TEntity> GetAll();
       void Add(TEntity entity);
       void AddRange(IEnumerable<TEntity> entities);
       void Remove(TEntity entity);
       void RemoveRange(IEnumerable<TEntity> entities );
       void Update(TEntity entity);
    }
}
