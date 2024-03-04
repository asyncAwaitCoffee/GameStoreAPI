using GameStoreApi.Entities;
using GameStoreApi.Repositories;

namespace GameStoreApi.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndPoint = "GetGame";        
        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/games").WithParameterValidation();

            // Get all games
            group.MapGet("/", (IGameRepository repository) => repository.GetAll().Select(g => g.AsDTO()));

            // Get game by id
            group.MapGet("/{id:int}", (IGameRepository repository, int id) =>
            {
                Game? game = repository.GetGame(id);
                return game is not null ? Results.Ok(game.AsDTO()) : Results.NotFound();
            }).WithName(GetGameEndPoint);

            // Add new game
            group.MapPost("/", (IGameRepository repository, CreateGameDTO gameDTO) =>
            {
                Game game = new () {
                    Name = gameDTO.Name,
                    Genre = gameDTO.Genre,
                    Price = gameDTO.Price,
                    ReleaseDate = gameDTO.ReleaseDate,
                    ImageURI = gameDTO.ImageURI };

                repository.CreateGame(game);
                return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.Id }, gameDTO);
            });

            // Update existing game
            group.MapPut("/{id:int}", (IGameRepository repository, int id, UpdateGameDTO updatedGameDTO) =>
            {
                Game? existingGame = repository.GetGame(id);

                if (existingGame == null)
                {
                    return Results.NotFound();
                }

                existingGame.Name = updatedGameDTO.Name;
                existingGame.Genre = updatedGameDTO.Genre;
                existingGame.Price = updatedGameDTO.Price;
                existingGame.ReleaseDate = updatedGameDTO.ReleaseDate;
                existingGame.ImageURI = updatedGameDTO.ImageURI;

                repository.UpdateGame(existingGame);

                return Results.NoContent();
            });

            // Delete existing game
            group.MapDelete("/{id:int}", (IGameRepository repository, int id) =>
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
