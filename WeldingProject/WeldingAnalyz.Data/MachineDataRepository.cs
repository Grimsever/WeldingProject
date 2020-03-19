using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.DAL.Models;
using WeldingAnalyz.Data.Context;

namespace WeldingAnalyz.Data
{
    public class MachineDataRepository : IRepository<MachineData>
    {
        private readonly WeldingContext _context;
        private readonly DbSet<MachineData> _entity;
        public MachineDataRepository(WeldingContext context)
        {
            _context = context;
            _entity = context.Set<MachineData>();
        }

        public IEnumerable<MachineData> GetAll()
        {
            return _entity.Include(x => x.Machine)
                .Include(x => x.Amperages)
                .Include(x => x.Voltages).ToList();
        }
        public MachineData GetByName(string name)
        {
            if (name == "")
                throw new ArgumentNullException(nameof(name));

            return _entity.Include(x => x.Machine)
                .Include(x => x.Amperages)
                .Include(x => x.Voltages).FirstOrDefault(x => x.Name == name);
        }

        public MachineData GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return _entity.Include(x => x.Machine)
                 .Include(x => x.Amperages)
                 .Include(x => x.Voltages).FirstOrDefault(x => x.Id == id);
        }


        public void Remove(MachineData entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Remove(entity);

            _context.SaveChanges();
        }

        public void Update(MachineData entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Update(entity);

            _context.SaveChanges();
        }
    }
}
