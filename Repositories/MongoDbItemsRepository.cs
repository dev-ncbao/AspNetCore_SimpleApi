using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            await itemsCollection.DeleteOneAsync(item => item.Id.Equals(id));
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = await (await itemsCollection.FindAsync(item => item.Id.Equals(id))).SingleOrDefaultAsync();
            return item;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            var items = await (await itemsCollection.FindAsync(new BsonDocument())).ToListAsync();
            return items;
        }

        public async Task<Item> InsertItemAsync(Item item)
        {
            await itemsCollection.InsertOneAsync(item);
            return item;
        }

        public async Task UpdateItemAsync(Guid id, Item item)
        {
            await itemsCollection.ReplaceOneAsync(item => item.Id.Equals(id), item);
        }
    }
}