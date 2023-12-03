
using ProyectoLourtec2023.GestionPedido.Logic.Contracts;
using ProyectoLourtec2023.GestionPedido.Models;
using ProyectoLourtec2023.GestionPedido.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLourtec2023.GestionPedido.Logic.Service
{
    public class VendedorService:IVendedorService
    { 
        private readonly DAL.Contracts.IGenericRepository<Vendedor> _vendeRepo;
        public VendedorService(DAL.Contracts.IGenericRepository<Vendedor> vendeRepo )
        {
            _vendeRepo = vendeRepo;
        }
        public async Task<bool> Actualizar(Vendedor modelo)
        {
            return await _vendeRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _vendeRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Vendedor modelo)
        {
            return await _vendeRepo.Insertar(modelo);
        }

        public async Task<Vendedor> Obtener(int id)
        {
            return await _vendeRepo.Obtener(id);
        }

        public async Task<Vendedor> ObtenerPorNombre(string nombreVendedor)
        {
            IQueryable<Vendedor> queryVendedorSql = await _vendeRepo.ObtenerTodos();
            Vendedor vendedor = queryVendedorSql.Where(vn => vn.Nombre == nombreVendedor).FirstOrDefault();
            return vendedor;
        }

        public async Task<IQueryable<Vendedor>> ObtenerTodos()
        {
            return await _vendeRepo.ObtenerTodos();
        }
    }

    
}
