// Estas líneas 'using' son necesarias para que el código reconozca las clases que usamos.
using Microsoft.EntityFrameworkCore;
using MiProyectoWebAzure.Models;
using ProyectoWebAzure.Models; // Se asegura que el namespace del proyecto sea el correcto.

var builder = WebApplication.CreateBuilder(args);

// --- SECCIÓN DE CONFIGURACIÓN DE SERVICIOS ---

// 1. Lee la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registra el ApplicationDbContext como un servicio para la inyección de dependencias.
//    Esto permite que los controladores reciban una instancia de ApplicationDbContext
//    automáticamente para interactuar con la base de datos.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


// 3. Añade los servicios necesarios para el patrón MVC (Controladores y Vistas).
builder.Services.AddControllersWithViews();


// --- FIN DE LA SECCIÓN DE CONFIGURACIÓN ---


var app = builder.Build();

// --- SECCIÓN DE CONFIGURACIÓN DEL PIPELINE HTTP ---
// Define cómo la aplicación responderá a las peticiones web.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Habilita el uso de archivos estáticos como CSS, JavaScript, imágenes, etc.

app.UseRouting(); // Habilita el enrutamiento de peticiones a los controladores.

app.UseAuthorization();

// Define la ruta por defecto de la aplicación.
// Si no se especifica nada en la URL, se usará el controlador 'Home' y la acción 'Index'.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Inicia la aplicación.
