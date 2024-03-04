using GameStoreApi.Endpoints;

namespace GameStoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGamesEndpoints();

            app.Run();
        }
    }
}
