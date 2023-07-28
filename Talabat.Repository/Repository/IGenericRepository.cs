using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Specification;
using Talabat.Repository.Entites;

namespace Talabat.Core.Repository
{
    public interface IGenericRepository<T> where T : BaseEntite
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id); 

        Task<IReadOnlyList<T>> GetAllSpecAsync(ISpecifications<T> spec);
        Task<T> GetByIdSpecAsync(ISpecifications<T> spec);

    }
}
