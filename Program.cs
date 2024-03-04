using GameStoreApi.Endpoints;
using GameStoreApi.Repositories;

namespace GameStoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IGameRepository, InMemGameRepository>();

            var app = builder.Build();

            app.MapGamesEndpoints();

            app.Run();
        }
    }
}
