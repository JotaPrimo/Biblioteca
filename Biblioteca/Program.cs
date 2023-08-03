using Biblioteca.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
          options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
          new MySqlServerVersion(builder.Configuration.GetValue<string>("MySql:ServerVersion"))));

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// rotas de categoria_livro
app.MapControllerRoute(
    name: "categoriaLivro",
    pattern: "Categoria-Livro/{action}/{id?}",
    defaults: new { Controller = "CategoriaLivro", action = "List" });

app.Run();
