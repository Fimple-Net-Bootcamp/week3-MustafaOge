using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VirtualPetCareAPI.Context;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly PetCareDbContext _context;

        public ActivitiesController(PetCareDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<PetActivity>> PostActivity(PetActivity activity)
        {
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivities), new { petId = activity.Id }, activity);
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<IEnumerable<PetActivity>>> GetActivities(int petId)
        {
            var activities =  _context.Activities.Where(a => a.PetId == petId).FirstOrDefault();
            return Ok(activities);
        }
    }
}
