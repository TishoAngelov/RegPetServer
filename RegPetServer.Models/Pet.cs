namespace RegPetServer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string UserId { get; set; }

        public string Owner { get; set; }

        public virtual int PetCategoryId { get; set; }

        public virtual PetCategory PetCategory { get; set; }

        public virtual int BreedId { get; set; }

        public virtual Breed Breed { get; set; }
    }
}