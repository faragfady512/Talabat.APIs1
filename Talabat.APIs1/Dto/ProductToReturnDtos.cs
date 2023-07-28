using System;
using Talabat.Repository.Entites;

namespace Talabat.APIs1.Dto
{
    public class ProductToReturnDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Decimal Salary { get; set; }

        public string PictureUrl { get; set; }

        public int ProductBrandId { get; set; }

        public string ProductBrand { get; set; }

        public int ProductTypeId { get; set; }


        public string ProductType { get; set; }


    }
}
