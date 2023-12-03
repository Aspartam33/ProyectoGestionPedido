using ProyectoLourtec2023.GestionPedido.DAL.DataContext;
using ProyectoLourtec2023.GestionPedido.Models;

namespace ProyectoLourtec2023.GestionPedido.UI.Models.ViewModels
{
    public class VendedorViewModel
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Razon { get; set; }

        public string? Rif { get; set; }

        public string? Direccion { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public bool Activo { get; set; }

        

        public virtual ICollection<VentaE> VentaEs { get; set; } = new List<VentaE>();
    }
}
