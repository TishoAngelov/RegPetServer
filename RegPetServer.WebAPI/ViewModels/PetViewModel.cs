namespace RegPetServer.WebAPI.ViewModels
{
    public class PetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string PetCategory { get; set; }

        public string Breed { get; set; }
    }
}