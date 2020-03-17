using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WeldingAnalyz.DAL.Interface;
using WeldingAnalyz.DAL.Models;

namespace WeldingAnalyz.Data.DI
{
    public static class DependencyRegister
    {

        public static void RegisterDataComponents(this IServiceCollection serviceCollection)
        {
          //  serviceCollection.AddSingleton<IRepository<ITEntity>, Repository<Worker>>();
        }
    }
}
