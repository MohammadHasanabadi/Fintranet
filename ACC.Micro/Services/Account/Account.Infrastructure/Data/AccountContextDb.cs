using Account.Application.Contracts;
using Account.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Account.Infrastructure.Data
{
    public class AccountContextDb : IAccountContextDb
    {
        public AccountContextDb(IConfiguration config)
        {
            var client = new MongoClient(config.GetValue<string>("databaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("databaseSettings:DatabaseName"));
            Users = database.GetCollection<User>("databaseSettings:CollectionName");

            SeedData(Users, database);
        }

        public void SeedData(IMongoCollection<User> collection,IMongoDatabase database)
        {
            if ( collection.Find(x => true).Any())
            {
                //database.CreateCollection("User");


                collection.InsertMany(new List<User>()
                {
                new User()
                {
                    
                    Familly="hassanabadi",
                    Mob="989128303238",
                    Name="Mohammad",

                     UserName="hassanabadimim",
                    Password="123456",

                }
                }); ;
            }

        }
    }
}
