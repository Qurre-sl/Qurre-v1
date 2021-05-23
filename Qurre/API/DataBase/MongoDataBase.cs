namespace Qurre.API.DataBase
{
    public class MongoDataBase
    {
        public global::MongoDB.Driver.IAsyncCursor<string> ListDatabaseNames(CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IAsyncCursor<string> ListDatabaseNames(global::MongoDB.Driver.ListDatabaseNamesOptions options, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IAsyncCursor<string> ListDatabaseNames(global::MongoDB.Driver.IClientSessionHandle session, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IAsyncCursor<string> ListDatabaseNames(global::MongoDB.Driver.IClientSessionHandle session, global::MongoDB.Driver.ListDatabaseNamesOptions options, CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IAsyncCursor<string>> ListDatabaseNamesAsync(CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IAsyncCursor<string>> ListDatabaseNamesAsync(global::MongoDB.Driver.ListDatabaseNamesOptions options, CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IAsyncCursor<string>> ListDatabaseNamesAsync(global::MongoDB.Driver.IClientSessionHandle session, CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IAsyncCursor<string>> ListDatabaseNamesAsync(global::MongoDB.Driver.IClientSessionHandle session, global::MongoDB.Driver.ListDatabaseNamesOptions options, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IAsyncCursor<global::MongoDB.Bson.BsonDocument> ListDatabases(global::MongoDB.Driver.IClientSessionHandle session, global::MongoDB.Driver.ListDatabasesOptions options, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IAsyncCursor<global::MongoDB.Bson.BsonDocument> ListDatabases(global::MongoDB.Driver.ListDatabasesOptions options, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IAsyncCursor<global::MongoDB.Bson.BsonDocument> ListDatabases(global::MongoDB.Driver.IClientSessionHandle session, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IAsyncCursor<global::MongoDB.Bson.BsonDocument> ListDatabases(CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IAsyncCursor<global::MongoDB.Bson.BsonDocument>> ListDatabasesAsync(global::MongoDB.Driver.IClientSessionHandle session, global::MongoDB.Driver.ListDatabasesOptions options, CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IAsyncCursor<global::MongoDB.Bson.BsonDocument>> ListDatabasesAsync(global::MongoDB.Driver.IClientSessionHandle session, CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IAsyncCursor<global::MongoDB.Bson.BsonDocument>> ListDatabasesAsync(CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IAsyncCursor<global::MongoDB.Bson.BsonDocument>> ListDatabasesAsync(global::MongoDB.Driver.ListDatabasesOptions options, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IClientSessionHandle StartSession(global::MongoDB.Driver.ClientSessionOptions options = null, CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IClientSessionHandle> StartSessionAsync(global::MongoDB.Driver.ClientSessionOptions options = null, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IChangeStreamCursor<TResult> Watch<TResult>(global::MongoDB.Driver.PipelineDefinition<global::MongoDB.Driver.ChangeStreamDocument<global::MongoDB.Bson.BsonDocument>, TResult> pipeline, global::MongoDB.Driver.ChangeStreamOptions options = null, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IChangeStreamCursor<TResult> Watch<TResult>(global::MongoDB.Driver.IClientSessionHandle session, global::MongoDB.Driver.PipelineDefinition<global::MongoDB.Driver.ChangeStreamDocument<global::MongoDB.Bson.BsonDocument>, TResult> pipeline, global::MongoDB.Driver.ChangeStreamOptions options = null, CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IChangeStreamCursor<TResult>> WatchAsync<TResult>(global::MongoDB.Driver.PipelineDefinition<global::MongoDB.Driver.ChangeStreamDocument<global::MongoDB.Bson.BsonDocument>, TResult> pipeline, global::MongoDB.Driver.ChangeStreamOptions options = null, CancellationToken cancellationToken = default);
        public System.Threading.Tasks.Task<global::MongoDB.Driver.IChangeStreamCursor<TResult>> WatchAsync<TResult>(global::MongoDB.Driver.IClientSessionHandle session, global::MongoDB.Driver.PipelineDefinition<global::MongoDB.Driver.ChangeStreamDocument<global::MongoDB.Bson.BsonDocument>, TResult> pipeline, global::MongoDB.Driver.ChangeStreamOptions options = null, CancellationToken cancellationToken = default);
        public global::MongoDB.Driver.IMongoClient WithReadConcern(global::MongoDB.Driver.ReadConcern readConcern);
        public global::MongoDB.Driver.IMongoClient WithReadPreference(global::MongoDB.Driver.ReadPreference readPreference);
        public global::MongoDB.Driver.IMongoClient WithWriteConcern(global::MongoDB.Driver.WriteConcern writeConcern);
    }
}
