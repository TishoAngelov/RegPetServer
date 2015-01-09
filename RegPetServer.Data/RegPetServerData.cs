namespace RegPetServer.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using RegPetServer.Data.Repositories;
    using RegPetServer.Models;

    public class RegPetServerData : IRegPetServerData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public RegPetServerData(RegPetServerDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Article> Articles
        {
            get { return this.GetRepository<Article>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
        }

        public IRepository<Breed> Breeds
        {
            get { return this.GetRepository<Breed>(); }
        }

        public IRepository<Pet> Pets
        {
            get { return this.GetRepository<Pet>(); }
        }

        public IRepository<PetCategory> PetCategories
        {
            get { return this.GetRepository<PetCategory>(); }
        }

        // TODO: Add repos for all models.

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}