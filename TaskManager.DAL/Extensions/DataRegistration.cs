using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Extensions
{
    public static class DataRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            return services;
        }
    }
}
