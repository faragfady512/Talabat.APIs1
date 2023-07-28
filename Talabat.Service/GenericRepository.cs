using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Repository;
using Talabat.Core.Specification;
using Talabat.Repository.Data;
using Talabat.Repository.Entites;
using Talabat.Service.Data;


namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntite
    {
        private readonly StoreDbConetxt _dbContext;


        public GenericRepository(StoreDbConetxt dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }


        public async Task<IReadOnlyList<T>> GetAllSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }



        public async Task<T> GetByIdSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

  

        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
          
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
    }
}
