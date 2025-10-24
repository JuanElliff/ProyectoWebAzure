using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Este namespace debe coincidir con la carpeta y el nombre del proyecto.
namespace ProyectoWebAzure.Models
{
    /// <summary>
    /// Representa un producto en la base de datos.
    /// Cada propiedad de esta clase se convertirá en una columna en la tabla 'Productos'.
    /// </summary>
    public class Producto
    {
        // El atributo [Key] designa esta propiedad como la clave primaria de la tabla.
        [Key]
        public int Id { get; set; }

        // El atributo [Required] asegura que esta columna no puede ser nula.
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100)] // Define una longitud máxima para la cadena.
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        // El atributo [Column] permite especificar detalles exactos del tipo de dato en SQL.
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }

        // Establece la fecha y hora actual (en UTC) como valor por defecto al crear un nuevo producto.
        public DateTime FechaDeAlta { get; set; } = DateTime.UtcNow;
    }
}
