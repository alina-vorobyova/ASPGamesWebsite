using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSearchAsp.Models;
using Microsoft.AspNetCore.Http;
using GamesSearchAsp.Extensions;

namespace GamesSearchAsp.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly GameAppDbContext context;

        //public CartItem Item { get; set; } = new CartItem();
        List<CartItem> CartList { get; set; } = new List<CartItem>();
        public CartService(IHttpContextAccessor httpContextAccessor, GameAppDbContext context)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.context = context;
        }
       
        public void Add(int id)
        {
            var gameProduct = context.GameProducts.Find(id);
            CartItem Item = new CartItem();
            if (gameProduct != null)
            {
                Item.ItemName = gameProduct.Title; 
                Item.Id = gameProduct.Id;
                Item.ItemPrice = gameProduct.Price;
                Item.ItemImage = gameProduct.Image;
                Item.ItemCount++;
               
                CartList.Add(Item);
                if (httpContextAccessor.HttpContext.Session.Keys.Contains("cart"))
                {
                    var productList = httpContextAccessor.HttpContext.Session.Get<IEnumerable<CartItem>>("cart").ToList();
                    if (productList.Any(x => x.Id == Item.Id))
                    {
                        var sameGame = productList.FirstOrDefault(x => x.Id == Item.Id);
                        sameGame.ItemCount++;
                    }
                    else
                    {
                        productList.Add(Item);
                    }
                    httpContextAccessor.HttpContext.Session.Set<IEnumerable<CartItem>>("cart", productList);
                }
                else
                {
                    httpContextAccessor.HttpContext.Session.Set<IEnumerable<CartItem>>("cart", CartList);
                }
            }
            
        }

        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetProducts()
        {
            var productList = httpContextAccessor.HttpContext.Session.Get<IEnumerable<CartItem>>("cart");
            return productList;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
