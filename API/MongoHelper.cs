using MongoDB.Driver;
using API.Models;

namespace API
{
    public class MongoHelper
    {
        private readonly IMongoCollection<Pet> _pets;

        public MongoHelper(IMongoClient mongoClient)
        {
            var dataBase = mongoClient.GetDatabase("PetsDB");
            _pets = dataBase.GetCollection<Pet>("pets");
        }

        //Post Request
        public async Task AddNewPet(Pet pet)
        {
            await _pets.InsertOneAsync(pet);
        }

        //Get Request
        public async Task<List<Pet>> GetAllPets()
        {
            return await _pets.Find(item => true).ToListAsync();
        }

    }
}
