using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataStorage
{
    public static class ServiceCollectionDataClientExtensions
    {
        public static void AddDataStorage(this IServiceCollection collection, IConfiguration configuration)
        {
            var apiKey = configuration["Firebase:Config"];
            var email = configuration["Firebase:Email"];
            var password = configuration["Firebase:Password"];

            collection.AddScoped<IDataClient>(x => new FirebaseDataClient(apiKey, email, password));
            collection.AddScoped<IDecksCollection, DecksCollection>();
            collection.AddScoped<ICardsCollection, CardsCollection>();
        }
    }
}
