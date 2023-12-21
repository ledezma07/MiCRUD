
using QuestPDF.Infrastructure;


using CRUD.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

QuestPDF.Settings.License = LicenseType.Community; //Para activar la licencia de los reportes
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

//ASqui la sub cadena parala conexion
builder.Services.AddDbContext<MiContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion"));
});

//Fin dela cadena

//Agreganmos para no regresar en las vista despues de cerrar sesion
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
    new ResponseCacheAttribute
    {
        NoStore = true,
        Location = ResponseCacheLocation.None,
    }
    );
});
//Fin de la regrecion de vistas al cerrar session




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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
