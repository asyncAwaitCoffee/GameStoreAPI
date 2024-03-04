using GameStoreApi.Entities;

namespace GameStoreApi.Repositories
{
    public class InMemGameRepository
    {
        private readonly List<Game> games = new()
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

        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        public Game? GetGame(int id)
        {
            return games.Find(g => g.Id == id);
        }

        public void CreateGame(Game game)
        {
            game.Id = games.Max(g => g.Id) + 1;
            games.Add(game);
        }

        public void UpdateGame(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;
        }

        public void DeleteGame(int id)
        {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);
        }
    }
}
