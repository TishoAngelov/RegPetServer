namespace RegPetServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PetCategory
    {
        private ICollection<Pet> pets;

        public PetCategory()
        {
            this.pets = new HashSet<Pet>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}