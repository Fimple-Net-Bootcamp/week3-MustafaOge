using Microsoft.AspNetCore.Mvc;
using VirtualPetCareAPI.Context;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly PetCareDbContext _context;

        public UsersController(PetCareDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new {id = user.Id }, user);

        }

        [HttpGet]
        public async Task<ActionResult<User>>GetUser(int userId)
        {
           var user  = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return user;

        }



    }
}
