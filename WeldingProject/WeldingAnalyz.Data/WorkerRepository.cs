using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.DAL.Models;
using WeldingAnalyz.Data.Context;
using System.Linq;

namespace WeldingAnalyz.Data
{
    public class WorkerRepository: IRepository<Worker>
    {
        private readonly WeldingContext _context;
        private readonly DbSet<Worker> _entity;
        public WorkerRepository(WeldingContext context)
        {
            _context = context;
            _entity = context.Set<Worker>();
        }

        public Worker GetByName(string name)
        {
            if (name == "")
                throw new ArgumentNullException(nameof(name));

            return _entity.Include(x => x.Foreman)
                .Include(x => x.Task)
                .FirstOrDefault(x => x.Name == name);

        }

        public Worker GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return _entity.Include(x => x.Foreman)
                .Include(x => x.Task)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Worker> GetAll()
        {
            return _entity.Include(x => x.Foreman)
                .Include(x => x.Foreman).ToList();
        }

        public void Remove(Worker entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Remove(entity);

            _context.SaveChanges();
        }

        public void Update(Worker entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Update(entity);

            _context.SaveChanges();
        }
    }
}
