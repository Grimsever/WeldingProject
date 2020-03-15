using System.Collections.Generic;

namespace WeldingAnalyz.DAL.Interface
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity GetByName(string name);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        void Remove(TEntity entity);
        void Update(TEntity entity);
        void Save();
    }
}
