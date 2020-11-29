﻿using Microsoft.AspNetCore.Mvc;
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

        //Contrutor com argumentos
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            //Chamada para o SellerService, irá retornar uma lista de seller
            var list = _sellerService.FindAll();
            return View(list);
        }
    }
}
