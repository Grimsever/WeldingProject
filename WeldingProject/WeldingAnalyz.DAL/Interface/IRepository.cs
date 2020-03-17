using System.Collections.Generic;
using WeldingAnalyz.DAL.Models;

namespace WeldingAnalyz.DAL.Interface
{
    public interface IRepository<TEntity> where TEntity: BaseEntity
    {
        TEntity GetByName(string name);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
