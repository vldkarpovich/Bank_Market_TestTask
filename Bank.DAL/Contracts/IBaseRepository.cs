using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DAL.Contracts
{
    /// <summary>
    /// EF Base class contract for models
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Adds a new entity
        /// SaveChangesAsync() needs to be called before it is persisted.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<T> AddAsync(T input);

        /// <summary>
        /// Marks the entity to be updated.
        /// SaveChangesAsync() needs to be called before it is persisted.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        void Update(T input);

        /// <summary>
        /// Saves all the changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
