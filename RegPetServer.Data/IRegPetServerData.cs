namespace RegPetServer.Data
{
    using System;
    using RegPetServer.Data.Repositories;
    using RegPetServer.Models;

    public interface IRegPetServerData
    {
        IRepository<Article> Articles { get; }

        IRepository<Category> Categories { get; }

        int SaveChanges();

        IRepository<Tag> Tags { get; }

        IRepository<Breed> Breeds { get; }

        IRepository<Pet> Pets { get; }

        IRepository<PetCategory> PetCategories { get; }

        // TODO: Add all repos.
    }
}
