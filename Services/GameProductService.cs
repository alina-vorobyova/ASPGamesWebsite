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

        public Task<GameProduct> GetGameByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
