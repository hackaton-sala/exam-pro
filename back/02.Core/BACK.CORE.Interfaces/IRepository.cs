using BACK.CORE.Queries.OData;
using Microsoft.AspNetCore.OData.Query;
using System.Linq.Expressions;

namespace BACK.CORE.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        OQuery<TEntity> GetFiltered(ODataQueryOptions options);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}