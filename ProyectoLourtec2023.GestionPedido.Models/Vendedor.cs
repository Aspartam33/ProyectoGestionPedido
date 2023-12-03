using System;
using System.Collections.Generic;

namespace ProyectoLourtec2023.GestionPedido.Models;

public partial class Vendedor
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Razon { get; set; }

    public string? Rif { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<VentaE> VentaEs { get; set; } = new List<VentaE>();
}
