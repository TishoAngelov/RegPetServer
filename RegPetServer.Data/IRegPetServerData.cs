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

        // TODO: Add all repos.
    }
}
