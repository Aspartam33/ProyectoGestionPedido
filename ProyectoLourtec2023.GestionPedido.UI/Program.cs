using Microsoft.EntityFrameworkCore;
using ProyectoLourtec2023.GestionPedido.DAL.Contracts;
using ProyectoLourtec2023.GestionPedido.DAL.DataContext;
using ProyectoLourtec2023.GestionPedido.DAL.Repositories;
using ProyectoLourtec2023.GestionPedido.Logic.Contracts;
using ProyectoLourtec2023.GestionPedido.Logic.Service;
using ProyectoLourtec2023.GestionPedido.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGenericRepository<Cliente>, VistasRepository>();
builder.Services.AddScoped<IClienteServices, ClienteService>();
builder.Services.AddScoped<IGenericRepository<Vendedor>, VendedorRepository>();
builder.Services.AddScoped<IVendedorService,VendedorService>();

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
