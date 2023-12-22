using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareAPI.Entities
{
    public class PetFood : Entity
    {

        public string Name { get; set; }

        public Guid PetId { get; set; }

        public Pet Pet { get; set; }


    }
}
