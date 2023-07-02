using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Repository.Entites
{
    public class Product : BaseEntite
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Decimal Salary { get; set; }  

         public string PictureUrl { get; set; }

        public int ProductBrandId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int ProductTypeId { get; set; }


        public ProductType ProductType { get; set; }



    }
}
