using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Repository.Entites;

namespace Talabat.Core.Specification
{
    public interface ISpecifications<T> where T : BaseEntite
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }

        public Expression<Func<T, object>> OrderBy { get; }
        public Expression<Func<T, object>> OrderByDescending { get; }

        public int Take { get; }
        public int Skip { get; }

        public bool IsPagingEnabled { get; }





    }
}
