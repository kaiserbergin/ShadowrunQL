using GraphQL.Types;
using ShadowQL.Models;
using ShadowQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowQL.GraphQL.Types
{
    public class PlayerType: ObjectGraphType<Player>
    {
        public PlayerType(PlayerRepository playerRepository, CharacterRepository characterRepository)
        {
            Field(t => t.Id);
            Field(t => t.FirstName).Description("Player's First Name");
            Field(t => t.LastName).Description("Player's Last Name");

            Field<ListGraphType<CharacterType>>(
                "characters",
                resolve: context => characterRepository.GetForPlayer(context.Source.Id)
            );
        }
    }
}
