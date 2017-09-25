namespace IllyCake.Data.Repository
{
    using System;
    using System.Linq;

    using Models;
    using Microsoft.EntityFrameworkCore;

    public class Repository<T> : IRepository<T>
        where T : class
    {
        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private DbSet<T> DbSet { get; }

        private DbContext Context { get; }

        /// <summary>
        /// Returns all entities from the DB
        /// </summary>
        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        /// <summary>
        /// Marks entity as deleted
        /// </summary>
        public void Delete(T entity)
        {
            if (entity is IDeletableEntity)
            {
                var deletable = entity as IDeletableEntity;
                deletable.IsDeleted = true;
                deletable.DeletedOn = DateTime.UtcNow;
            }
            else
            {
                this.DbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Removes entity from the DB
        /// </summary>
        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        /// <summary>
        /// Save entities changes to the DB
        /// </summary>
        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
