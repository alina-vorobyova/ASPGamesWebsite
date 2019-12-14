using GamesSearchAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSearchAsp.Services
{
    public interface IGameProductService
    {
        Task<IEnumerable<GameProduct>> GetAllGameProductsAsync();

        Task<GameProduct> GetGameByIdAsync(int id);
        Task<IEnumerable<GameProduct>> GetSimilarGamesFromDb(int id);
    }
}
