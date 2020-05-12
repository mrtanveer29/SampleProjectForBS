using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;

namespace DataAccessWithRepository.Model.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        TEntity Find(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);
        IEnumerable<TEntity> GetAll();

        bool Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);

        bool Remove(TEntity entity);
        int RemoveRange(IEnumerable<TEntity> entities);


    }
}
