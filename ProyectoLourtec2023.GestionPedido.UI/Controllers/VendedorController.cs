using Microsoft.AspNetCore.Mvc;

using ProyectoLourtec2023.GestionPedido.Logic.Contracts;
using ProyectoLourtec2023.GestionPedido.Models;
using ProyectoLourtec2023.GestionPedido.UI.Models.ViewModels;
using System.Diagnostics.Contracts;

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
                Direccion = vn.Direccion,
                Telefono = vn.Telefono,
                Activo = vn.Activo == true,


            }).ToList();

            return View(listaVendedorViewModels);

        }
       
        //añadir
        public async Task<IActionResult> CrearVendedor()
        {
            VendedorViewModel vendedorViewModel = new VendedorViewModel()
            {
                Activo = false
            };
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
             ;
                return RedirectToAction("Index", "Vendedor");
            }
            else
            {
                Console.WriteLine("desde la vista",vendedor);
            }
            return View();
        }

        //editar
        public async Task<IActionResult> EditarVendedor( int id)
        {

          
            Task<Vendedor> _vendedor = _vendedorService.Obtener(id);
            VendedorViewModel vendedor = new VendedorViewModel()
            {
                Id = _vendedor.Result.Id,
                Nombre = _vendedor.Result.Nombre,
                Correo = _vendedor.Result.Correo,
                Direccion = _vendedor.Result.Direccion,
                Rif = _vendedor.Result.Rif,
                Telefono = _vendedor.Result.Telefono,
                Razon = _vendedor.Result.Razon,
                Activo = (bool)_vendedor.Result.Activo,


            };
            
            return View(vendedor);
        }

        [HttpPost]
        public async Task<IActionResult> EditarVendedor(VendedorViewModel vendedorViewModel, int id)
        {
            Vendedor vendedor = new Vendedor()
            {
                Id=vendedorViewModel.Id,
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