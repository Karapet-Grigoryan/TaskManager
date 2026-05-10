using Microsoft.EntityFrameworkCore;
using TaskManager.BLL.Extensions;
using TaskManager.DAL.Extensions;
using TaskManager.DAL.TaskManagerModel;

namespace TaskManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TaskManagerContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDataServices();
            builder.Services.AddBusinessLogicLayerService();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Task}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
