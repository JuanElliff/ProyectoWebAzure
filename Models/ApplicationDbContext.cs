using Microsoft.EntityFrameworkCore;
using ProyectoWebAzure.Models;

// Asegúrate de que el namespace coincida con el nombre de tu proyecto.
// Si tu proyecto se llama "MiProyectoWebAzure", el namespace será MiProyectoWebAzure.Models
namespace MiProyectoWebAzure.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Esta línea crea una representación de la tabla "Productos" en la base de datos.
        // El nombre de la propiedad ("Productos") será el nombre de la tabla.
        public DbSet<Producto> Productos { get; set; }
    }

}