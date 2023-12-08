using ProyectoLourtec2023.GestionPedido.DAL.DataContext;
using ProyectoLourtec2023.GestionPedido.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLourtec2023.GestionPedido.UI.Models.ViewModels
{
    public class VendedorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingresa el nombre del usuario")]
        public string? Nombre { get; set; }

        public string? Razon { get; set; }
        [Required(ErrorMessage = "Ingresa el número de cédula")]
        public string? Rif { get; set; }
        [Required(ErrorMessage = "Ingresa la dirección del usuario")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "Ingresa el correo electrónico")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingresa el campo teléfono está vacío")]
        public string? Telefono { get; set; }

        public bool Activo { get; set; }

        

        public virtual ICollection<VentaE> VentaEs { get; set; } = new List<VentaE>();
    }
}
