using System;
using System.Collections.Generic;

namespace MyCompany.VistasWeb.Models;

public partial class TipoCli
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
