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
            var model = new CartViewModel {
                CartItems = productList,
                Count = cartService.Item.Count,
                Total = productList.Sum(x => x.ItemPrice)
            };
            return View(model);
        }

        public void AddToCart(GameProduct gameProduct)
        {
            if (gameProduct != null)
            {
                cartService.Item.Count++;
                cartService.Add(gameProduct);
            }
            
        }




    }
}