﻿namespace IllyCake.Data.Repository
{
    using IllyCake.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T: class
    {
        IQueryable<T> All();
        
        T GetById(object id);

        Task<T> GetByIdAsync(object id);
        
        void Add(T entity);

        Task AddAsync(T entity);

        void AddRange(IEnumerable<T> entity);

        Task AddRangeAsync(IEnumerable<T> entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();

        Task SaveAsync();
    }
}
