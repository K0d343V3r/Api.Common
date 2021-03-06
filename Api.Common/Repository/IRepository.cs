﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Common.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        int Count();
        Task<List<T>> GetAsync(params Expression<Func<T, object>>[] includePredicates);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> wherePredicate, params Expression<Func<T, object>>[] includePredicates);
        Task<List<T>> GetAsync(RetrievalOptions<T> options, params Expression<Func<T, object>>[] includePredicates);
        Task<T> GetAsync(int id, params Expression<Func<T, object>>[] includePredicates);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
