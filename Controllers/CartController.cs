using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSearchAsp.Models;
using GamesSearchAsp.Services;
using GamesSearchAsp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesSearchAsp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            var productList = cartService.GetProducts();
            if (productList != null)
            {
                var model = new CartViewModel
                {
                    CartItems = productList,
                    Count = productList.Count(),
                    Total = productList.Sum(x => x.ItemPrice)
                };
                return View(model);
            }
            return View();
        }

        public void AddToCart(int id)
        {
            cartService.Add(id);
            
        }




    }
}