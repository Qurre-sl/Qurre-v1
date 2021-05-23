namespace Qurre.API.DataBase
{
    public class DataBase
    {
        public static DataBase Static { get; }
        public bool Enabled { get; }
        public bool Connected { get; }

        public global::MongoDB.Driver.IMongoCollection<global::MongoDB.Bson.BsonDocument> GetCollection(global::MongoDB.Driver.IMongoDatabase database, string name);
        public global::MongoDB.Driver.IMongoDatabase GetDatabase(string name);
        public List<global::MongoDB.Bson.BsonDocument> GetDocuments(global::MongoDB.Driver.IMongoCollection<global::MongoDB.Bson.BsonDocument> collection, global::MongoDB.Bson.BsonDocument parameters);
        public object GetValue(global::MongoDB.Bson.BsonDocument document, string key);
    }
}