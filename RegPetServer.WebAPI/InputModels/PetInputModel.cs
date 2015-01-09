namespace RegPetServer.WebAPI.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PetInputModel
    {
        [Required]
        public string Name { get; set; }

        public string Breed { get; set; }

        public string PetCategory { get; set; }
    }
}