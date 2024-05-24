using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProjetoEstacionamentoFaculdade.Models.Contexto;
using ProjetoEstacionamentoFaculdade.Models.Interface;
using ProjetoEstacionamentoFaculdade.Models.Repositorio;

namespace ProjetoEstacionamentoFaculdade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectioString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SistemaEstacionamentoDbContext>(
              options => options.UseMySql(connectioString, ServerVersion.AutoDetect(connectioString))
            );

            builder.Services.AddScoped<ICadastroRepositorio, CadastroRepositorio>();
            builder.Services.AddScoped<ILoginRepositorio, LoginRepositorio>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie();
            
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Login/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}