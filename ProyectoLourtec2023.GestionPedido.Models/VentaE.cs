using System;
using System.Collections.Generic;

namespace ProyectoLourtec2023.GestionPedido.Models;

public partial class VentaE
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Documento { get; set; }

    public int? IdCliente { get; set; }

    public int? IdAlmacen { get; set; }

    public int? IdVendedor { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? Total { get; set; }

    public string? Notas { get; set; }

    public virtual Vendedor? IdVendedorNavigation { get; set; }
}
