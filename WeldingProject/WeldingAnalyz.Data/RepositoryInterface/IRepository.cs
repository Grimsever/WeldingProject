using System.Collections.Generic;

namespace WeldingAnalyz.Data.RepositoryInterface
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetByName(string name);
        void Insert(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
    }
}
