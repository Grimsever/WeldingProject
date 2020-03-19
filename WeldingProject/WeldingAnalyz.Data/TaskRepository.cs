using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.DAL.Models;
using WeldingAnalyz.Data.Context;

namespace WeldingAnalyz.Data
{
    public class TaskRepository : IRepository<Task>
    {
        private readonly WeldingContext _context;
        private readonly DbSet<Task> _entity;

        public TaskRepository(WeldingContext context)
        {
            _context = context;
            _entity = context.Set<Task>();
        }

        public IEnumerable<Task> GetAll()
        {
            return _entity.Include(x => x.Machine)
                .Include(x => x.TechnologicalMap)
                .Include(x => x.Worker).ToList();
        }

        public Task GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return _entity.Include(x => x.Machine)
                .Include(x => x.TechnologicalMap)
                .Include(x => x.Worker)
                .FirstOrDefault(x => x.Id == id);
        }

        public Task GetByName(string name)
        {
            if (name == "")
                throw new ArgumentNullException(nameof(name));

            return _entity.Include(x => x.Machine)
                .Include(x => x.TechnologicalMap)
                .Include(x => x.Worker)
                .FirstOrDefault(x => x.Name == name);
        }

        public void Remove(Task entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Remove(entity);

            _context.SaveChanges();
        }

        public void Update(Task entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Update(entity);
            _context.SaveChanges();
        }
    }
}
