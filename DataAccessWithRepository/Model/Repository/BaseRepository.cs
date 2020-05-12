using DataAccessWithRepository.Model.IRepository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessWithRepository.Model.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    
        private readonly DbSet<TEntity> _entities;
        protected readonly IdentityDbContext context;

        public BaseRepository(IdentityDbContext context)
        {
            this._entities = context.Set<TEntity>();
            this.context = context;
        }

        public bool Add(TEntity entity)
        {

            _entities.Add(entity);
            return true;
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
            return 1;
        }

        public TEntity Find(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public bool Remove(TEntity entity)
        {
            _entities.Remove(entity);
            return true;
        }

        public int RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
            return 1;
        }
    }
}
