using GD.SysProductos.DAL;
using Microsoft.EntityFrameworkCore;
using GD.SysProductos.BL;
using Microsoft.AspNetCore.Authentication.Cookies;
using OfficeOpenXml; //agregar using para acceder al AddDbContext y UseMySql
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Agregar el contexto de la base de datos SysLogingDBContexte al contenedor de servicios de la aplicacion.
builder.Services.AddDbContext<SysProductosDBContext>(options =>
{
    // Obtiene la cadena de conexio?n desde el archivo de configuracio?n  (Appsettings.json).
    var conexionString = builder.Configuration.GetConnectionString("Conn");
    // Configura Entity Framework Core para usar MySQL  como proveedor de base de datos ,
    // detectado automaticamente la versio?n del servidor .
    options.UseMySql(conexionString, ServerVersion.AutoDetect(conexionString));
});
builder.Services.AddScoped<ProductosDAL>(); // definir ciclo de vida Scoped, es decir que una nueva instancia de RolDAL se creara? por cada solicitud HTTP
builder.Services.AddScoped<ProductosBL>(); // Al depender de ProductosDAL, esta tambie?n recibira? la misma instancia de ProductosDAL en una solicitud HTTP.

builder.Services.AddScoped<ProveedorDAL>();
builder.Services.AddScoped<ProveedorBL>();

builder.Services.AddScoped<UsuarioDAL>();
builder.Services.AddScoped<UsuarioBL>();
builder.Services.AddScoped<CompraDAL>();
builder.Services.AddScoped<CompraBL>();
builder.Services.AddScoped<VentaDAL>();
builder.Services.AddScoped<VentaBL>();
builder.Services.AddScoped<ClienteDAL>();
builder.Services.AddScoped<ClienteBL>();

builder.Services.AddControllersWithViews();
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../wwwroot/Rotativa");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
