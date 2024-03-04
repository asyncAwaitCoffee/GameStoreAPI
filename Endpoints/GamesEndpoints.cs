using GameStoreApi.Entities;
using GameStoreApi.Repositories;

namespace GameStoreApi.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndPoint = "GetGame";        
        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {
            InMemGameRepository repository = new InMemGameRepository();

            var group = routes.MapGroup("/games").WithParameterValidation();

            group.MapGet("/", () => repository.GetAll());
            group.MapGet("/{id:int}", (int id) =>
            {
                Game? game = repository.GetGame(id);
                return game is not null ? Results.Ok(game) : Results.NotFound();
            }).WithName(GetGameEndPoint);

            group.MapPost("/", (Game game) =>
            {
                repository.CreateGame(game);
                return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.Id }, game);
            });

            group.MapPut("/{id:int}", (int id, Game updatedGame) =>
            {
                Game? existingGame = repository.GetGame(id);

                if (existingGame == null)
                {
                    return Results.NotFound();
                }

                existingGame.Name = updatedGame.Name;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Price = updatedGame.Price;
                existingGame.ReleaseDate = updatedGame.ReleaseDate;
                existingGame.ImageURI = updatedGame.ImageURI;

                repository.UpdateGame(existingGame);

                return Results.NoContent();
            });

            group.MapDelete("/{id:int}", (int id) =>
            {
                Game? existingGame = repository.GetGame(id);

                if (existingGame != null)
                {
                    repository.DeleteGame(id);
                }

                return Results.NoContent();
            });


            return group;
        }
    }
}
