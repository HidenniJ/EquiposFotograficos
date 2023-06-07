using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using EquiposFotograficos.Data;
using EquiposFotograficos.Data.Context;
using EquiposFotograficos.Data.Services;
using EquiposFotograficos.Data.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<EquiposFotograficoDbContext>(); //se utiliza para registrar el contexto de la base de dato
builder.Services.AddScoped<IEquiposFotograficoDbContext, EquiposFotograficoDbContext>();//se utiliza para registrar el contexto de la base de dato es como servicio con el tipo de interfaz
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IEmpleadoServices, EmpleadoServices >();
builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<IVentaServices, VentaServices>();
builder.Services.AddScoped<IProveedorServices,ProveedorServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
