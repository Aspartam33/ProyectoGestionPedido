using System;
using System.Collections.Generic;

namespace ProyectoLourtec2023.GestionPedido.Models;

public partial class VentaD
{
    public int? Id { get; set; }

    public int? IdProd { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Costo { get; set; }

    public decimal? Precio { get; set; }

    public decimal? DescuentoP { get; set; }

    public decimal? DescuentoV { get; set; }

    public string? Total { get; set; }

    public virtual VentaE? IdNavigation { get; set; }
}
