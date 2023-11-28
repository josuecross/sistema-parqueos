using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UIProyecto2v2.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServicioEmpleado, ServicioEmpleado>();

builder.Services.AddScoped<IServicioParqueo, ServicioParqueo>();

builder.Services.AddScoped<IServicioTiquete, ServicioTiquete>();

builder.Services.AddScoped<IServicioReportes, ServicioReportes>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
