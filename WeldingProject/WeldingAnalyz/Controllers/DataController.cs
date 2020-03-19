using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.DAL.Models;
using Task = WeldingAnalyz.DAL.Models.Task;

namespace WeldingAnalyz.Controllers
{
    public class DataController : Controller
    {
        private readonly IRepository<Worker> _workerRepository;
        private readonly IRepository<Foreman> _foremanRepository;
        private readonly IRepository<MachineData> _machineDataRepository;
        private readonly IRepository<Machine> _machineRepository;
        private readonly IRepository<TechnologicalMap> _mapRepository;
        private readonly IRepository<Task> _taskRepository;

        public DataController(IRepository<Worker> workerRepository, IRepository<Foreman> foremanRepository,
            IRepository<MachineData> machineDataRepository, IRepository<Machine> machineRepository,
            IRepository<TechnologicalMap> mapRepository, IRepository<Task> taskRepository)
        {
            _workerRepository = workerRepository;
            _foremanRepository = foremanRepository;
            _machineDataRepository = machineDataRepository;
            _machineRepository = machineRepository;
            _mapRepository = mapRepository;
            _taskRepository = taskRepository;
        }


        [Route("~/api/GetWorkers")]
        [HttpGet]
        public ActionResult<IEnumerable<Worker>> GetWorkers()
        {
            List<Worker> workers = _workerRepository.GetAll().ToList();

            return workers.ToList();
        }

        [Route("~/api/GetMasters")]
        [HttpGet]
        public JsonResult GetMasters()
        {
            return Json(_foremanRepository.GetAll().ToList());
        }

        [HttpGet("machines")]
        public JsonResult GetMachines()
        {
            return Json(_machineRepository.GetAll().ToList());
        }


    }
}
