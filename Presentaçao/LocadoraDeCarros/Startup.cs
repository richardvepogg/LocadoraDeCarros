using LocadoraDeCarros.Middlewares;
using AutoMapper;
using Negocio.RepositorioDados;
using Dados.Repositorio;
using Negocio.ServiçoNegocio.Base;
using Negocio.ServiçoNegocio;
using Dados.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddDbContext<LocadoraDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });

            // Add services to the container.
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IClienteServico, ClienteServico>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            { 
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            //custom middleware
            app.UseMiddleware<FriendListMiddleware>(Configuration["SafeList"]);

            app.UseEndpoints(endpoints =>
            {
                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }

    }

}
