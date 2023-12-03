using Microsoft.EntityFrameworkCore;
using ProyectoLourtec2023.GestionPedido.DAL.Contracts;
using ProyectoLourtec2023.GestionPedido.DAL.DataContext;
using ProyectoLourtec2023.GestionPedido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLourtec2023.GestionPedido.DAL.Repositories
{
    public class VendedorRepository : IGenericRepository<Vendedor>
    {
        private readonly GestionPedidosContext _dbContxt;
        public VendedorRepository(GestionPedidosContext dbCntxt)
        {
            _dbContxt = dbCntxt;
        }
        public async Task<bool> Actualizar(Vendedor modelo)
        {
            _dbContxt.Vendedors.Update(modelo);
            _dbContxt.SaveChanges();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Vendedor modelo = _dbContxt.Vendedors.First(v => v.Id == id);
            _dbContxt.Vendedors.Remove(modelo);
            _dbContxt.SaveChanges();
            return true;
        }

        public async Task<bool> Insertar(Vendedor modelo)
        {
            _dbContxt.Vendedors.Add(modelo);
            _dbContxt.SaveChanges();
            return true;
        }

        public async Task<Vendedor> Obtener(int id)
        {
            return await _dbContxt.Vendedors.FindAsync(id);
        }

        public async Task<IQueryable<Vendedor>> ObtenerTodos()
        {
            IQueryable<Vendedor> queryVendedorSql = _dbContxt.Vendedors;
            return queryVendedorSql;
        }
    }
}
