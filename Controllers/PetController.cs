using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualPetCareAPI.Context;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("/api/pets")]
    public class PetController : ControllerBase
    {
        private readonly PetCareDbContext _petCareDbContext;

        public PetController(PetCareDbContext petCareDbContext)
        {
            _petCareDbContext = petCareDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {

            if (pet.User != null)
            {
                pet.User.Id = pet.User.Id;
            }

            _petCareDbContext.Pets.Add(pet);
            await _petCareDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { petId = pet.Id }, pet);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return Ok(await _petCareDbContext.Pets.ToListAsync());
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<User>> GetPet(int petId)
        {
            var pet = await _petCareDbContext.Pets.FindAsync(petId);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);    
        }
    }
}
