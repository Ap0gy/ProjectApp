using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoApi.Models;
using TodoApi.Models.Configuration;

namespace TodoApi.Repositories
{
    public class MongoToDoRepository : IToDoRepository
    {
        private readonly IMongoCollection<ToDoItem> _toDosCollection;

        public MongoToDoRepository(IOptions<ProjectAppDb> databaseConnectionOptions)
        {
            var databaseConnectionSettings = databaseConnectionOptions.Value;
            // https://stackoverflow.com/questions/57690523/is-it-safe-to-create-multiple-instances-of-mongoclient-by-using-the-same-connect
            var mongoClient = new MongoClient(databaseConnectionSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseConnectionSettings.DatabaseName);
            _toDosCollection = mongoDatabase.GetCollection<ToDoItem>(databaseConnectionSettings.ToDosCollectionName);
        }

        public async Task AddToDoItem(ToDoItem todoItem) => await _toDosCollection.InsertOneAsync(todoItem);

        public Task<List<ToDoItem>> GetToDoItems() => _toDosCollection.Find(tdi => true).ToListAsync();

        public async Task<ToDoItem> GetToDoItemById(Guid id) => await _toDosCollection.Find(tdi => tdi.Id == id).SingleAsync();

        public async Task UpdateToDoItem(ToDoItem todoItem) => await _toDosCollection.ReplaceOneAsync(tdi => tdi.Id == todoItem.Id, todoItem);

        public async Task DeleteToDoItem(Guid id) => await _toDosCollection.DeleteOneAsync(tdi => tdi.Id == id);
    }
}
