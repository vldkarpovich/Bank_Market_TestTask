using Bank.DAL.Contracts;
using Bank.EFModels.Models.Base;
using Bank.EFModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL.Repositories.Base
{
    public class BaseKeyRepository<S, T> : BaseRepository<S, T>, IBaseKeyRepository<T> where T : Entity
    {

        public BaseKeyRepository(
                ILogger<S> logger,
                ApplicationDataContext context)
            : base(logger, context)
        {
        }

        public virtual async Task<T> GetByIdAsync(Guid id, Func<IQueryable<T>, IQueryable<T>> include = null)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentNullException("Id for input can not be empty");

                IQueryable<T> queryWithInclude = include?.Invoke(_set) ?? _set.AsQueryable();

                return await queryWithInclude.Where(c => c.Id.Equals(id))?.AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Could not fetch by id for set " + typeof(T).ToString() + ": " + e.ToString());
                throw;
            }
        }
    }
}
