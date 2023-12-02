using Microsoft.AspNetCore.Mvc;
using ProyectoLourtec2023.GestionPedido.Logic.Contracts;
using ProyectoLourtec2023.GestionPedido.Models;
using ProyectoLourtec2023.GestionPedido.UI.Models.ViewModels;

namespace ProyectoLourtec2023.GestionPedido.UI.Controllers
{
    public class VendedorController : Controller
    {
        private readonly IVendedorService _vendedorService;
        public VendedorController(IVendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }
        public async Task<IActionResult>Index(VendedorViewModel vendedorViewModel)
        {
            IQueryable<Vendedor> vendedorSql = await _vendedorService.ObtenerTodos();
            List<VendedorViewModel> listaVendedorViewModels = vendedorSql.Select(vn=> new VendedorViewModel()
            {
                Id = vn.Id,
                Nombre = vn.Nombre,
                Cedula = vn.Cedula,
                Correo = vn.Correo,
                Telefono = vn.Telefono,
                Activo = vn.Activo,

                
            }).ToList();

            return View(listaVendedorViewModels);
        }
    }
}
