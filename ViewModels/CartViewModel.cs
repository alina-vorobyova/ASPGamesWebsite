using GamesSearchAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public decimal Total { get; set; }
        public int Count { get; set; }
    }
}
