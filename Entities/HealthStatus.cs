using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareAPI.Entities
{
    public class HealthStatus : Entity
    {

        public string Status { get; set; }

        [Required]
        public Guid PetId { get; set; }

        public Pet Pet { get; set; }
    }
}
