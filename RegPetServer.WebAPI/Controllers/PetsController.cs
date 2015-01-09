namespace RegPetServer.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;
    using RegPetServer.Data;
    using RegPetServer.Models;
    using RegPetServer.WebAPI.InputModels;
    using Microsoft.AspNet.Identity;
    using RegPetServer.WebAPI.ViewModels;

    public class PetsController : BaseController
    {
        public PetsController()
            : base()
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(PetInputModel petModel)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var currentUserUsername = this.User.Identity.Name;

            var petCategory = GetPetCategory(petModel.PetCategory);
            var breed = GetBreed(petModel.Breed);

            var pet = new Pet
            {
                Name = petModel.Name,
                UserId = currentUserId,
                Owner = currentUserUsername,
                PetCategory = petCategory,
                Breed = breed
            };

            this.data.Pets.Add(pet);
            this.data.SaveChanges();

            var viewModelPet = new PetViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Owner = pet.Owner,
                PetCategory = pet.PetCategory.Name,
                Breed = pet.Breed.Name
            };

            return Json(viewModelPet);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var pets = this.data.Pets.All().Select(p => new PetViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Owner = p.Owner,
                PetCategory = p.PetCategory.Name,
                Breed = p.Breed.Name
            });

            return Json(pets);
        }

        private PetCategory GetPetCategory(string petCategoryName)
        {
            var petCategory = this.data.PetCategories.All().FirstOrDefault(pc => pc.Name == petCategoryName);

            if (petCategory == null)
            {
                petCategory = new PetCategory
                {
                    Name = petCategoryName
                };
                this.data.PetCategories.Add(petCategory);
            }

            return petCategory;
        }

        private Breed GetBreed(string breed)
        {
            var result = this.data.Breeds.All()
                .FirstOrDefault(b => b.Name == breed);
            if (result == null)
            {
                result = new Breed { Name = breed };
                this.data.Breeds.Add(result);
            }

            return result;
        }
    }
}