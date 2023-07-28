﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Repository.Entites;

namespace Talabat.Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecifications<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
            : base(P =>
                    (string.IsNullOrEmpty(productParams.Search) || P.Name.ToLower().Contains(productParams.Search)) &&
                     (!productParams.BrandId.HasValue || P.ProductBrandId == productParams.BrandId.Value) &&
                     (!productParams.TypeId.HasValue || P.ProductTypeId == productParams.TypeId.Value))
        {
        }
    }
}
