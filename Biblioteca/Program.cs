using Biblioteca.Context;
using Biblioteca.Repositories;
using Biblioteca.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddDbContext<AppDbContext>(options =>
                  options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                  new MySqlServerVersion(builder.Configuration.GetValue<string>("MySql:ServerVersion"))));

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<ICategoriaLivroRepository, CategoriaLivroRepositoryImpl>();


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