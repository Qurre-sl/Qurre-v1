using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Qurre.API.DataBase
{
    public class Collection
    {
        public Collection(Database db, string name)
        {
            Name = name;
            MongoDB = db.MongoDatabase.GetCollection<BsonDocument>(name);
        }

        ///<summary>
        ///<para>Finds all documents in the collection with the given parameters.</para>
        ///<para>Example:</para>
        /// <example>
        /// <code>
        /// List&lt;BsonDocument&gt; Documents = Collection.Find(new BsonDocument("UserId", Player.UserId));
        /// </code>
        /// Find and Parse
        /// <code>
        /// IEnumerable&lt;T&gt; Documents = Collection.Find(new BsonDocument("UserId", Player.UserId)).Select(x => Collection.ParseBson&lt;T&gt;(x));
        /// </code>
        /// </example>
        ///</summary>
        public List<BsonDocument> Find(BsonDocument doc) => MongoDB.Find(doc).ToList();
        ///<summary>
        ///<para>Finds all documents in the collection with a search format.</para>
        ///<para>Example:</para>
        /// <example>
        /// <code>
        /// List&lt;BsonDocument&gt; Documents = Collection.Find(_ => true);
        /// </code>
        /// Find and Parse
        /// <code>
        /// IEnumerable&lt;T&gt; Documents = Collection.Find(_ => true).Select(x => Collection.ParseBson&lt;T&gt;(x));
        /// </code>
        /// </example>
        ///</summary>
        public List<BsonDocument> Find(Expression<Func<BsonDocument, bool>> filter) => MongoDB.Find(filter).ToList();
        ///<summary>
        ///<para>Updates the first document in the collection that matches the parameters.</para>
        ///<para>Example:</para>
        /// <example>
        /// <code>
        /// var filter = Builds.Filter.Eq("UserId", Player.UserId);
        /// var update = Builds.Update.Set("level", 10);
        /// Collection.UpdateOne(filter, update);
        /// </code>
        /// </example>
        ///</summary>
        public UpdateResult UpdateOne(FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update, UpdateOptions options = null) =>
            MongoDB.UpdateOne(filter, update, options);
        ///<summary>
        ///<para>Updates all documents in the collection that match the parameters.</para>
        ///<para>Example:</para>
        /// <example>
        /// <code>
        /// var filter = Builds.Filter.Eq("UserId", Player.UserId);
        /// var update = Builds.Update.Set("level", 10);
        /// Collection.UpdateAll(filter, update);
        /// </code>
        /// </example>
        ///</summary>
        public UpdateResult UpdateAll(FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update, UpdateOptions options = null) =>
            MongoDB.UpdateMany(filter, update, options);
        ///<summary>
        ///<para>Replaces the first document in the collection that matches the parameters.</para>
        ///<para>Example:</para>
        /// <example>
        /// <code>
        /// var filter = Builds.Filter.Eq("UserId", Player.UserId);
        /// Collection.ReplaceOne(filter, BsonDocument);
        /// </code>
        /// </example>
        ///</summary>
        public ReplaceOneResult ReplaceOne(FilterDefinition<BsonDocument> filter, BsonDocument replacement, ReplaceOptions options = null) =>
            MongoDB.ReplaceOne(filter, replacement, options);
        ///<summary>
        ///<para>Parse BsonDocument into your class.</para>
        ///<para>Example:</para>
        /// <example>
        /// <code>
        /// T Data = Collection.ParseBson&lt;T&gt;(BsonDocument);
        /// or
        /// MyClass Data = Collection.ParseBson&lt;MyClass&gt;(BsonDocument);
        /// </code>
        /// </example>
        ///</summary>
        public T ParseBson<T>(BsonDocument bson) => JsonConvert.DeserializeObject<T>(bson is null ? "" : bson.ToJson());

        ///<summary>
        ///<para>MongoDB class, if you are missing something in this class.</para>
        ///</summary>
        public readonly IMongoCollection<BsonDocument> MongoDB;

        public readonly string Name;
    }
}