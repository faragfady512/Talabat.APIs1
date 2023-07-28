﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Repository
{
    public interface IBasketRepository
    {
         Task<CustomerBasket> GetBasketAsync (string Basketid);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task <bool> DeleteBasketAsync (string Basketid);           



    }
}
