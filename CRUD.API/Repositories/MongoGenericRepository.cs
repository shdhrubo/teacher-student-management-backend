using CRUD.API.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.API.Repositories
{
    public class MongoGenericRepository<T> : IMongoGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoGenericRepository(IMongoDatabase dbContext, string collectionName)
        {
            _collection = dbContext.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
