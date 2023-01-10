using lab3.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace lab3.Services
{
    public class PersonsService
    {
        private readonly IMongoCollection<Person> _personsCollection;

        public PersonsService(
            IOptions<LibraryStoreDatabaseSettings> libraryStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                libraryStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                libraryStoreDatabaseSettings.Value.DatabaseName);

            _personsCollection = mongoDatabase.GetCollection<Person>(
                libraryStoreDatabaseSettings.Value.PersonsCollectionName);
        }

        public async Task<List<Person>> GetAsync() =>
            await _personsCollection.Find(_ => true).ToListAsync();

        public async Task<Person?> GetAsync(int id) =>
            await _personsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Person person) =>
            await _personsCollection.InsertOneAsync(person);

        public async Task UpdateAsync(int id, Person person) =>
            await _personsCollection.ReplaceOneAsync(x => x.Id == id, person);

        public async Task RemoveAsync(int id) =>
            await _personsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
