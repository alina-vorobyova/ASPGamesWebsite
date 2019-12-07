using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.Models
{
    public class GameProduct
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public GamePlatform GamePlatform { get; set; }
        public int GamePlatformId { get; set; }

    }
}
