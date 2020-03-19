using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.DAL.Models;
using WeldingAnalyz.Data.Context;

namespace WeldingAnalyz.Data
{
    public class Repository<ITEntity> : IRepository<ITEntity> where ITEntity : BaseEntity
    {
        private readonly WeldingContext _context;
        private readonly DbSet<ITEntity> _entities;

        public Repository(WeldingContext context)
        {
            _context = context;
            _entities = context.Set<ITEntity>();
        }

        public ITEntity GetByName(string name)
        {
            return _entities.FirstOrDefault(x => x.Name == name);
        }

        public ITEntity GetById(int id)
        {
            return _entities.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ITEntity> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public void Remove(ITEntity entity)
        {
            if(entity==null)
                throw new ArgumentNullException(nameof(entity));
            _entities.Remove(entity);

            _context.SaveChanges();
        }

        public void Update(ITEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Update(entity);

            _context.SaveChanges();
        }

    }
}
