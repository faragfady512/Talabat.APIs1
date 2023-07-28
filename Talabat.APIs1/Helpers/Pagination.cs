using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Talabat.APIs1.Dto;
namespace Talabat.APIs1.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
   

   
 
        public class Pagination<T>
        {



            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public int Count { get; set; }
            public IReadOnlyList<T> Data { get; set; }


            public Pagination(int pageIndex, int pageSize, int totalItems, IReadOnlyList<T> data)
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
                Count = totalItems;
                Data = data;
            }
        }
    }

