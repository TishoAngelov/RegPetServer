﻿namespace RegPetServer.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFRepository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private IDbSet<T> set;

        public EFRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);

            return entity;
        }

        public T Delete(object id)
        {
            T entity = this.Find(id);
            this.Delete(entity);

            return entity;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (state == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}