using GameStoreApi.Entities;

namespace GameStoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string GetGameEndPoint = "GetGame";

            List<Game> games = new()
            {
                new()
                {
                    Id = 1,
                    Name = "Street Fighter II",
                    Genre = "Fighting",
                    Price = 19.99M,
                    ReleaseDate = new DateTime(1991,2,1),
                    ImageURI = "https://placehold.co/100"
                },
                new()
                {
                    Id = 2,
                    Name = "Final Fantasy XIV",
                    Genre = "RPG",
                    Price = 59.99M,
                    ReleaseDate = new DateTime(2010,9,30),
                    ImageURI = "https://placehold.co/100"
                },
                new()
                {
                    Id = 3,
                    Name = "FIFA 2023",
                    Genre = "RPG",
                    Price = 69.99M,
                    ReleaseDate = new DateTime(2022,9,27),
                    ImageURI = "https://placehold.co/100"
                }
            };

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/games", () => games);
            app.MapGet("/games/{id:int}", (int id) =>
            {
                Game? game = games.Find(g => g.Id == id);

                if (game == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(game);
            }).WithName(GetGameEndPoint);

            app.MapPost("/games", (Game game) =>
            {
                game.Id = games.Max(g => g.Id) + 1;
                games.Add(game);

                return Results.CreatedAtRoute(GetGameEndPoint, new { id = game.Id }, game);
            });

            app.MapPut("/games/{id:int}", (int id, Game updatedGame) =>
            {
                Game? existingGame = games.Find(g => g.Id == id);

                if (existingGame == null)
                {
                    return Results.NotFound();
                }

                existingGame.Name = updatedGame.Name;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Price = updatedGame.Price;
                existingGame.ReleaseDate = updatedGame.ReleaseDate;
                existingGame.ImageURI = updatedGame.ImageURI;

                return Results.NoContent();
            });

            app.MapDelete("games/{id:int}", (int id) =>
            {
                Game? existingGame = games.Find(g => g.Id == id);

                if (existingGame != null)
                {
                    games.Remove(existingGame);
                }

                return Results.NoContent();
            });

            app.Run();
        }
    }
}
