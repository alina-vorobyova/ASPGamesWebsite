using GamesSearchAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.ViewModels
{
    public class ShopGameDetailsViewModel
    {
        public GameProduct GameFromDb { get; set; }
        public GameDetailsApiResponse Game { get; set; }
        public IEnumerable<GameProduct> SimilarGames { get; set; }
        public ScreenshotsApiResponse Screenshots { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public Review Review { get; set; }
        public int ReviewCount { get; set; }
    }
}
