using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/pet")]
    public class PetController: ControllerBase
    {
        private readonly MongoHelper DB;

        public PetController(MongoHelper db)
        {
            DB = db;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pet pet)
        {
            try
            {
                pet.CreatedAt = DateTime.Now;
                await DB.AddNewPet(pet);
                return Ok("Pet added");
            }
            catch 
            {
                return BadRequest();
            }

        }

        //[HttpGet]
        //public async Task<ActionResult<List<Pet>>> Get()
        //{
        //    var pets = await DB.GetAllPets();
        //    int ages = 0;
        //    foreach (var pet in pets)
        //    {
        //        ages += pet.Age;
        //    }
        //    Console.WriteLine(ages);
        //    return Ok(new { pets, ages});
        //}
    }
}
