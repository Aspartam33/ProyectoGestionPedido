using ProyectoLourtec2023.GestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLourtec2023.GestionPedido.Logic.Contracts
{
    public interface IVendedorService
    {
        
        Task<bool> Insertar(Vendedor modelo);
        Task<bool> Actualizar(Vendedor modelo);
        Task<bool> Eliminar(int id);
        Task<Vendedor> Obtener(int id);
        Task<IQueryable<Vendedor>> ObtenerTodos();
        Task<Vendedor> ObtenerPorNombre(string nombreVendedor);
    }
}
