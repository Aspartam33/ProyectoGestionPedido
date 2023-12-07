using Microsoft.EntityFrameworkCore;
using MyCompany.VistasWeb.DAL.Contracts;
using MyCompany.VistasWeb.DAL.DataContext;
using MyCompany.VistasWeb.DAL.Repositories;
using MyCompany.VistasWeb.Logic.Contracts;
using MyCompany.VistasWeb.Logic.Service;
using MyCompany.VistasWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IGenericRepository<Cliente>, VistasRepository>();
builder.Services.AddScoped<IClienteServices, ClienteService>();

builder.Services.AddDbContext<GestionPedidosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});

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
