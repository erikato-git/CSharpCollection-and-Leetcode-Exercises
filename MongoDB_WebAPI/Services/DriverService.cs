using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_WebAPI.Configurations;
using MongoDB_WebAPI.Models;
using ZstdSharp.Unsafe;

namespace MongoDB_WebAPI.Services
{
    public class DriverService
    {
        private readonly IMongoCollection<Driver> _driverCollection;

        public DriverService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DataBaseName);
            _driverCollection = mongoDb.GetCollection<Driver>(databaseSettings.Value.DataBaseName); 
        }

        public async Task<List<Driver>> GetAsync()
        {
            return await _driverCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Driver> GetAsync(string id)
        {
            return await _driverCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Driver driver)
        {
            await _driverCollection.InsertOneAsync(driver);
            return;
        }

        public async Task UpdateAsync(Driver driver)
        {
            await _driverCollection.ReplaceOneAsync(x => x.Id == driver.Id, driver);
            return;
        }

        public async Task RemoveAsync(string id)
        {
            await _driverCollection.DeleteOneAsync(x => x.Id == id);
            return;
        }


    }
}
