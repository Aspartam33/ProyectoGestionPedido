using ProyectoLourtec2023.GestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLourtec2023.GestionPedido.Logic.Contracts
{
    public interface IClienteServices
    {
        Task<bool> Insertar(Cliente modelo);
        Task<bool> Actualizar(Cliente modelo);
        Task<bool> Eliminar(int id);
        Task<Cliente> Obtener(int id);
        Task<IQueryable<Cliente>> ObtenerTodos();
        Task<Cliente> ObtenerPorNombre(string nombreCliente);
    }
}
