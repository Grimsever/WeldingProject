using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.DAL.Models;
using WeldingAnalyz.Data.Context;

namespace WeldingAnalyz.Data
{
    public class TechnologicMapRepository : IRepository<TechnologicalMap>
    {
        private readonly WeldingContext _context;
        private readonly DbSet<TechnologicalMap> _entity;
        public TechnologicMapRepository(WeldingContext context)
        {
            _context = context;
            _entity = context.Set<TechnologicalMap>();
        }

        public IEnumerable<TechnologicalMap> GetAll()
        {
            return _entity.Include(x => x.Task).ToList();
        }
        public TechnologicalMap GetByName(string name)
        {
            if (name == "")
                throw new ArgumentNullException(nameof(name));

            return _entity.Include(x => x.Task).FirstOrDefault(x => x.Name == name);
        }

        public TechnologicalMap GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return _entity.Include(x => x.Task).FirstOrDefault(x => x.Id == id);
        }


        public void Remove(TechnologicalMap entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Remove(entity);

            _context.SaveChanges();
        }

        public void Update(TechnologicalMap entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Update(entity);

            _context.SaveChanges();
        }
    }
}
