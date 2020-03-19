using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.DAL.Models;
using WeldingAnalyz.Data.Context;

namespace WeldingAnalyz.Data
{
    public class ForemanRepository : IRepository<Foreman>
    {
        private readonly WeldingContext _context;
        private readonly DbSet<Foreman> _entity;

        public ForemanRepository(WeldingContext context)
        {
            _context = context;
            _entity = context.Set<Foreman>();
        }

        public Foreman GetByName(string name)
        {
            if (name == "")
                throw new ArgumentNullException(nameof(name));

            return _entity.Include(x => x.Workers).FirstOrDefault(x => x.Name == name);
        }

        public Foreman GetById(int id)
        {
            if(id <= 0)
                throw new ArgumentNullException(nameof(id));

            return _entity.Include(x => x.Workers).FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<Foreman> GetAll()
        {
            return _entity.Include(x => x.Workers).ToList();
        }

        public void Remove(Foreman entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Remove(entity);

            _context.SaveChanges();
        }

        public void Update(Foreman entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Update(entity);

            _context.SaveChanges();

        }
    }
}
