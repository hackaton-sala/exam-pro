using BACK.CORE.Interfaces;
using BACK.CORE.Queries.OData;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BACK.IL.Repository.EF.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Query().ToList();
        }

        public virtual IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>().AsNoTracking().AsQueryable();
        }

        public OQuery<TEntity> GetFiltered(ODataQueryOptions options = null)
        {

            IQueryable<TEntity>? query = Query();

            OQuery<TEntity> oQuery = new();

            // Filtro
            if (options.Filter == null)
            {
                oQuery.TotalRegistros = query.Count();
                query = options.ApplyTo(query) as IQueryable<TEntity>;
            }
            else
            {
                query = options.ApplyTo(query, AllowedQueryOptions.Top | AllowedQueryOptions.Skip) as IQueryable<TEntity>;
                oQuery.TotalRegistros = query.Count();
                query = options.ApplyTo(query, AllowedQueryOptions.Filter) as IQueryable<TEntity>;
            }

            oQuery.Resultado = query.ToList();

            return oQuery;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
