using MongoDB.Driver;
namespace Qurre.API.DataBase
{
    public class Database
    {
        public Database(Client client, string name)
        {
            Name = name;
            MongoDatabase = client.MClient.GetDatabase(name);
        }
        public readonly IMongoDatabase MongoDatabase;
        public readonly string Name;
        public Collection GetCollection(string name) => new(this, name);
    }
}