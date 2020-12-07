using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        //Dependencia para SellerService
        private readonly SellerService _sellerService;

        //Dependencia para DepartmentService
        private readonly DepartmentService _departmentService;

        //Contrutor com argumentos
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            //Chamada para o SellerService, irá retornar uma lista de seller
            var list = _sellerService.FindAll();
            return View(list);
        }

        //Create vendedor
        public IActionResult Create()
        {
            //Carregar os departamentos do banco de dados
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        
        [HttpPost] //Indicando que é POST
        [ValidateAntiForgeryToken] //Token formulario
        //Create vendedor salvar no banco de dados
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);

            //Redicionar para o index
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            //Verificar se o id é nulo
            if (id == null)
            {
                return NotFound();
            }

            //Buscar o objeto, se for nulo dar NotFound
            var obj = _sellerService.FindById(id.Value);
            if (id == null)
            {
                return NotFound();
            }

            //Retornar o objeto
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            //Verificar se o id é nulo
            if (id == null)
            {
                return NotFound();
            }

            //Buscar o objeto, se for nulo dar NotFound
            var obj = _sellerService.FindById(id.Value);
            if (id == null)
            {
                return NotFound();
            }

            //Retornar o objeto
            return View(obj);
        }
    }
}
