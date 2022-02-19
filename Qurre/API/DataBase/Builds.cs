using MongoDB.Bson;
using MongoDB.Driver;
namespace Qurre.API.DataBase
{
    public static class Builds
    {
        private readonly static FilterDefinitionBuilder<BsonDocument> __filter = new();
        private readonly static IndexKeysDefinitionBuilder<BsonDocument> __index = new();
        private readonly static ProjectionDefinitionBuilder<BsonDocument> __projection = new();
        private readonly static SortDefinitionBuilder<BsonDocument> __sort = new();
        private readonly static UpdateDefinitionBuilder<BsonDocument> __update = new();
        public static FilterDefinitionBuilder<BsonDocument> Filter => __filter;
        public static IndexKeysDefinitionBuilder<BsonDocument> IndexKeys => __index;
        public static ProjectionDefinitionBuilder<BsonDocument> Projection => __projection;
        public static SortDefinitionBuilder<BsonDocument> Sort => __sort;
        public static UpdateDefinitionBuilder<BsonDocument> Update => __update;
    }
}