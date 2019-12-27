using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemImage { get; set; }
        public decimal ItemTotalPrice { get; set; }
        public int ItemCount { get; set; }

    }
}
