using GraphQL.DataLoader;
using GraphQL.Types;
using ShadowQL.Models;
using ShadowQL.Repositories;

namespace ShadowQL.GraphQL.Types
{
    public class PlayerType: ObjectGraphType<Player>
    {
        public PlayerType(
            CharacterRepository characterRepository,
            IDataLoaderContextAccessor dataLoaderAccessor    
        )
        {
            Field(t => t.Id);
            Field(t => t.FirstName).Description("Player's First Name");
            Field(t => t.LastName).Description("Player's Last Name");

            Field<ListGraphType<CharacterType>>(
                "characters",
                resolve: context => {
                    // N+1 Issue:
                    //return characterRepository.GetForPlayer(context.Source.Id);

                    // Chached data Loader:
                    var loader = dataLoaderAccessor
                        .Context
                        .GetOrAddCollectionBatchLoader<long, Character>("GetCharactersByPlayerId", characterRepository.GetForPlayers);

                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}
