﻿using Bank.DAL.Contracts;
using Bank.EFModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Bank.DAL.Repositories.Base
{
    public class BaseRepository<S, T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDataContext _context;
        protected readonly DbSet<T> _set;
        protected readonly ILogger<S> _logger;

        public BaseRepository(
                ILogger<S> logger,
                ApplicationDataContext context)
        {
            _logger = logger;
            _context = context;
            _set = context.Set<T>();
        }

        public async virtual Task<T> AddAsync(T input)
        {
            try
            {
                if (input == null)
                    throw new ArgumentNullException("input can not be null");

                await _set.AddAsync(input);
                return input;
            }
            catch (Exception e)
            {
                _logger.LogError("Could not add for set " + typeof(T).ToString() + ": " + e.ToString());
                throw;
            }
        }

        public virtual void Update(T input)
        {
            try
            {
                if (input == null)
                    throw new ArgumentNullException("input can not be null");

                var result = _context.Update(input);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not update entity for set " + typeof(T).ToString() + ": " + e.ToString());
                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Could not update changes for set " + typeof(T).ToString() + ": " + e.ToString());
                throw;
            }
        }
    }
}