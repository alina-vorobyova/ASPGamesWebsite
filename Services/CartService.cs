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
        public CartItem Item { get; set; } = new CartItem();
        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
       
        public void Add(GameProduct gameProduct)
        {
          
            Item.ItemName = gameProduct.Title;
            Item.Id = gameProduct.Id;
            Item.ItemPrice = gameProduct.Price;
            Item.ItemImage = gameProduct.Image;
            var cartList = new List<CartItem>();
            cartList.Add(Item);
            
            httpContextAccessor.HttpContext.Session.Set<IEnumerable<CartItem>>("cart", cartList);
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
