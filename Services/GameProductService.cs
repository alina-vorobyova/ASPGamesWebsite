using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSearchAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesSearchAsp.Services
{
    public class GameProductService : IGameProductService
    {
        private readonly GameAppDbContext context;
        private readonly IGameSearchService gameSearchService;

        public GameProductService(GameAppDbContext context, IGameSearchService gameSearchService)
        {
            this.context = context;
            this.gameSearchService = gameSearchService;
        }

        public async Task<IEnumerable<GameProduct>> GetAllGameProductsAsync()
        {
            return await context.GameProducts.Include(x => x.GamePlatform).ToListAsync();
        }

        public async Task<GameProduct> GetGameByIdAsync(int id)
        {
            var game = await context.GameProducts.Include(x => x.GamePlatform).FirstOrDefaultAsync(x => x.Id == id);
            if (game != null)
            {
                return game;
            }
            throw new Exception("Game not found");
        }

        public async Task<IEnumerable<GameProduct>> GetSimilarGamesFromDb(int id)
        {
            var similarGamesFromApi = await gameSearchService.SearchSimilarGamesAsync(id);
            var simirlarGamesFromDb = new List<GameProduct>();
            foreach (var item in similarGamesFromApi.results)
            {
                var foundGames = await context.GameProducts.Include(x => x.GamePlatform).FirstOrDefaultAsync(x => x.GameId == item.id);
                if (foundGames != null)
                {
                    simirlarGamesFromDb.Add(foundGames);
                }
            }
            return simirlarGamesFromDb;

        }
       
    }
}
