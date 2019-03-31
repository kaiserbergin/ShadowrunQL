using Microsoft.EntityFrameworkCore;
using ShadowQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowQL.Repositories
{
    public class PlayerRepository
    {
        private readonly ShadowRunContext _dbContext;

        public PlayerRepository(ShadowRunContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _dbContext.Players.ToListAsync();
        }

        public async Task<Player> GetPlayer(long id)
        {
            return await _dbContext.Players.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
