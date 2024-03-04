namespace GameStoreApi.Entities
{
    public static class EntityExtensions
    {
        public static GameDTO AsDTO(this Game game)
        {
            return new GameDTO(
                game.Id,
                game.Name,
                game.Genre,
                game.Price,
                game.ReleaseDate,
                game.ImageURI
                );
        }
    }
}
