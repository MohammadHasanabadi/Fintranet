using Micro.Services.ACC.Entity;
using MongoDB.Driver;

namespace Micro.Services.ACC.Data
{
    public abstract class IACCdbContext
    {
        public IMongoCollection<Group> Groups { get; set; }
        public IMongoCollection<Person> Persons { get; set; }

    }
}
