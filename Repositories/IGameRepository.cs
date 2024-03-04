using GameStoreApi.Entities;

namespace GameStoreApi.Repositories
{
    public interface IGameRepository
    {
        void CreateGame(Game game);
        void DeleteGame(int id);
        IEnumerable<Game> GetAll();
        Game? GetGame(int id);
        void UpdateGame(Game updatedGame);
    }
}