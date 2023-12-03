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
        public async Task<IActionResult> Index(VendedorViewModel vendedorViewModel)
        {
            IQueryable<Vendedor> vendedorSql = await _vendedorService.ObtenerTodos();
            List<VendedorViewModel> listaVendedorViewModels = vendedorSql.Select(vn => new VendedorViewModel()
            {
                Id = vn.Id,
                Nombre = vn.Nombre,
                Rif = vn.Rif,
                Correo = vn.Correo,
                Telefono = vn.Telefono,
                Activo = vn.Activo,


            }).ToList();

            return View(listaVendedorViewModels);

        }

        //añadir
        public async Task<IActionResult> CrearVendedor()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreaVendedor(VendedorViewModel vendedorViewModel)
        {
            Vendedor vendedor = new Vendedor()
            {

                Nombre = vendedorViewModel.Nombre,
                Correo = vendedorViewModel.Correo,
                Direccion = vendedorViewModel.Direccion,
                Rif = vendedorViewModel.Rif,
                Telefono = vendedorViewModel.Telefono,
                Razon = vendedorViewModel.Razon,
                Activo = vendedorViewModel.Activo,


            };
            if (ModelState.IsValid)
            {
                var respuesta = await _vendedorService.Insertar(vendedor);
                return RedirectToAction("Index", "Vendedor");
            }
            return View();
        }

        //editar
        public async Task<IActionResult> EditarVendedor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditarVendedor(VendedorViewModel vendedorViewModel)
        {
            Vendedor vendedor = new Vendedor()
            {

                Nombre = vendedorViewModel.Nombre,
                Correo = vendedorViewModel.Correo,
                Direccion = vendedorViewModel.Direccion,
                Rif = vendedorViewModel.Rif,
                Telefono = vendedorViewModel.Telefono,
                Razon = vendedorViewModel.Razon,
                Activo = vendedorViewModel.Activo,


            };
            if (ModelState.IsValid)
            {
                var respuesta = _vendedorService.Actualizar(vendedor);
                return RedirectToAction("Index", "Vendedor");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, VendedorViewModel vendedorViewModel)
        {
            if (ModelState.IsValid)
            {
                bool respuesta = await _vendedorService.Eliminar(id);
                return RedirectToAction("Index", "Vendedor");
            }
            return View();
        }
    }
}