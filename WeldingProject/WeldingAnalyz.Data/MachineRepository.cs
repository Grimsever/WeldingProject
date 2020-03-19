using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.Data.Context;
using Machine = WeldingAnalyz.DAL.Models.Machine;

namespace WeldingAnalyz.Data
{
    public class MachineRepository : IRepository<Machine>
    {
        private readonly WeldingContext _context;
        private readonly DbSet<Machine> _entity;
        public MachineRepository(WeldingContext context)
        {
            _context = context;
            _entity = context.Set<Machine>();
        }

        public IEnumerable<Machine> GetAll()
        {
            return _entity.Include(x => x.Task)
                .Include(x => x.MachineData).ToList();
        }
        public Machine GetByName(string name)
        {
            if (name == "")
                throw new ArgumentNullException(nameof(name));

            return _entity.Include(x => x.Task)
                .Include(x => x.MachineData).FirstOrDefault(x => x.Name == name);
        }

        public Machine GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return _entity.Include(x => x.Task)
                .Include(x => x.MachineData).FirstOrDefault(x => x.Id == id);
        }


        public void Remove(Machine entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Remove(entity);

            _context.SaveChanges();
        }

        public void Update(Machine entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Update(entity);

            _context.SaveChanges();
        }
    }
}
