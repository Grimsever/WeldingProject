using Microsoft.Extensions.DependencyInjection;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.DAL.Models;

namespace WeldingAnalyz.Data.DI
{
    public static class DependencyRegister
    {

        public static void RegisterDataComponents(this IServiceCollection serviceCollection)
        {
           serviceCollection.AddSingleton<IRepository<Worker>, WorkerRepository>();

           serviceCollection.AddSingleton<IRepository<Foreman>, ForemanRepository>();
            
           serviceCollection.AddSingleton<IRepository<MachineData>, MachineDataRepository>();

           serviceCollection.AddSingleton<IRepository<Machine>, MachineRepository>();

           serviceCollection.AddSingleton<IRepository<TechnologicalMap>, TechnologicMapRepository>();

           serviceCollection.AddSingleton<IRepository<Task>, TaskRepository>();

        }
    }
}
