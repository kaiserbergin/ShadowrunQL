using GraphQL.Types;
using ShadowQL.GraphQL.Types;
using ShadowQL.Models;
using ShadowQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowQL.GraphQL.Queries
{
    public class ShadowRunQuery : ObjectGraphType
    {
        public ShadowRunQuery(PlayerRepository playerRepository)
        {
            Field<ListGraphType<PlayerType>>(
                "players",
                resolve: context => playerRepository.GetAll()
            );

            Field<PlayerType>(
                "player",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return playerRepository.GetPlayer(id);
                }
            );
        }
    }
}
