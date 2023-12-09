namespace ProyectoLourtec2023.GestionPedido.UI.Models.ViewModels
{
    public class ProveedorViewModel
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }
        public string? RazonSocial { get; set;}
        public string? Rif { get; set;}
        public string? Direccion { get; set;}

        public string? Telefonos { get; set;}

        public string? Correos { get; set;}
        public string? Contacto { get; set;}

        public int IdTipoProv {  get; set;}

        public bool Activo { get; set; }


    }
}
