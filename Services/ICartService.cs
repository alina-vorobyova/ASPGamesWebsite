using GamesSearchAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.Services
{
    public interface ICartService
    {
        public CartItem Item { get; set; }
        void Add(GameProduct gameProduct);
        void Remove(int id);
        void ClearCart();
        IEnumerable<CartItem> GetProducts();
    }
}
