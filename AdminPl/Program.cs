using AdminPl.Helper;
using BLL;
using BLL.Interfaces;
using BLL.Repositories;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace AdminPl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(
               options =>
               {
                   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
               }); //register
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IAdminUnitOfWork, AdminUnitOfWork>();
            builder.Services.AddScoped(typeof(IBaseGetRepository<>), typeof(BaseGetRepository<>));
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IBaseGetUnitOfWork<,>), typeof(BaseGetUnitOfWork<,>));
            builder.Services.AddScoped(typeof(IBaseUnitOfWork<,>), typeof(BaseUnitOfWork<,>));
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
