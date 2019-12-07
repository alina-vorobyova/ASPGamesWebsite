using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.Models
{
    public class GamePlatform
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
        public IEnumerable<GameProduct> GameProducts { get; set; }
    }
}
