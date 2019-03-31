using Microsoft.EntityFrameworkCore;
using ShadowQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowQL.Repositories
{
    public class CharacterRepository
    {
        private readonly ShadowRunContext shadowRunContext;

        public CharacterRepository(ShadowRunContext shadowRunContext)
        {
            this.shadowRunContext = shadowRunContext;
        }

        public async Task<IEnumerable<Character>> GetForPlayer(long playerId) => await shadowRunContext.Characters.Where(c => c.PlayerId == playerId).ToListAsync();

        public async Task<ILookup<long, Character>> GetForPlayers(IEnumerable<long> playerIds)
        {
            var players = await shadowRunContext.Characters.Where(c => playerIds.Contains(c.PlayerId)).ToListAsync();
            return players.ToLookup(x => x.PlayerId);
        }
    }
}
