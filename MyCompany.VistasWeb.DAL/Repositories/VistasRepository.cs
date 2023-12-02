using MyCompany.VistasWeb.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.VistasWeb.Models;
using MyCompany.VistasWeb.DAL.DataContext;

namespace MyCompany.VistasWeb.DAL.Repositories
{
    public class VistasRepository : IGenericRepository<Cliente>
    {

        private readonly GestionPedidosContext _dbContext;

        public VistasRepository(GestionPedidosContext context)
        {
            _dbContext=context;
        }
        public async Task<bool> Actualizar(Cliente modelo)
        {
          _dbContext.Clientes.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Cliente modelo = _dbContext.Clientes.First(c => c.Id == id);
            _dbContext.Clientes.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Cliente modelo)
        {
           _dbContext.Clientes.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            IQueryable<Cliente> queryClienteSql = _dbContext.Clientes;
            return queryClienteSql;
        }
    }
}
