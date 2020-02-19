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
                    Total = productList.Sum(x => x.ItemPrice * x.ItemCount)
                };
                return View(model);
            }
            return View();
        }

        public IActionResult AddToCart(int id)
        {
            cartService.Add(id);
            return RedirectToAction("Shop", "Home");
        }

        public IActionResult RemoveFromCart(int id)
        {
            cartService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            cartService.ClearCart();
            return RedirectToAction("Index");
        }


    }
}