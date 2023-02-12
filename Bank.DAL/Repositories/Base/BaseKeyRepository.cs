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

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentNullException("Id for input can not be empty");

                return await _set.FirstAsync(c => c.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not fetch by id " + typeof(T).ToString() + ": " + e.ToString());
                throw;
            }
        }
    }
}
