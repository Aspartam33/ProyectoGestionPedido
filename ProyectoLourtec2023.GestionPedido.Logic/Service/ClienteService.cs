using ProyectoLourtec2023.GestionPedido.DAL.Contracts;
using ProyectoLourtec2023.GestionPedido.Logic.Contracts;
using ProyectoLourtec2023.GestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLourtec2023.GestionPedido.Logic.Service
{
    public class ClienteService : IClienteServices
    {
        
        private readonly IGenericRepository<Cliente> _clienRepo;

        public ClienteService(IGenericRepository<Cliente> clienRepo)
        {
            _clienRepo = clienRepo;
        }
        public async Task<bool> Actualizar(Cliente modelo)
        {
            return await _clienRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _clienRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Cliente modelo)
        {
            return await _clienRepo.Insertar(modelo);
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _clienRepo.Obtener(id);
        }

        public async Task<Cliente> ObtenerPorNombre(string nombreCliente)
        {
            IQueryable<Cliente> queryClienteSql = await _clienRepo.ObtenerTodos();
            Cliente cliente = queryClienteSql.Where(c => c.Nombre == nombreCliente).FirstOrDefault();
            return cliente;
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            return await _clienRepo.ObtenerTodos();
        }
    }
}
