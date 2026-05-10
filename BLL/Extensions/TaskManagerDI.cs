using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.Extensions
{
    public static class TaskManagerDI
    {
        public static IServiceCollection AddBusinessLogicLayerService(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
