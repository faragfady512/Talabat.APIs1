using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Repository.Entites;

namespace Talabat.Core.Specification
{
    public class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product>
    {
        /// This Constructor Use When Need to Get All Products
        public ProductWithBrandAndTypeSpecifications(ProductSpecParams productParams)
            : base(P =>
                    (string.IsNullOrEmpty(productParams.Search) || P.Name.ToLower().Contains(productParams.Search)) &&
                    (!productParams.BrandId.HasValue || P.ProductBrandId == productParams.BrandId.Value) &&
                    (!productParams.TypeId.HasValue || P.ProductTypeId == productParams.TypeId.Value))
        {
            AddInclude(P => P.ProductType);
            AddInclude(P => P.ProductBrand);
            AddOrderBy(P => P.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Salary);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(P => P.Salary);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
        }

        /// This Constructor Use When Need to Get a Specific Product With Id
        public ProductWithBrandAndTypeSpecifications(int id) : base(P => P.ID == id)
        {
            AddInclude(P => P.ProductType);
            AddInclude(P => P.ProductBrand);
        }

















































        //// this ctor use to get all products 
        //public ProductWithBrandAndTypeSpecifications( ProductSpecParams productSpecParams ) :
        //    base(
        //        P => (!productSpecParams.BrandId.HasValue || P.ProductBrandId == productSpecParams.BrandId)  &&

        //             (!productSpecParams.TypeId.HasValue  || P.ProductTypeId == productSpecParams.TypeId)
        //        )
        //{
        //    Includes.Add(p => p.ProductBrand);
        //    Includes.Add(p => p.ProductType);

        //    ApplyPigination(productSpecParams.PageIndex * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

        //    if (!string.IsNullOrEmpty(productSpecParams.sort))
        //    {
        //        switch (productSpecParams.sort)
        //        {
        //            case "priceAsec":
        //                AddOrderBy(s => s.Salary);
        //                break;
        //            case "priceDesc":
        //                AddOrderByDesc(s => s.Salary);
        //                break;
        //            default:
        //                AddOrderBy(s => s.Name);
        //                break;

        //        }

        //    }

        //}
        //public ProductWithBrandAndTypeSpecifications(int id) : base(P => P.ID == id)
        //{
        //    Includes.Add(P => P.ProductType);
        //    Includes.Add(P => P.ProductBrand);
        //}
    }
}
