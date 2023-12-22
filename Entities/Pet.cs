using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareAPI.Entities
{
    public class Pet : Entity
    {

        public string Name { get; set; }

        public string Type { get; set; }

        public User User { get; set; }

        public int Age { get; set; }


      

    }
}
