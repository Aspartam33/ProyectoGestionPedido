using Microsoft.AspNetCore.Mvc;
using MyCompany.VistasWeb.Logic.Contracts;
using MyCompany.VistasWeb.Models;
using MyCompany.VistasWeb.UI.Models;
using MyCompany.VistasWeb.UI.Models.ViewModels;
using System.Diagnostics;
using System.Globalization;

namespace MyCompany.VistasWeb.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;

        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }
        public async Task<IActionResult> Index(ClienteViewModel clienteViewModel)
        {
            IQueryable<Cliente> queryClienteSQL = await _clienteServices.ObtenerTodos();

            List<ClienteViewModel> LstclienteViewModel = queryClienteSQL
                                                      .Select(c => new ClienteViewModel()
                                                      {
                                                          Id = c.Id,
                                                          Nombre = c.Nombre,
                                                          Razon = c.Razon,
                                                          Rif = c.Rif,
                                                          Direccion = c.Direccion,
                                                          Correo = c.Correo,
                                                          Telefono = c.Telefono,
                                                          //Activo = c.Activo.To,
                                                          Notas = c.Notas
                                                      }).ToList();
            return View(LstclienteViewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(ClienteViewModel clienteViewModel)
        {
            Cliente cliente = new Cliente()
            {
                //Id= clienteViewModel.Id,
                Nombre = clienteViewModel.Nombre,
                Razon = clienteViewModel.Razon,
                Rif = clienteViewModel.Rif,
                Direccion = clienteViewModel.Direccion,
                Correo = clienteViewModel.Correo,
                Telefono = clienteViewModel.Telefono,
                Activo = clienteViewModel.Activo,
                Notas = clienteViewModel.Notas
            };

            if(ModelState.IsValid)
            {
                bool respuesta=await _clienteServices.Insertar(cliente);
                return RedirectToAction("Index", "Cliente");
            }
            return View();
        }

        public async Task<IActionResult>Edit(int id)
        {
            Task<Cliente> _cliente = _clienteServices.Obtener(id);

            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                Id= _cliente.Result.Id,
                Nombre=_cliente.Result.Nombre,
                Razon=_cliente.Result.Razon,
                Rif= _cliente.Result.Rif,
                Direccion=_cliente.Result.Direccion,
                Correo= _cliente.Result.Correo,
                Telefono= _cliente.Result.Telefono,
                //Activo=_cliente.Result.Activo,
                Notas= _cliente.Result.Notas
            };
            return View(clienteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(ClienteViewModel clienteViewModel)
        {
            Cliente cliente = new Cliente()
            {
                Id = clienteViewModel.Id,
                Nombre = clienteViewModel.Nombre,
                Razon = clienteViewModel.Razon,
                Rif = clienteViewModel.Rif,
                Direccion= clienteViewModel.Direccion,
                Correo= clienteViewModel.Correo,
                Telefono = clienteViewModel.Telefono,
                //Activo= clienteViewModel.Activo,
                Notas= clienteViewModel.Notas
            };
            if(ModelState.IsValid)
            {
                bool respuesta=await _clienteServices.Actualizar(cliente);
                return RedirectToAction("Index","Cliente");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            Task<Cliente> _cliente = _clienteServices.Obtener(id);

            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                Id = _cliente.Result.Id,
                Nombre = _cliente.Result.Nombre,
                Razon = _cliente.Result.Razon,
                Rif = _cliente.Result.Rif,
                Direccion = _cliente.Result.Direccion,
                Correo = _cliente.Result.Correo,
                Telefono = _cliente.Result.Telefono,
                //Activo = _cliente.Result.Activo,
                Notas = _cliente.Result.Notas
            };
            return View(clienteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                bool respuesta=await _clienteServices.Eliminar(id);
                return RedirectToAction("Index", "Cliente");
            }

            return View();
        }
    }
}
