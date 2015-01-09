namespace RegPetServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Breed
    {
        private ICollection<Pet> pets;

        public Breed()
        {
            this.pets = new HashSet<Pet>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Pet> Pets
        {
            get { return this.pets; }
            set { this.pets = value; }
        }
    }
}