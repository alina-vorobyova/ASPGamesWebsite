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

        public GameProductService(GameAppDbContext context)
        {
            this.context = context;
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
    }
}
