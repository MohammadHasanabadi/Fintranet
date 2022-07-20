using Micro.Services.ACC.Entity;
using MongoDB.Driver;

namespace Micro.Services.ACC.Data
{
    public class AccdbContext : IACCdbContext
    {
        public AccdbContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("DatabaseSettings:DatabaseName"));
            Groups = database.GetCollection<Group>(config.GetValue<string>("DatabaseSettings:CollectionNameGroup"));
            Persons = database.GetCollection<Person>(config.GetValue<string>("DatabaseSettings:CollectionNamePerson"));



            //Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            ContextSeed.SeedData(Groups,Persons);

        }

        //public IMongoCollection<Group> Groups { get; }
        //public IMongoCollection<Person> Persons { get; }


    }
}
