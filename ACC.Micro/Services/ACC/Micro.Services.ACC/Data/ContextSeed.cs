using Micro.Services.ACC.Entity;
using MongoDB.Driver;

namespace Micro.Services.ACC.Data
{
    public class ContextSeed
    {
        public static void SeedData(IMongoCollection<Group> collectionGroup, IMongoCollection<Person> collectionPerson)
        {
            var existed = collectionGroup.Find(p => true).Any();
            if (!existed)
            {
                collectionGroup.InsertMany(GetDefaulData());

            }

            var existedperson = collectionPerson.Find(p => true).Any();
            if (!existedperson)
            {
                collectionPerson.InsertMany(GetDefaulDataPerson());

            }
        }

        public static IEnumerable<Group> GetDefaulData()
        {
            return new List<Group>()
            {
                new Group{
                 GroupName="دارایی جاری",
                 GroupCode="01"
                },
                new Group{
                 GroupName="دارایی غیر جاری",
                 GroupCode="01"
                }

            };

        }

        public static IEnumerable<Person> GetDefaulDataPerson()
        {
            return new List<Person>()
            {
                new Person{
                Familly="Hassanabadi",
                Mob="09128303238",
                Name="Mohammad"
                },
                
            };

        }

    }
}
