using System.ComponentModel.DataAnnotations;

namespace ProyectoLourtec2023.GestionPedido.UI.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingresa el nombre del cliente")]
        public string? Nombre { get; set; }


        public string? Razon { get; set; }
        [Required(ErrorMessage = "Ingresa el número de cédula o RIF")]
        public string? Rif { get; set; }
        [Required(ErrorMessage = "Ingresa la dirección del cliente")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "Ingresa el correo electrónico")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingresa el número del cliente")]
        public string? Telefono { get; set; }

        public bool Activo { get; set; }

        public string? Notas { get; set; }
    }
}
