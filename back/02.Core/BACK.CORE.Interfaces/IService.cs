namespace BACK.CORE.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetList();
        TEntity Get(Guid id);
        TEntity Add(TEntity entity);
        void Update(TEntity entityOld, TEntity entityNew);
        void Delete(TEntity entity);
    }
}