using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPITeste.Models;

namespace WebAPITeste.Services
{
    public class StoreService
    {
        private readonly IMongoCollection<Shopp> _shoppsCollection;


        public StoreService(
        IOptions<StoreDataBaseSettings> StoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                StoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                StoreDatabaseSettings.Value.DatabaseName);

            _shoppsCollection = mongoDatabase.GetCollection<Shopp>(
                StoreDatabaseSettings.Value.StoreCollectionName);
        }

        public async Task<List<Shopp>> GetAsync() =>
            await _shoppsCollection.Find(_ => true).ToListAsync();

        public async Task<Shopp?> GetAsync(string id) =>
            await _shoppsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Shopp shopp) =>
            await _shoppsCollection.InsertOneAsync(shopp);

        public async Task UpdateAsync(string id, Shopp updatedshopp) =>
            await _shoppsCollection.ReplaceOneAsync(x => x.Id == id, updatedshopp);

        public async Task RemoveAsync(string id) =>
            await _shoppsCollection.DeleteOneAsync(x => x.Id == id);
    }



}

