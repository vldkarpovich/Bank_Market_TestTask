using Bank.EFModels.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DAL.Contracts
{
    /// <summary>
    /// EF Base class contract for models with a key
    /// </summary>
    public interface IBaseKeyRepository<T> : IBaseRepository<T> where T : Entity
    {
        /// <summary>
        /// Gets the entity with the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id);
    }
}
